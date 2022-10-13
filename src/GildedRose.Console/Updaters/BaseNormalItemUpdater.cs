using System;
namespace GildedRose.Console.Updaters
{
    public class BaseNormalItemUpdater: IItemUpdater
    {
        private int speed;

        public BaseNormalItemUpdater(int speed)
        {
            this.speed = speed;
        }

        public void UpdateItem(Item item)
        {
            item.SellIn -= 1;

            int qualityDecrease = item.SellIn < 0 ? 2*speed : speed;

            if(item.Quality >= qualityDecrease)
            {
                item.Quality -= qualityDecrease;
            }
            else
            {
                item.Quality = 0;
            }
        }
    }
}
