using System;
using GildedRose.Console;
using GildedRose.Console.Updaters;
using Xunit;

namespace GildedRose.Tests
{
    public class NormalItemTests
    {
        public NormalItemTests()
        {
           
        }

        [Theory]
        [InlineData(20, 10,19,9)]
        [InlineData(20, 0, 19, 0)]
        [InlineData(0, 10, -1, 8)]
        [InlineData(0, 0, -1, 0)]
        public void NormalItemUpdated(int sellIn, int quality, int expextedSellIn, int expectedQuality)
        {
            Item item = new Item { Name = "A normal item", SellIn = sellIn, Quality = quality };

            IItemUpdater sut = new NormalItemUpdater();

            sut.UpdateItem(item);

            Assert.Equal(item.Quality, expectedQuality);
            Assert.Equal(item.SellIn, expextedSellIn);
        }
    }
}

