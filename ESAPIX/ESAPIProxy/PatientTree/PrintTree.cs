using System.Net.Mime;
using System.Text;

namespace ESAPIProxy
{
    public class PrintTree : ITreeVisitor
    {
        private StringBuilder TextBuilder { get; } = new StringBuilder();
        private int Indent { get; set; } = 0;

        public void Visit(Node node)
        {
            TextBuilder.AppendLine($"{GetTabs()}{node.TagInfo.Description}");
            foreach (var child in node.GetChildren())
            {
                Indent++;
                child.Accept(this);
                Indent--;
            }
        }

        private string GetTabs()
        {
            string tab = "";
            for (int i = 0; i < Indent; i++)
            {
                tab += "\t";
            }

            return tab;
        }

        public string GetOutput()
        {
            return TextBuilder.ToString();
        }
    }
}