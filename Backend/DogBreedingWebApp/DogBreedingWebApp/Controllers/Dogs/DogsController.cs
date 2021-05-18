using System.Collections.Generic;

using DogBreedingWebApp.DataModels;
using DogBreedingWebApp.Interfaces.Services;

using Microsoft.AspNetCore.Mvc;

namespace DogBreedingWebApp.Controllers.Dogs
{
	[Route("api/dogs")]
	[ApiController]
	public class DogsController : ControllerBase
	{
		private readonly IDogService _dogService;

		public DogsController(IDogService dogService)
		{
			_dogService = dogService;
		}

		[HttpGet]
		public IActionResult GetAllBreedsAndPossibleSubBreeds()
		{
			var result = _dogService.GetAllBreed();
			return Ok(result);
		}

		[HttpGet("{breed}/subbreed")]
		public IActionResult GetAllBreedsAndPossibleSubBreedsImageURL(string breed, string subbreed = null)
		{
			var result = _dogService.GellAllBreedImageURLs(breed, subbreed);

			return Ok(result);
		}
	}
}
