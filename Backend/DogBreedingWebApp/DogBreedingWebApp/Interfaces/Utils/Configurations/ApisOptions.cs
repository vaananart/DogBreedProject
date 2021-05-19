using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogBreedingWebApp.Interfaces.Utils.Configurations
{
	public class ApisOptions
	{
		public const string Apis = "Application:Apis";

		public string AllBreeds { get; set; }
		public string BreedImageURL { get; set; }
		public string SubBreedImageURL { get; set; }
	}
}
