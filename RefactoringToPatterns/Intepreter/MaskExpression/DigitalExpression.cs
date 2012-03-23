namespace MaskExpression
{
    public class DigitalExpression :IExpression
    {
        private readonly char _digit;

        public DigitalExpression(char digit)
        {
            _digit = digit;
        }

        public bool Interpret(Context context)
        {
            var tryInterpret = _digit == ExpressionBuilder.ALPHANUM;

            if ((tryInterpret  || context.MoveNext()) && char.IsDigit(context.Current()))
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