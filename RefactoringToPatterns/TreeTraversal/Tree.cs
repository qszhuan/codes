using System.Collections.Generic;

namespace refactoring_to_visitor.TreeTraversal
{
    public class Tree
    {
        public string Name { get; set; }
        public List<Folder> Folders = new List<Folder>();
        public List<Doc> Docs = new List<Doc>();

        public string ListContent(TreeVisitor treeVisitor)
        {
            Accept(treeVisitor);
            return treeVisitor.Result();
        }

        private void Accept(TreeVisitor treeVisitor)
        {
            treeVisitor.Visit(this);
            foreach (var folder in Folders)
            {
                Accept(folder, treeVisitor);
            }
            foreach (var doc in Docs)
            {
                Accept(doc, treeVisitor);
            }
        }

        private void Accept(Doc doc, TreeVisitor treeVisitor)
        {
            treeVisitor.VisitDoc(doc);
        }

        private void Accept(Folder folder, TreeVisitor treeVisitor)
        {
            treeVisitor.VisitFolder(folder);
        }
    }
}