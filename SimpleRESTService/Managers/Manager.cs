using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelLib;

namespace SimpleRESTService.Managers
{
	public class Manager : IManager
	{
		private static List<FootballPlayer> players = new List<FootballPlayer>()
		{
			new FootballPlayer(1, "Brandon", 200000, 3),
			new FootballPlayer(2, "Wayne", 120000, 12),
			new FootballPlayer(3, "Salem", 150000, 19),
			new FootballPlayer(4, "Jason", 220000, 34),
			new FootballPlayer(4, "Lars", 300000, 4),
		};
		public IEnumerable<FootballPlayer> Get()
		{
			return new List<FootballPlayer>(players);
		}

		public FootballPlayer Get(int id)
		{
			if (players.Exists(i => i.Id == id))
			{
				return players.Find(i => i.Id == id);
			}
			throw new KeyNotFoundException();
		}

		public bool Create(FootballPlayer value)
		{
			players.Add(value);
			return true;
		}

		public bool Update(int id, FootballPlayer value)
		{
			FootballPlayer player = Get(id);
			if (player != null)
			{
				player.Id = value.Id;
				player.Name = value.Name;
				player.Price = value.Price;
				player.ShirtNumber = value.ShirtNumber;

				return true;
			}

			return false;
		}

		public FootballPlayer Delete(int id)
		{
			FootballPlayer player = Get(id);
			players.Remove(player);
			return player;
		}
	}
}
