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
		IEnumerable<DogModel> GetAllSubBreed(string breedName);
		IEnumerable<DogModel> GetAllBreed();
		IEnumerable<string> GellAllBreedImageURLs(string breed, string subbreed = null);
		IEnumerable<string> GellAllSubBreedImageURLs(string breedName);
	}
}
