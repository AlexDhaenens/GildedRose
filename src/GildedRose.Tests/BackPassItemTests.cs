using System;
using GildedRose.Console;
using GildedRose.Console.Updaters;
using Xunit;

namespace GildedRose.Tests
{
    public class BackPassItemTests
    {
        public BackPassItemTests()
        {
           
        }

        [Theory]
        [InlineData(20, 10,19,9)]
        [InlineData(20, 0, 19, 0)]
        [InlineData(7, 10, 6, 8)]
        [InlineData(7, 0, 6, 0)]
        [InlineData(3, 10, 2, 7)]
        [InlineData(3, 0, 2, 0)]
        [InlineData(0, 10, -1, 0)]
        [InlineData(0, 0, -1, 0)]
        public void PackPassItemsUpdated(int sellIn, int quality, int expextedSellIn, int expectedQuality)
        {
            Item item = new Item { Name = "A conjured item", SellIn = sellIn, Quality = quality };

            IItemUpdater sut = new ConjuredItemUpdater();

            sut.UpdateItem(item);

            Assert.Equal(item.Quality, expectedQuality);
            Assert.Equal(item.SellIn, expextedSellIn);
        }
    }
}

