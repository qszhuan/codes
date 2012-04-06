namespace Ipad
{
    public class VolumeSpec :ISpec
    {
        private readonly int _volume;

        public VolumeSpec(int volume)
        {
            _volume = volume;
        }

        public int GetSpecPrice()
        {
            var volumePrice = 0;
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
    }
}