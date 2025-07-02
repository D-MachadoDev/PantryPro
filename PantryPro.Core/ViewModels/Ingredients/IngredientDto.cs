
using System.ComponentModel.DataAnnotations;


namespace PantryPro.Core.ViewModels.Ingredients
{
    public class IngredientDto
    {
        [Required] public string IngredientId { get; set; }    // GUID
        [Required] public double QuantityRequired { get; set; } // 0.2
    }
}