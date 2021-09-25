using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelLib.model;

namespace SimpleRESTService.Managers
{
	public class Manager : IManager
	{
		private static List<Item> items = new List<Item>()
		{
			new Item(1, "Bread", "Low", 33),
			new Item(2,"Bread","Middle",21),
			new Item(3,"Beer","Low",70.5),
			new Item(4,"Soda","High",21.4),
			new Item(5,"Milk","Low",55.8)
		};
		public IEnumerable<Item> Get()
		{
			return new List<Item>(items);
		}

		public Item Get(int id)
		{
			if (items.Exists(i => i.Id == id))
			{
				return items.Find(i => i.Id == id);
			}
			throw new KeyNotFoundException();
		}

		public IEnumerable<Item> GetFromSubstring(string substring)
		{
			return new List<Item>(items.Where(i => i.Name.Contains(substring)));
		}

		public IEnumerable<Item> GetFromItemQuality(string itemQuality)
		{
			return new List<Item>(items.Where(i => i.ItemQuality.Equals(itemQuality)));
		}

		public bool Create(Item value)
		{
			items.Add(value);
			return true;
		}

		public bool Update(int id, Item value)
		{
			Item item = Get(id);
			if (item != null)
			{
				item.Id = value.Id;
				item.Name = value.Name;
				item.ItemQuality = value.ItemQuality;
				item.AmountQuantity = value.AmountQuantity;

				return true;
			}

			return false;
		}

		public Item Delete(int id)
		{
			Item item = Get(id);
			items.Remove(item);
			return item;
		}
	}
}
