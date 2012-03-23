using System.Linq;

namespace MaskExpression
{
    public class ExpressionBuilder
    {
        private const char DIGIT = '9';
        private const char SEPERATOR = '-';
        private const char ALPHABET = 'a';
        public const char ALPHANUM = '*';
        private readonly string _mask;

        public ExpressionBuilder(string mask)
        {
            _mask = mask;
        }

        public IExpression Build()
        {
            IExpression expression = null;
            foreach (var mask in _mask.Reverse())
            {
                IExpression temp = null;
                switch (mask)
                {
                    case DIGIT:
                        temp = new DigitalExpression(mask);
                        break;
                    case SEPERATOR:
                        temp = new SeperatorExpression(mask);
                        break;
                    case ALPHABET:
                        temp = new AlphabetExpression(mask);
                        break;
                    case ALPHANUM:
                        temp = new OrExpression(new DigitalExpression(mask), new AlphabetExpression(mask));
                        break;
                }

                expression = (expression == null ? temp : new SequenceExpression(temp, expression));
            }
            return expression;
        }
    }

    public class OrExpression : IExpression
    {
        private readonly IExpression _one;
        private readonly IExpression _another;

        public OrExpression(IExpression one, IExpression another)
        {
            _one = one;
            _another = another;
        }

        public bool Interpret(Context context)
        {
            if (context.MoveNext())
            {
                return _one.Interpret(context) || _another.Interpret(context);
            }
            context.Failed();
            return false;
        }
    }
}