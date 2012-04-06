using Xunit;

namespace Ipad
{
    public class IpadFacts
    {
        [Fact]
        public void should_get_price_of_black_ipad()
        {
            var ipad = new IPad(new ColorSpec(Color.Black), new VolumeSpec(8), new NetSpec(Net.None));
            Assert.Equal(3688, ipad.Price());
        }

        [Fact]
        public void should_get_price_of_white_ipad()
        {
            var pad = new IPad(new ColorSpec(Color.White), new VolumeSpec(8), new NetSpec(Net.None));
            Assert.Equal(3888, pad.Price());
        }

        [Fact]
        public void should_get_price_of_red_ipad()
        {
            var pad = new IPad(new ColorSpec(Color.Red), new VolumeSpec(8), new NetSpec(Net.None));
            Assert.Equal(4088, pad.Price());
        }

        [Fact]
        public void should_get_price_of_16g_black_ipad()
        {
            var pad = new IPad(new ColorSpec(Color.Black), new VolumeSpec(16), new NetSpec(Net.None));
            Assert.Equal(4488, pad.Price());
        }

        [Fact]
        public void should_get_price_of_32g_black_ipad()
        {
            var pad = new IPad(new ColorSpec(Color.Black), new VolumeSpec(32), new NetSpec(Net.None));
            Assert.Equal(5288, pad.Price());
        }

        [Fact]
        public void should_get_price_of_64g_black_ipad()
        {
            var pad = new IPad(new ColorSpec(Color.Black), new VolumeSpec(64), new NetSpec(Net.None));
            Assert.Equal(6188, pad.Price());
        }
        [Fact]
        public void should_get_price_of_128g_black_ipad()
        {
            var pad = new IPad(new ColorSpec(Color.Black), new VolumeSpec(128), new NetSpec(Net.None));
            Assert.Equal(6888, pad.Price());
        }

        [Fact]
        public void should_get_price_of_wifi_black_ipad()
        {
            var ipad = new IPad(new ColorSpec(Color.Black), new VolumeSpec(8), new NetSpec(Net.Wifi));
            Assert.Equal(4488, ipad.Price());
        }
        [Fact]
        public void should_get_price_of_3g_black_ipad()
        {
            var ipad = new IPad(new ColorSpec(Color.Black), new VolumeSpec(8), new NetSpec(Net.ThreeG));
            Assert.Equal(5288, ipad.Price());
        }
        [Fact]
        public void should_get_price_of_wifi_wifi_3g_ipad()
        {
            var ipad = new IPad(new ColorSpec(Color.Black), new VolumeSpec(8), new NetSpec(Net.WifiThreeG));
            Assert.Equal(6888, ipad.Price());
        }

    }
    public enum Net
    {
        None,
        Wifi ,
        ThreeG ,
        WifiThreeG
    }
    public enum Color
    {
        Black,
        Red,
        White
    }
}
