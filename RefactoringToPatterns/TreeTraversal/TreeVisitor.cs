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

        public void VisitDoc(Doc doc)
        {
            _stringBuilder.Append(doc.Content);
        }

        public void VisitFolder(Folder folder)
        {
            _stringBuilder.Append(folder.Content);
        }

        public string Result()
        {
            return _stringBuilder.ToString();
        }
    }
}