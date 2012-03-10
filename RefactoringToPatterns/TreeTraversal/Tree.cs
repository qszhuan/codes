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
                folder.Accept(treeVisitor);
            }
            foreach (var doc in Docs)
            {
                doc.Accept(treeVisitor);
            }
        }
    }
}