using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib.model
{
	public class Item
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string ItemQuality { get; set; }
		public double AmountQuantity { get; set; }

		public Item() { }

		public Item(int id, string name, string itemQuality, double quantity)
		{
			Id = id;
			Name = name;
			ItemQuality = itemQuality;
			AmountQuantity = quantity;
		}

		public override string ToString()
		{
			return $"{Id}, {Name}, {ItemQuality}, {AmountQuantity}";
		}
	}
}
