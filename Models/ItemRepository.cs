using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Swaipy.Models
{
    public class ItemRepository : IItemRepository
    {
        private static ConcurrentDictionary<string, Item> items =
            new ConcurrentDictionary<string, Item>();

        public ItemRepository()
        {
            Add(new Item { Id = Guid.NewGuid().ToString(), Text = "Starbucks", Description = "4 points." });
            Add(new Item { Id = Guid.NewGuid().ToString(), Text = "Thai Jasmin", Description = "2 points." });
            Add(new Item { Id = Guid.NewGuid().ToString(), Text = "Burger King", Description = "1 point." });
        }

        public Item Get(string id)
        {
            return items[id];
        }

        public IEnumerable<Item> GetAll()
        {
            return items.Values;
        }

        public void Add(Item item)
        {
            item.Id = Guid.NewGuid().ToString();
            items[item.Id] = item;
        }

        public Item Find(string id)
        {
            Item item;
            items.TryGetValue(id, out item);

            return item;
        }

        public Item Remove(string id)
        {
            Item item;
            items.TryRemove(id, out item);

            return item;
        }

        public void Update(Item item)
        {
            items[item.Id] = item;
        }
    }
}
