using System;
using Xunit;

namespace Ipad
{
    public class IpadFacts
    {
        [Fact]
        public void should_get_price_of_black_ipad()
        {
            var ipad = new IPad(Color.Black, 8);
            Assert.Equal(3688, ipad.Price());
        }

        [Fact]
        public void should_get_price_of_white_ipad()
        {
            var pad = new IPad(Color.White, 8);
            Assert.Equal(3888, pad.Price());
        }

        [Fact]
        public void should_get_price_of_red_ipad()
        {
            var pad = new IPad(Color.Red, 8);
            Assert.Equal(4088, pad.Price());
        }

        [Fact]
        public void should_get_price_of_16g_black_ipad()
        {
            var pad = new IPad(Color.Black, 16);
            Assert.Equal(4488, pad.Price());
        }

        [Fact]
        public void should_get_price_of_32g_black_ipad()
        {
            var pad = new IPad(Color.Black, 32);
            Assert.Equal(5288, pad.Price());
        }

        [Fact]
        public void should_get_price_of_64g_black_ipad()
        {
            var pad = new IPad(Color.Black, 64);
            Assert.Equal(6188, pad.Price());
        }
        [Fact]
        public void should_get_price_of_128g_black_ipad()
        {
            var pad = new IPad(Color.Black, 128);
            Assert.Equal(6888, pad.Price());
        }

        [Fact]
        public void should_get_price_of_wifi_black_ipad()
        {
            var ipad = new IPad(Color.Black, 8, Net.Wifi);
            Assert.Equal(4488, ipad.Price());
        }
        [Fact]
        public void should_get_price_of_3g_black_ipad()
        {
            var ipad = new IPad(Color.Black, 8, Net.ThreeG);
            Assert.Equal(5288, ipad.Price());
        }
        [Fact]
        public void should_get_price_of_wifi_wifi_3g_ipad()
        {
            var ipad = new IPad(Color.Black, 8, Net.WifiThreeG);
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
