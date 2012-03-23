namespace MaskExpression
{
    public class SequenceExpression : IExpression
    {
        private readonly IExpression _first;
        private readonly IExpression _second;

        public SequenceExpression(IExpression first, IExpression second)
        {
            _first = first;
            _second = second;
        }

        public bool Interpret(Context context)
        {
            return _first.Interpret(context) && _second.Interpret(context);
        }
    }
}