using System.Collections.Generic;
using System.Text;

namespace refactoring_to_visitor.TreeTraversal
{
    public class Folder
    {
        public List<Doc> Docs = new List<Doc>();

        public string Content
        {
            get
            {
                var stringBuilder = new StringBuilder();
                stringBuilder.AppendLine(FolderName);
                stringBuilder.AppendLine(Category);

                foreach (var doc in Docs)
                {
                    stringBuilder.Append(doc.Content);
                }
                return stringBuilder.ToString();
            }
        }

        public string FolderName { get; set; }
        public string Category { get; set; }

        public void Accept(TreeVisitor treeVisitor)
        {
            treeVisitor.VisitFolder(this);
        }
    }
}