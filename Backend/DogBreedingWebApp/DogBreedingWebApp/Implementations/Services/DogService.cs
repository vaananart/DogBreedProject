using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using DogBreedingWebApp.DataModels;
using DogBreedingWebApp.Interfaces.Services;
using DogBreedingWebApp.Interfaces.Utils.Configurations;
using DogBreedingWebApp.Interfaces.Utils.Http;

using Microsoft.Extensions.Options;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
			var baseUrl = _applicationOptions.BaseUrl;
			var breedApi = _apisOptions.SubBreedImageURL;

			return null;
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

			var jObject = JObject.Parse(rawPayload);

			var result = jObject["message"];

			var rootLevel = jObject.Values();
			var resultPropertyNames = rootLevel.FirstOrDefault().Select(x=>(x as JProperty));

			var resultList = from breed in resultPropertyNames
							 from subBreed in (breed.Value as JArray)
							 //from element in subBreed
							 select new DogModel
							 {
								 BreedName= breed.Name,
								 SubBreedName = (subBreed as JValue).Value.ToString()
							 };

			return resultList;
		}

		public IEnumerable<DogModel> GetAllSubBreed(string breedName)
		{
			throw new NotImplementedException();
		}
	}
}
