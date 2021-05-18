using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace DogBreedingWebApp.Controllers.Dogs
{
	[ApiController]
	[Route("[controller]")]
	public class BreedController : ControllerBase
	{
		[HttpGet]
		public IActionResult Get(string breedName)
		{
			return null;
		}
	}
}
