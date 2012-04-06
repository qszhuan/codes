namespace Ipad
{
    public class NetSpec : ISpec
    {
        private readonly Net _net;

        public NetSpec(Net net)
        {
            _net = net;
        }

        public int GetSpecPrice()
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
    }
}