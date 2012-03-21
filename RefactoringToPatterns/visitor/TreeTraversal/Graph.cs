using System;
using System.Text;

namespace refactoring_to_visitor.TreeTraversal
{
    public class Graph : IElement
    {
        public string Name { get; set; }

        public string Text { get; set; }

        public int Size { get; set; }

        public string Content
        {
            get { return string.Format("<Graph>: {0}, {1}, {2}{3}", Name, Text, Size, Environment.NewLine); }
        }

        public void Accept(TreeVisitor treeVisitor)
        {
            treeVisitor.VisitElement(this);
        }
    }
}