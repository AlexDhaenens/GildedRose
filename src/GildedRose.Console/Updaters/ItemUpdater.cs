using System;
using System.Collections.Generic;

namespace GildedRose.Console.Updaters
{
    enum ItemType  {Normal, Legendary, BackStagePass, Conjured};

    public class ItemUpdater: IItemUpdater
    {
        private Dictionary<ItemType, IItemUpdater> typeSpecificUpdater;


        public ItemUpdater()
        {
            typeSpecificUpdater = new Dictionary<ItemType, IItemUpdater>() {
                { ItemType.Normal, new NormalItemUpdater() },
                { ItemType.Legendary, new LegendaryItemUpdater() },
                { ItemType.BackStagePass, new BackStagePassItemUpdater() },
                { ItemType.Conjured, new ConjuredItemUpdater() } };
        }


        private ItemType GetItemType(Item item)
        {
            if(item.Name == "Aged Brie" && item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                return ItemType.BackStagePass;
            }
            if(item.Name == "Sulfuras, Hand of Ragnaros")
            {
                return ItemType.Legendary;
            }
            return ItemType.Normal;
        }

        public void UpdateItem(Item item)
        {
            ItemType type = GetItemType(item);

            IItemUpdater updater = typeSpecificUpdater[type];

            if (updater != null)
            {
                updater.UpdateItem(item);
            }
        }

    }
}
