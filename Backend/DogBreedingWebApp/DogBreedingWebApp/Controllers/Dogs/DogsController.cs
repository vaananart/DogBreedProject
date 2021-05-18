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
		public IEnumerable<DogModel> GetAllBreedsAndPossibleSubBreeds()
		{
			return _dogService.GetAllBreed();
		}

		[HttpGet("{breed}/subbreed")]
		public IEnumerable<string> GetAllBreedsAndPossibleSubBreedsImageURL(string breed, string subbreed = null)
		{
			return _dogService.GellAllBreedImageURLs(breed, subbreed);
		}
	}
}
