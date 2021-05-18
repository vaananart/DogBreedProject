using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DogBreedingWebApp.DataModels;
using DogBreedingWebApp.Interfaces.Services;
using DogBreedingWebApp.Interfaces.Utils.Http;

namespace DogBreedingWebApp.Implementations.Services
{
	public class DogService : IDogService
	{
		private readonly IHttpGETClient _getClient;

		public DogService(IHttpGETClient getClient)
		{
			_getClient = getClient;
		}

		public IEnumerable<string> GellAllBreedImageURLs(string breed, string subbreed = null)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<string> GellAllSubBreedImageURLs(string breedName)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<DogModel> GetAllBreed()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<DogModel> GetAllSubBreed(string breedName)
		{
			throw new NotImplementedException();
		}
	}
}
