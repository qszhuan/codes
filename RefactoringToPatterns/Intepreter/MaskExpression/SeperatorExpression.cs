namespace MaskExpression
{
    public class SeperatorExpression:IExpression
    {
        private readonly char _seperator;

        public SeperatorExpression(char seperator)
        {
            _seperator = seperator;
        }

        public bool Interpret(Context context)
        {
            if (context.MoveNext() && _seperator.Equals(context.Current()))
                return true;
            context.Failed();
            return false;
        }
    }
}