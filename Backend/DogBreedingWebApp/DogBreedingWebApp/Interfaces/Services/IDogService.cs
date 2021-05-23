using System.Collections.Generic;
using System.Threading.Tasks;

using DogBreedingWebApp.DataModels;

namespace DogBreedingWebApp.Interfaces.Services
{
	public interface IDogService
	{
		Task<IEnumerable<DogModel>> GetAllBreed();
		Task<IEnumerable<string>> GellAllBreedImageURLs(string breed, string subbreed = null);
	}
}
