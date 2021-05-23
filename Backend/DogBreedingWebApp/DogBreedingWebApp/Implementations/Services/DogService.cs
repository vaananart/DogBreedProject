using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using DogBreedingWebApp.DataModels;
using DogBreedingWebApp.Interfaces.Services;
using DogBreedingWebApp.Interfaces.Utils.Configurations;
using DogBreedingWebApp.Interfaces.Utils.Http;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Newtonsoft.Json.Linq;

namespace DogBreedingWebApp.Implementations.Services
{
	public class DogService : IDogService
	{
		private readonly IHttpGETClient _getClient;
		private readonly ILogger _logger;
		private readonly ApplicationOptions _applicationOptions;
		private readonly ApisOptions _apisOptions;

		public DogService(ILogger<DogService> logger
							,IOptions<ApplicationOptions> applicationOptions
							, IOptions<ApisOptions> apisOptions
							, IHttpGETClient getClient)
		{
			_logger = logger;
			_applicationOptions = applicationOptions.Value;
			_apisOptions = apisOptions.Value;
			_getClient = getClient;
		}

		public async Task<IEnumerable<string>> GellAllBreedImageURLs(string breed, string subbreed = null)
		{
			_logger.LogInformation($"DogService:GellAllBreedImageURLs: bread:{breed}-subbreed:{subbreed} request for images");
			var baseUrl = _applicationOptions.BaseUrl;
			var breedApi = string.Format(_apisOptions.SubBreedImageURL, breed, !string.IsNullOrEmpty(subbreed) ? ("/"+ subbreed) : null );
			var fullUrl = baseUrl + breedApi;

			JObject jObject = null;
			try
			{
				var rawPayload = await _getClient.Get(fullUrl);
				jObject = JObject.Parse(rawPayload);
			}
			catch (HttpRequestException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				_logger.LogError($"DogService:GellAllBreedImageURLs: something went wrong. {ex.Message}");
			}
			var result = jObject["message"];
			var rootLevel = jObject.Values();
			var imageResult = rootLevel.FirstOrDefault().Select(x => (x as JValue).Value as string);
			return imageResult;
		}

		public async Task<IEnumerable<DogModel>> GetAllBreed()
		{
			_logger.LogInformation($"DogService:GetAllBreed:Request for all Breed and SubBreed names");
			var baseUrl = _applicationOptions.BaseUrl;
			var breedApi = _apisOptions.AllBreeds;
			var fullUrl = baseUrl + breedApi;

			JObject jObject = null;
			try
			{
				var rawPayload = await _getClient.Get(fullUrl);
				jObject = JObject.Parse(rawPayload);
				
			}
			catch (HttpRequestException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				_logger.LogError($"DogService:GetAllBreed: something went wrong. {ex.Message}");
			}

			var result = jObject["message"];
			var rootLevel = jObject.Values();
			var resultPropertyNames = rootLevel.FirstOrDefault().Select(x=>(x as JProperty));

			var subBreedresultList = from breed in resultPropertyNames
							 from subBreed in (breed.Value as JArray)
							 select new DogModel
							 {
								 Breed = breed.Name,
								 SubBreed = (subBreed as JValue).Value.ToString()
							 };

			var alternativeList = from breed in resultPropertyNames
									where (breed.Value as JArray).ToString() == "[]"
								  select new DogModel
							 {
								 Breed = breed.Name
							 };

			var finalResult = subBreedresultList.ToList();
			finalResult.AddRange(alternativeList);
			return finalResult.OrderBy(x=>x.Breed);
		}
	}
}
