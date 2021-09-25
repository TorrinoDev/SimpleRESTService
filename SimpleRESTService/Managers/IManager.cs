using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using ModelLib;

namespace SimpleRESTService.Managers
{
	interface IManager
	{
		IEnumerable<FootballPlayer> Get();
		FootballPlayer Get(int id);
		bool Create(FootballPlayer value);
		bool Update(int id, FootballPlayer value);
		FootballPlayer Delete(int id);
	}
}
