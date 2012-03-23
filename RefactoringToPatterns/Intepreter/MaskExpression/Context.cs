using System;
using System.Text;

namespace MaskExpression
{
    public class Context
    {
        private readonly string _input;
        private readonly CharEnumerator Iterator;
        private StringBuilder resultBuilder = new StringBuilder();

        public Context(string input)
        {
            _input = input;
            Iterator = input.GetEnumerator();
        }

        public string Result
        {
            get { return resultBuilder.ToString(); }
        }

        public bool MoveNext()
        {
            return Iterator.MoveNext();
        }

        public char Current()
        {
            return Iterator.Current;
        }

        public void Failed()
        {
            resultBuilder.Clear();
            resultBuilder.Append(_input);
        }

        public void Feed()
        {
            resultBuilder.Append(Current());
        }
    }
}