using AutoMapper;
using PantryPro.Core.DTOs;
using PantryPro.Core.DTOs.Achievements;
using PantryPro.Core.DTOs.Inventary;
using PantryPro.Core.DTOs.MealPlans;
using PantryPro.Core.DTOs.Recipes;
using PantryPro.Core.DTOs.Shopping;
using PantryPro.Core.DTOs.Subscriptions;
using PantryPro.Core.DTOs.Users;
using PantryPro.Core.Models;
using PantryPro.Core.Models.Achievements;
using PantryPro.Core.Models.Inventory;
using PantryPro.Core.Models.MealPlans;
using PantryPro.Core.Models.Recipes;
using PantryPro.Core.Models.Shopping;
using PantryPro.Core.Models.Subscriptions;
using PantryPro.Core.Models.Users;


namespace PantryPro.Core.Mapping
{
    public class PantryProMappingProfile : Profile
    {
        public PantryProMappingProfile()
        {
            // ==================== Mapeos Base ====================
            CreateMap<BaseEntity, BaseDto>().ReverseMap();

            // ==================== Usuarios ====================
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.ProfileImageUrl, opt => opt.MapFrom(src => src.ProfileImageUrl))
                .ForMember(dest => dest.NotificationsEnabled, opt => opt.MapFrom(src => src.NotificationsEnabled))
                .ForMember(dest => dest.ExpirationAlertsEnabled, opt => opt.MapFrom(src => src.ExpirationAlertsEnabled))
                .ForMember(dest => dest.SubscriptionStatus, opt => opt.MapFrom(src => 
                    src.UserSubscription != null ? src.UserSubscription.Status.ToString() : "Free"));

            CreateMap<CreateUserDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.EmailVerified, opt => opt.MapFrom(_ => false))
                .ForMember(dest => dest.NotificationsEnabled, opt => opt.MapFrom(_ => true))
                .ForMember(dest => dest.ExpirationAlertsEnabled, opt => opt.MapFrom(_ => true));

            CreateMap<UpdateUserDto, User>()
                .ForMember(dest => dest.Email, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

            // ==================== Preferencias ====================
            CreateMap<UserPreference, UserPreferenceDto>()
                .ForMember(dest => dest.IsVegetarian, opt => opt.MapFrom(src => src.IsVegetarian))
                .ForMember(dest => dest.IsVegan, opt => opt.MapFrom(src => src.IsVegan))
                .ForMember(dest => dest.IsGlutenFree, opt => opt.MapFrom(src => src.IsGlutenFree))
                .ForMember(dest => dest.MaxCookingTimeMinutes, opt => opt.MapFrom(src => src.MaxCookingTimeMinutes));

            CreateMap<UserPreferenceDto, UserPreference>()
                .ForMember(dest => dest.UserId, opt => opt.Ignore());

            // ==================== Categorías ====================
            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color));

            // ==================== Ingredientes ====================
            CreateMap<Ingredient, IngredientDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.DefaultUnit, opt => opt.MapFrom(src => src.DefaultUnit));

            CreateMap<UserIngredient, UserIngredientDto>()
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => src.Unit))
                .ForMember(dest => dest.ExpirationDate, opt => opt.MapFrom(src => src.ExpirationDate));

            // ==================== Recetas ====================
            CreateMap<Recipe, RecipeDto>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ServingSize, opt => opt.MapFrom(src => src.ServingSize))
                .ForMember(dest => dest.PreparationTimeMinutes, opt => opt.MapFrom(src => src.PreparationTimeMinutes))
                .ForMember(dest => dest.CookingTimeMinutes, opt => opt.MapFrom(src => src.CookingTimeMinutes));

            CreateMap<RecipeIngredient, RecipeIngredientDto>()
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => src.Unit));

            // ==================== Planes de Comida ====================
            CreateMap<MealPlan, MealPlanDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));

            // ==================== Listas de Compra ====================
            CreateMap<ShoppingList, ShoppingListDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.IsCompleted, opt => opt.MapFrom(src => src.IsCompleted));

            // ==================== Logros ====================
            CreateMap<Achievement, AchievementDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Points, opt => opt.MapFrom(src => src.Points));

            // ==================== Suscripciones ====================
            CreateMap<SubscriptionPlan, SubscriptionPlanDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));
        }
    }
}