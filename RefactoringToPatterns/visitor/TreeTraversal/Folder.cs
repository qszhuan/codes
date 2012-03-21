using System.Collections.Generic;

namespace refactoring_to_visitor.TreeTraversal
{
    public class Folder
    {
        public List<Doc> Docs = new List<Doc>();

        public string FolderName { get; set; }
        public string Category { get; set; }

        public void Accept(TreeVisitor treeVisitor)
        {
            treeVisitor.VisitFolder(this);

            foreach (var doc in Docs)
            {
                doc.Accept(treeVisitor);
            }
        }
    }
}