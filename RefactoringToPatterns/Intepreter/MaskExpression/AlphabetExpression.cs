namespace MaskExpression
{
    public class AlphabetExpression : IExpression
    {
        private readonly char _mask;

        public AlphabetExpression(char mask)
        {
            _mask = mask;
        }

        public bool Interpret(Context context)
        {
            var tryInterpret = _mask == ExpressionBuilder.ALPHANUM;

            var notFinished = (tryInterpret || context.MoveNext());

            if (notFinished && char.IsLetter(context.Current()))
            {
                context.Feed();
                return true;
            }
            if (tryInterpret) return false;
            context.Failed();
            return false;
        }
    }
}