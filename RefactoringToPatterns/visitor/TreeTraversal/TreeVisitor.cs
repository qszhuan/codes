using System.Text;

namespace refactoring_to_visitor.TreeTraversal
{
    public class TreeVisitor
    {
        public readonly StringBuilder _stringBuilder = new StringBuilder();

        public void Visit(Tree tree)
        {
            _stringBuilder.AppendLine(tree.Name);
            return;
        }

        public string Result()
        {
            return _stringBuilder.ToString();
        }

        public void VisitFolder(Folder folder)
        {
            _stringBuilder.AppendLine(folder.FolderName);
            _stringBuilder.AppendLine(folder.Category);
        }

        public void VisitDoc(Doc doc)
        {
            _stringBuilder.AppendLine(doc.Title);
        }

        public void VisitElement(IElement graph)
        {
            _stringBuilder.Append(graph.Content);
        }
    }
}