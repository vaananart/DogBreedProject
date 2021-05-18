using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DogBreedingWebApp.Interfaces.Services;

using Microsoft.AspNetCore.Mvc;

namespace DogBreedingWebApp.Controllers.Dogs
{
	[ApiController]
	[Route("[controller]")]
	public class SubBreedController : ControllerBase
	{
		private readonly IDogService _dogService;

		public SubBreedController(IDogService dogService)
		{
			_dogService = dogService;
		}

		[HttpGet]
		public IActionResult Get(string breedName = null)
		{
			return _dogService.GetAllSubBreed(breedName);
		}

		public IActionResult GetAllImageURLs(string breedName)
		{
			return _dogService.GellAllSubBreedImageURLs(breedName);
		}
	}
}
