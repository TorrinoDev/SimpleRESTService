using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLib;
using SimpleRESTService.Managers;
using System.Collections.Generic;

namespace SimpleRESTService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PlayersController : ControllerBase
	{
		private readonly IManager mgr = new Manager();
		// GET: api/<PlayersController>
		[HttpGet]
		public IEnumerable<FootballPlayer> Get()
		{
			return mgr.Get();
		}

		// GET api/<PlayersController>/5
		[HttpGet]
		[Route("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult Get(int id)
		{
			try
			{
				return Ok(mgr.Get(id));
			}
			catch (KeyNotFoundException knfe)
			{
				return NotFound(knfe.Message);
			}

		}

		// POST api/<PlayersController>
		[HttpPost]
		public bool Post([FromBody] FootballPlayer value)
		{
			return mgr.Create(value);
		}

		// PUT api/<PlayersController>/5
		[HttpPut]
		[Route("{id}")]
		public bool Put(int id, [FromBody] FootballPlayer value)
		{
			return mgr.Update(id, value);
		}

		// DELETE api/<PlayersController>/5
		[HttpDelete]
		[Route("{id}")]
		public FootballPlayer Delete(int id)
		{
			return mgr.Delete(id);
		}
	}
}
