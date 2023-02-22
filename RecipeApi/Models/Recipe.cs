using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeApi.Models
{
    public class Recipe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string PhotoUrl { get; set; }
        public string Ingredients { get; set; }
        public string Description { get; set; }
    }
}
