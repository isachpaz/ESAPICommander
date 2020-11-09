using System.Collections.Generic;

namespace ESAPIProxy
{
    public class TagNode
    {
        public List<TagNode> Children = new List<TagNode>();
        public TagNode Parent { get; set; }
        public MyObject Source { get; set; }

        List<TagNode> BuildTreeAndGetRoots(List<MyObject> actualObjects)
        {
            var lookup = new Dictionary<int, TagNode>();
            var rootNodes = new List<TagNode>();

            foreach (var item in actualObjects)
            {
                // add us to lookup
                TagNode ourNode;
                if (lookup.TryGetValue(item.ID, out ourNode))
                {
                    // was already found as a parent - register the actual object
                    ourNode.Source = item;
                }
                else
                {
                    ourNode = new TagNode() {Source = item};
                    lookup.Add(item.ID, ourNode);
                }

                // hook into parent
                if (item.ParentID == item.ID)
                {
                    // is a root node
                    rootNodes.Add(ourNode);
                }
                else
                {
                    // is a child row - so we have a parent
                    TagNode parentNode;
                    if (!lookup.TryGetValue(item.ParentID, out parentNode))
                    {
                        // unknown parent, construct preliminary parent
                        parentNode = new TagNode();
                        lookup.Add(item.ParentID, parentNode);
                    }

                    parentNode.Children.Add(ourNode);
                    ourNode.Parent = parentNode;
                }
            }

            return rootNodes;
        }
    }
}