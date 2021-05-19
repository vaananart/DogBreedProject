using System;
using System.Net.Http;
using System.Threading.Tasks;

using DogBreedingWebApp.Interfaces.Utils.Http;

namespace DogBreedingWebApp.Implementations.Utils.Http
{
	public class HttpGETClient: IHttpGETClient
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public HttpGETClient(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<string> Get(string fullUrl)
		{
			var httpClient = _httpClientFactory.CreateClient();
			var response = String.Empty;
			try
			{
				using (var result = await httpClient.GetAsync(fullUrl))
				{
					if (result.IsSuccessStatusCode)
					{
						response = await result.Content.ReadAsStringAsync();
						//REVIEW: lOGGING NEEDED IN HERE
					}
					else
					{
						//REVIEW: lOGGING NEEDED IN HERE
					}
				}
			}
			catch (Exception ex)
			{
				//REVIEW: THROW EXCEPTIONS 
			}
			return response;
		}
	}
}
