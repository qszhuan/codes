using System;

namespace Ipad
{
    public interface ISpec
    {
        int GetSpecPrice();
    }

    public class  ColorSpec : ISpec
    {
        private int _colorPrice;
        private readonly Color _color;

        public ColorSpec(Color color)
        {
            _color = color;
        }

        public virtual int GetSpecPrice()
        {
            switch (_color)
            {
                case Color.Red:
                    RedColorPrice();
                    break;
                case Color.White:
                    WhiteColorPrice();
                    break;
                default:
                    break;
            }
            return _colorPrice;
        }

        private int WhiteColorPrice()
        {
            return _colorPrice=200;
        }

        private int RedColorPrice()
        {
            return _colorPrice=400;
        }
    }
}