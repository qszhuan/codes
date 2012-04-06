namespace Ipad
{
    public class IPad
    {
        private const int BasePrice = 3688;
        private readonly Color _color;
        private readonly int _volume;
        private readonly Net _net;

        public IPad(Color color, int volume, Net net = Net.None)
        {
            _color = color;
            _volume = volume;
            _net = net;
        }

        public int Price()
        {
            var price = BasePrice;
            price += GetColorPrice();
            price += GetVolumePrice();
            price += GetNetPrice();
            return price;
        }

        private int GetNetPrice()
        {
            int netPrice = 0;
            switch (_net)
            {
                case Net.Wifi:
                    netPrice = 800;
                    break;
                case Net.ThreeG:
                    netPrice = 1600;
                    break;
                case Net.WifiThreeG:
                    netPrice = 3200;
                    break;
                default:
                    break;

            }
            return netPrice;
        }

        private int GetVolumePrice()
        {
            int volumePrice = 0;
            switch (_volume)
            {
                case 16:
                    volumePrice = 800;
                    break;
                case 32:
                    volumePrice = 1600;
                    break;
                case 64:
                    volumePrice = 2500;
                    break;
                case 128:
                    volumePrice = 3200;
                    break;
                default:
                    break;
            }
            return volumePrice;
        }

        private int GetColorPrice()
        {
            int colorPrice = 0;
            switch (_color)
            {
                case Color.Red:
                    colorPrice=400;break;
                case Color.White:
                    colorPrice=200;break;
                default:
                    break;
            }
            return colorPrice;
        }
    }
}