﻿using System.Collections.Generic;
using System.Threading.Tasks;

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
		public async Task<IActionResult> GetAllBreedsAndPossibleSubBreeds()
		{
			var result = await _dogService.GetAllBreed();
			return Ok(result);
		}

		[HttpGet("{breed}/subbreed")]
		public async Task<IActionResult> GetAllBreedsAndPossibleSubBreedsImageURL(string breed)
		{
			var result = await _dogService.GellAllBreedImageURLs(breed);

			return Ok(result);
		}

		[HttpGet("{breed}/{subBreed}/subbreed")]
		public async Task<IActionResult> GetAllBreedsAndPossibleSubBreedsImageURL(string breed, string subBreed)
		{
			var result = await _dogService.GellAllBreedImageURLs(breed, subBreed);

			return Ok(result);
		}
	}
}
