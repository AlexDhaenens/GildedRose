using System;
using GildedRose.Console;
using GildedRose.Console.Updaters;
using Xunit;

namespace GildedRose.Tests
{
    public class UpdateItemTests
    {
       
        public UpdateItemTests()
        {
        }


        [Theory]
        [InlineData("+5 Dexterity Vest",20, 10, 19, 9)]
        [InlineData("+5 Dexterity Vest", 0, 10, -1, 8)]
        [InlineData("+5 Dexterity Vest", 20, 0, 19, 0)]
        [InlineData("Sulfuras, Hand of Ragnaros",20, 80, 19, 80)]
        [InlineData("Sulfuras, Hand of Ragnaros", 20, 0, 19, 0)]
        [InlineData("Sulfuras, Hand of Ragnaros", 0, 80, -1, 80)]
        [InlineData("Conjured Mana Cake", 20, 10, 19, 8)]
        [InlineData("Conjured Mana Cake", 0, 10, -1, 6)]
        [InlineData("Conjured Mana Cake", 20, 0, 19, 0)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert",20, 10, 19, 9)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 8, 10, 7, 8)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 3, 10, 2, 7)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 0, 10, -1, 0)]
        public void temTests(string name, int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            Item item = new Item { Name = name, SellIn = sellIn, Quality = quality };

            IItemUpdater sut = new ItemUpdater();

            sut.UpdateItem(item);

            Assert.Equal(item.Quality, expectedQuality);
            Assert.Equal(item.SellIn, expectedSellIn);
        }
    }
}

