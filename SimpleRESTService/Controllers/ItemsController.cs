using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLib.model;
using SimpleRESTService.Managers;

namespace SimpleRESTService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ItemsController : ControllerBase
	{
		private readonly IManager mgr = new Manager();
			// GET: api/<ItemsController>
			[HttpGet]
			public IEnumerable<Item> Get()
			{
				return mgr.Get();
			}

			// GET api/<ItemsController>/5
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

			// GET: api/<ItemsController>/{substring}
			[HttpGet]
			[Route("Name/{substring}")]
			public IEnumerable<Item> GetFromSubstring(string substring)
			{
				return mgr.GetFromSubstring(substring);
			}

			// GET: api/<ItemsController>/{itemQuality}
			[HttpGet]
			[Route("ItemQuality/{itemQuality}")]
			public IEnumerable<Item> GetFromItemQuality(string itemQuality)
			{
				return mgr.GetFromItemQuality(itemQuality);
			}

			// POST api/<ItemsController>
			[HttpPost]
			public bool Post([FromBody] Item value)
			{
				return mgr.Create(value);
			}

			// PUT api/<ItemsController>/5
			[HttpPut]
			[Route("{id}")]
			public bool Put(int id, [FromBody] Item value)
			{
				return mgr.Update(id, value);
			}

			// DELETE api/<ItemsController>/5
			[HttpDelete]
			[Route("{id}")]
			public Item Delete(int id)
			{
				return mgr.Delete(id);
			}
		}
}
