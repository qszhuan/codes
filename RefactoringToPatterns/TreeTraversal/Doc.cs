using System.Collections.Generic;

namespace refactoring_to_visitor.TreeTraversal
{
    public class Doc
    {
        public string Title { get; set; }

        public List<IElement> Elements = new List<IElement>();

        public void Accept(TreeVisitor treeVisitor)
        {
            treeVisitor.VisitDoc(this);
            foreach (var element in Elements)
            {
                element.Accept(treeVisitor);
            }
        }
    }
}