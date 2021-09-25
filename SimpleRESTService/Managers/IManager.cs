using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using ModelLib.model;

namespace SimpleRESTService.Managers
{
	interface IManager
	{
		IEnumerable<Item> Get();
		Item Get(int id);
		IEnumerable<Item> GetFromSubstring(string substring);
		IEnumerable<Item> GetFromItemQuality(string itemQuality);
		bool Create(Item value);
		bool Update(int id, Item value);
		Item Delete(int id);
	}
}
