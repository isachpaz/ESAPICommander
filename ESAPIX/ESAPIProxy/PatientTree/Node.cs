using System.Collections.Generic;

namespace ESAPIProxy
{
    public class Node
    {
        public List<Node> Children = new List<Node>();
        public Node Parent { get; set; }
        public Tag Source { get; set; }

        public override string ToString()
        {
            return $"{nameof(Source)}: {Source}";
        }

        public static List<Node> BuildTreeAndGetRoots(List<Tag> actualObjects)
        {
            var lookup = new Dictionary<int, Node>();
            var rootNodes = new List<Node>();

            foreach (var item in actualObjects)
            {
                // add us to lookup
                Node ourNode;
                if (lookup.TryGetValue(item.ID, out ourNode))
                {
                    // was already found as a parent - register the actual object
                    ourNode.Source = item;
                }
                else
                {
                    ourNode = new Node() {Source = item};
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
                    Node parentNode;
                    if (!lookup.TryGetValue(item.ParentID, out parentNode))
                    {
                        // unknown parent, construct preliminary parent
                        parentNode = new Node();
                        lookup.Add(item.ParentID, parentNode);
                    }

                    parentNode.Children.Add(ourNode);
                    ourNode.Parent = parentNode;
                }
            }

            return rootNodes;
        }

        public void AddChildren(Node node)
        {
            Children.Add(node);
        }
    }
}