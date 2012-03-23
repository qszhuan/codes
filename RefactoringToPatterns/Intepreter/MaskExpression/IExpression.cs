namespace MaskExpression
{
    public interface IExpression
    {
        bool Interpret(Context context);
    }
}