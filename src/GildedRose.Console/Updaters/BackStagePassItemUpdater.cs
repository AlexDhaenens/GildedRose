using System;
namespace GildedRose.Console.Updaters
{
    public class BackStagePassItemUpdater : IItemUpdater
    {
        public BackStagePassItemUpdater()
        {
        }

        public void UpdateItem(Item item)
        {
            item.SellIn -= 1;

            if(item.SellIn >= 0)
            {
                int qualityIncrease = item.SellIn <= 5 ? 3 : item.SellIn <= 10 ? 2 : 1;

                if(item.Quality + qualityIncrease <= 50)
                {
                    item.Quality = qualityIncrease;
                }
                else
                {
                    item.Quality = 50;
                }
            }
            else
            {
                item.Quality = 0;
            }
        }
    }
}
