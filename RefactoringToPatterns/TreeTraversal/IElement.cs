namespace refactoring_to_visitor.TreeTraversal
{
    public interface IElement
    {
        string Name { get; set; }
        string Text { get; set; }
        int Size { get; set; }
        string Content { get; }
        void Accept(TreeVisitor treeVisitor);
    }
}