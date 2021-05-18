using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace DogBreedingWebApp.Controllers.Dogs
{
	[ApiController]
	[Route("[controller]")]
	public class SubBreedController : ControllerBase
	{
		[HttpGet]
		public IActionResult Get()
		{
			return null;
		}
	}
}
