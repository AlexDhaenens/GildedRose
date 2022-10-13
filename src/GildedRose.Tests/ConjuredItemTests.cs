using System;
using GildedRose.Console;
using GildedRose.Console.Updaters;
using Xunit;

namespace GildedRose.Tests
{
    public class ConjuredItemTests
    {
        public ConjuredItemTests()
        {
           
        }

        [Theory]
        [InlineData(20, 10,19,8)]
        [InlineData(20, 0, 19, 0)]
        [InlineData(0, 10, -1, 6)]
        [InlineData(0, 0, -1, 0)]
        public void ConjuredUpdated(int sellIn, int quality, int expextedSellIn, int expectedQuality)
        {
            Item item = new Item { Name = "A conjured item", SellIn = sellIn, Quality = quality };

            IItemUpdater sut = new ConjuredItemUpdater();

            sut.UpdateItem(item);

            Assert.Equal(item.Quality, expectedQuality);
            Assert.Equal(item.SellIn, expextedSellIn);
        }
    }
}

