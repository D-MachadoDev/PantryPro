using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PantryPro.ExternalAPIs.Spoonacular
{
    public class SpoonacularService : IRecipeService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SpoonacularService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory.CreateClient("Spoonacular");;
        }

        // Implement methods to interact with the Spoonacular API
        // Example: GetRecipes, GetRecipeDetails, etc.
        
    }
}