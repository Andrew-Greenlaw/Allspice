namespace Allspice.Services;

public class IngredientsService
{
  private readonly IngredientsRepository _repo;
  private readonly RecipesService _recipesService;

  public IngredientsService(IngredientsRepository repo, RecipesService recipesService)
  {
    _repo = repo;
    _recipesService = recipesService;
  }

  internal Ingredient CreateIngredient(Ingredient ingredientData, Account userInfo)
  {
    Recipe recipe = _recipesService.GetById(ingredientData.RecipeId);
    if (recipe == null)
    {
      throw new Exception("this recipe doesnt exist");
    }
    if (recipe.CreatorId != userInfo.Id)
    {
      throw new Exception("You didnt create this recipe, you can't add ingredients");
    }
    return _repo.Create(ingredientData);
  }

  internal List<Ingredient> GetIngredientsByRecipe(int recipeId)
  {
    return _repo.Get(recipeId);
  }

  internal string DeleteIngredient(int ingredientId, Account userInfo)
  {
    return _repo.Delete(ingredientId);
  }
}
