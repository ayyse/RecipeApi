using Microsoft.EntityFrameworkCore;
using RecipeApi.Models;

namespace RecipeApi.Data
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RecipeDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<RecipeDbContext>>()))
            {
                if (context.Recipes.Any())
                {
                    return;
                }

                context.Recipes.AddRange(
                   new Recipe()
                   {
                       Title = "Karnıyarık",
                       PhotoUrl = "",
                       Ingredients = "Patlıcan, Kıyma",
                       Description = "Tarif"
                   },
                   new Recipe()
                   {
                       Title = "Arnavut Ciğeri",
                       PhotoUrl = "",
                       Ingredients = "Ciğer",
                       Description = "Tarif"
                   }
                   );

                context.SaveChanges();
            }
            
        }
    }
}
