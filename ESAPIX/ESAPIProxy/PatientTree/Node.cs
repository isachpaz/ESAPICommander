using System.Collections.Generic;

namespace ESAPIProxy
{
    public class Node : IVisitable
    {
        private List<Node> _children = new List<Node>();
        public Node Parent { get; set; }
        public TagInfo TagInfo { get; set; }

        public IEnumerable<Node> GetChildren() => _children;
        public override string ToString()
        {
            return $"{nameof(TagInfo)}: {TagInfo}";
        }

        public void Accept(ITreeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void AddChildren(Node node)
        {
            _children.Add(node);
        }

        public static List<Node> BuildTreeAndGetRoots(List<TagInfo> actualObjects)
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
                    ourNode.TagInfo = item;
                }
                else
                {
                    ourNode = new Node() {TagInfo = item};
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

                    parentNode._children.Add(ourNode);
                    ourNode.Parent = parentNode;
                }
            }

            return rootNodes;
        }
    }
}