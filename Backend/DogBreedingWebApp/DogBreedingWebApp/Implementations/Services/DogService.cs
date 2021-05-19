using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DogBreedingWebApp.DataModels;
using DogBreedingWebApp.Interfaces.Services;
using DogBreedingWebApp.Interfaces.Utils.Configurations;
using DogBreedingWebApp.Interfaces.Utils.Http;

using Microsoft.Extensions.Options;

namespace DogBreedingWebApp.Implementations.Services
{
	public class DogService : IDogService
	{
		private readonly IHttpGETClient _getClient;
		private ApplicationOptions _applicationOptions;
		private readonly ApisOptions _apisOptions;

		public DogService(IOptions<ApplicationOptions> applicationOptions
							, IOptions<ApisOptions> apisOptions
							, IHttpGETClient getClient)
		{
			_applicationOptions = applicationOptions.Value;
			_apisOptions = apisOptions.Value;
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

		public async Task<IEnumerable<DogModel>> GetAllBreed()
		{
			var baseUrl = _applicationOptions.BaseUrl;
			var breedApi = _apisOptions.AllBreeds;
			var fullUrl = baseUrl + breedApi;
			var rawPayload = await _getClient.Get(fullUrl);

			return null;
		}

		public IEnumerable<DogModel> GetAllSubBreed(string breedName)
		{
			throw new NotImplementedException();
		}
	}
}
