using System;
using GildedRose.Console;
using GildedRose.Console.Updaters;
using Xunit;

namespace GildedRose.Tests
{
    public class LegendaryItemUpdaterTests
    {
        public LegendaryItemUpdaterTests()
        {

        }

        [Theory]
        [InlineData(50,80)]
        public void LegendaryItemNotUpdated(int sellIn, int quality)
        {
            Item item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = sellIn, Quality = quality };

            IItemUpdater sut = new LegendaryItemUpdater();

            sut.UpdateItem(item);

            Assert.Equal(item.Quality, quality);
            Assert.Equal(item.SellIn, sellIn);
        }
    }
}