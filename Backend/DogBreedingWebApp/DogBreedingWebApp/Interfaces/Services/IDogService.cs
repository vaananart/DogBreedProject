using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DogBreedingWebApp.DataModels;

using Microsoft.AspNetCore.Mvc;

namespace DogBreedingWebApp.Interfaces.Services
{
	public interface IDogService
	{
		Task<IEnumerable<DogModel>> GetAllBreed();
		Task<IEnumerable<string>> GellAllBreedImageURLs(string breed, string subbreed = null);
	}
}
