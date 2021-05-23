using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DogBreedingWebApp.Interfaces.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DogBreedingWebApp.Controllers.Dogs
{
	[Route("api/dogs")]
	[ApiController]
	public class DogsController : ControllerBase
	{
		private readonly IDogService _dogService;
		private readonly ILogger _logger;

		public DogsController(ILogger<DogsController> logger, IDogService dogService)
		{
			_dogService = dogService;
			_logger = logger;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllBreedsAndPossibleSubBreeds()
		{
			
			_logger.LogInformation($"DogController:GetAllBreedsAndPossibleSubBreeds: Request for all breed response");
			IEnumerable<object> result = null;
			try
			{
				result = (await _dogService.GetAllBreed()).Select(x =>
				{
					return new
					{
						breed = x.Breed,
						subbreed = x.SubBreed
					};
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}

			return Ok(result);
		}

		[HttpGet("{breed}/subbreed")]
		public async Task<IActionResult> GetAllBreedsImageURL(string breed)
		{
			_logger.LogInformation($"DogController:GetAllBreedsImageURL: Request for {breed} breed images.");
			IEnumerable<object> result = null;
			try
			{ 
				result = await _dogService.GellAllBreedImageURLs(breed);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}

			return Ok(result);
		}

		[HttpGet("{breed}/{subBreed}/subbreed")]
		public async Task<IActionResult> GetAllBreedsAndPossibleSubBreedsImageURL(string breed, string subBreed)
		{
			_logger.LogInformation($"DogController:GetAllBreedsAndPossibleSubBreedsImageURL: Request for breed:{breed}-subBreed:{subBreed} images");
			IEnumerable<object> result = null;
			try
			{
				result = await _dogService.GellAllBreedImageURLs(breed, subBreed);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}

			return Ok(result);
		}
	}
}
