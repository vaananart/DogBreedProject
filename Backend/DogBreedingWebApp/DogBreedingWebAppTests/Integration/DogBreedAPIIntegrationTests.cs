using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

using DogBreedingWebApp.Controllers.Dogs;
using DogBreedingWebApp.Implementations.Services;
using DogBreedingWebApp.Implementations.Utils.Http;
using DogBreedingWebApp.Interfaces.Services;
using DogBreedingWebApp.Interfaces.Utils.Configurations;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

using NUnit.Framework;

namespace DogBreedingWebAppTests.Integration
{
	[TestFixture]
	public class DogBreedAPIIntegrationTests
	{
		private const string jsonConfigFileName = "configurations.json";
		private IConfiguration JsonConfigurationObject;

		public object DogController { get; }

		private class DefaultHttpClientFactory : IHttpClientFactory
		{
			private static readonly Lazy<HttpClient> _httpClientLazy =
				new Lazy<HttpClient>(() => new HttpClient());

			public HttpClient CreateClient(string name) => _httpClientLazy.Value;
		}


		[Test]
		public async Task GetAllBreedsAndPossibleSubBreeds_WhenRequestedFor_AllBreed_ShouldReturnAllBreedAndSubBreed()
		{
			//Arrange
			HttpGETClient client = new HttpGETClient(new DefaultHttpClientFactory());
			IDogService dogService = new DogService(Options.Create(new ApplicationOptions
			{
				BaseUrl= "https://dog.ceo/"
			}), Options.Create(new ApisOptions {
				AllBreeds= "api/breeds/list/all",
				BreedImageURL="api/breed/{breedName}/images",
				SubBreedImageURL= "api/breed/{0}{1}/images"
			}), client);
			DogsController dogController = new DogsController(dogService);
			//Action

			var result = await dogController.GetAllBreedsAndPossibleSubBreeds();
			var values = ((OkObjectResult)result).Value as IEnumerable<object>;
			//Assert	
			Assert.IsTrue(values.Count() > 0);	
		}

		[Test]
		public async Task GetAllBreedsImageURL_WhenRequestedFor_ABreed_ShouldReturnTheBreedImageURLs()
		{
			//Arrange
			HttpGETClient client = new HttpGETClient(new DefaultHttpClientFactory());
			IDogService dogService = new DogService(Options.Create(new ApplicationOptions
			{
				BaseUrl = "https://dog.ceo/"
			}), Options.Create(new ApisOptions
			{
				AllBreeds = "api/breeds/list/all",
				BreedImageURL = "api/breed/{breedName}/images",
				SubBreedImageURL = "api/breed/{0}{1}/images"
			}), client);
			DogsController dogController = new DogsController(dogService);
			//Action

			var result = await dogController.GetAllBreedsImageURL("australian");
			var values = ((OkObjectResult)result).Value as IEnumerable<object>;

			//Assert	
			Assert.IsTrue(values.Count() == 4);
		}

		[Test]
		public async Task GetAllBreedsAndPossibleSubBreedsImageURL_WhenRequestedFor_ASubBreed_ShouldReturnTheSubBreedImageURLs()
		{
			//Arrange
			HttpGETClient client = new HttpGETClient(new DefaultHttpClientFactory());
			IDogService dogService = new DogService(Options.Create(new ApplicationOptions
			{
				BaseUrl = "https://dog.ceo/"
			}), Options.Create(new ApisOptions
			{
				AllBreeds = "api/breeds/list/all",
				BreedImageURL = "api/breed/{breedName}/images",
				SubBreedImageURL = "api/breed/{0}{1}/images"
			}), client);
			DogsController dogController = new DogsController(dogService);
			//Action

			var result = await dogController.GetAllBreedsAndPossibleSubBreedsImageURL("australian", "shepherd");
			var values = ((OkObjectResult)result).Value as IEnumerable<object>;

			//Assert	
			Assert.IsTrue(values.Count() > 0);
		}

	}
}
