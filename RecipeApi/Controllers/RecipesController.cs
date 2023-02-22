using Microsoft.AspNetCore.Mvc;
using RecipeApi.Data;
using RecipeApi.Models;

namespace RecipeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipesController : Controller
    {
        private readonly RecipeDbContext _context;
        public RecipesController(RecipeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Recipe> GetRecipes()
        {
            var recipes = _context.Recipes.OrderBy(x => x.Title).ToList(); // Order by title
            return recipes;
        }

        [HttpGet("{id}")]
        public Recipe GetRecipeById([FromQuery] int id)
        {
            var recipe = _context.Recipes.Where(x => x.Id == id).SingleOrDefault();
            return recipe;
        }

        [HttpPost]
        public IActionResult CreateRecipe([FromBody] Recipe newRecipe)
        {
            var recipe = _context.Recipes.SingleOrDefault(x => x.Title == newRecipe.Title);

            if (recipe is not null)
                return BadRequest();

            _context.Recipes.Add(recipe);
            _context.SaveChanges();

            return Ok(); // Ok => 200 http status code
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRecipe([FromQuery] int id, [FromBody] Recipe newRecipe)
        {
            var recipe = _context.Recipes.Where(x => x.Id == id).SingleOrDefault();

            if (recipe is null)
                return BadRequest(); // BadRequest => 400 http status code

            recipe.Title = newRecipe.Title != default ? newRecipe.Title : recipe.Title;
            recipe.PhotoUrl = newRecipe.PhotoUrl != default ? newRecipe.PhotoUrl : recipe.PhotoUrl;
            recipe.Ingredients = newRecipe.Ingredients != default ? newRecipe.Ingredients : recipe.Ingredients;
            recipe.Description = newRecipe.Description != default ? newRecipe.Description : recipe.Description;

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRecipe([FromRoute] int id)
        {
            var recipe = _context.Recipes.Where(x => x.Id == id).SingleOrDefault();

            if (recipe is null)
                return NotFound(); // NotFound => 404 http status code

            _context.Recipes.Remove(recipe);
            _context.SaveChanges();

            return Ok();
        }
    }
}
