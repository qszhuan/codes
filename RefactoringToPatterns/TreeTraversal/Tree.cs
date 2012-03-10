using System.Collections.Generic;
using System.Text;

namespace refactoring_to_visitor.TreeTraversal
{
    public class Tree
    {
        public string Name { get; set; }
        public List<Folder> Folders = new List<Folder>();
        public List<Doc> Docs = new List<Doc>();

        public string ListContent()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(Name);
            foreach (var folder in Folders)
            {
                stringBuilder.Append(folder.Content);
            }
            foreach (var doc in Docs)
            {
                stringBuilder.Append(doc.Content);
            }
            return stringBuilder.ToString();
        }
    }
}