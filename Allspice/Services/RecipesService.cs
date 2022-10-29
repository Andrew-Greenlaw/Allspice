namespace Allspice.Services;

public class RecipesService
{
  private readonly RecipesRepository _repo;

  public RecipesService(RecipesRepository repo)
  {
    _repo = repo;
  }

  internal Recipe CreateRecipe(Recipe newRecipe)
  {
    return _repo.CreateRecipe(newRecipe);
  }

  internal List<Recipe> GetAllRecipes()
  {
    return _repo.Get();
  }

  internal Recipe GetById(int recipeId)
  {
    Recipe recipe = _repo.GetById(recipeId);
    if (recipe == null)
    {
      throw new Exception("Invalid Recipe Id");
    }
    return recipe;
  }

  internal Recipe EditRecipe(Recipe recipeData)
  {
    Recipe recipe = GetById(recipeData.Id);
    if (recipeData.CreatorId != recipe.CreatorId)
    {
      throw new Exception("you are not the creator of this recipe Get Away!");
    }
    recipe.Title = recipeData.Title ?? recipe.Title;
    recipe.Instructions = recipeData.Instructions ?? recipe.Instructions;
    recipe.Img = recipeData.Img ?? recipe.Img;
    recipe.Category = recipeData.Category ?? recipe.Category;
    return _repo.Update(recipe);
  }

  internal string DeleteRecipe(int recipeId, Account userInfo)
  {
    Recipe recipe = GetById(recipeId);
    if (recipe.CreatorId != userInfo.Id)
    {
      throw new Exception("cannot Delet this you did not create it!");
    }
    return _repo.Delete(recipeId);
  }
}