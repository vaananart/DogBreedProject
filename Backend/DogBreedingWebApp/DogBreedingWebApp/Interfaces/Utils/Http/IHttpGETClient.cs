﻿using System.Threading.Tasks;

namespace DogBreedingWebApp.Interfaces.Utils.Http
{
	public interface IHttpGETClient
	{
		Task<string> Get(string fullUrl);
	}
}
