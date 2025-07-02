using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PantryPro.Core.Interfaces;


namespace PantryPro.ExternalAPIs.Spoonacular
{
    public class SpoonacularService : IRecipeService
    {
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IRecipeService _recipeService;

    public SpoonacularService(IHttpClientFactory httpClientFactory, IRecipeService recipeService)
    {
        _httpClientFactory = httpClientFactory;
        _recipeService = recipeService;
    }

        // Implement methods to interact with the Spoonacular API
        // Example: GetRecipes, GetRecipeDetails, etc.
        
    }
}