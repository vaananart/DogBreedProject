using System;
using System.Collections.Generic;
using System.Linq;
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
	}
}
