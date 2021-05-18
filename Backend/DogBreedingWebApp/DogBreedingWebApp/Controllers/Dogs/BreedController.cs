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
	public class BreedController : ControllerBase
	{
		private readonly IDogService _dogService;

		public BreedController(IDogService dogService)
		{
			_dogService = dogService;	
		}
		[HttpGet]
		public IActionResult GetAll()
		{
			return _dogService.GetAllBreed();
		}

		public IActionResult GetAllImageURLs()
		{
			return _dogService.GellAllBreedImageURLs();
		}
	}
}
