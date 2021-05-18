using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
	}
}
