using System;
using System.Net.Http;
using System.Threading.Tasks;

using DogBreedingWebApp.Interfaces.Utils.Http;

using Microsoft.Extensions.Logging;

namespace DogBreedingWebApp.Implementations.Utils.Http
{
	public class HttpGETClient: IHttpGETClient
	{
		private readonly ILogger _logger;
		private readonly IHttpClientFactory _httpClientFactory;

		public HttpGETClient(ILogger<HttpGETClient> logger
								, IHttpClientFactory httpClientFactory)
		{
			_logger = logger;
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
						_logger.LogInformation($"HttpGETClient:Get:{fullUrl} => has made a suceessful request.");
					}
					else
					{
						_logger.LogWarning($"HttpGETClient:Get:{fullUrl} => has made made a failed request.");
						_logger.LogWarning($"HttpGETClient:Get:{fullUrl} => reqsponse status is {result.StatusCode}.");
					}
				}
			}
			catch (Exception ex)
			{
				throw new HttpRequestException(ex.Message);
			}
			return response;
		}
	}
}
