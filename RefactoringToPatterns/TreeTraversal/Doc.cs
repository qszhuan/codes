using System.Collections.Generic;
using System.Text;

namespace refactoring_to_visitor.TreeTraversal
{
    public class Doc
    {
        public string Title { get; set; }

        public string Content
        {
            get
            {
                var stringBuilder = new StringBuilder();
                stringBuilder.AppendLine(Title);
                foreach (var element in Elements)
                {
                    stringBuilder.Append(element.Content);
                }
                return stringBuilder.ToString();
            }
        }

        public List<IElement> Elements = new List<IElement>();
    }
}