namespace Allspice.Services;

public class FavoritesService
{
  private readonly FavoritesRepository _repo;
  private readonly RecipesService _recipesService;

  public FavoritesService(FavoritesRepository repo, RecipesService recipesService)
  {
    _repo = repo;
    _recipesService = recipesService;
  }

  internal Favorite CreateFavorite(Favorite favoriteData)
  {
    Recipe recipe = _recipesService.GetById(favoriteData.RecipeId);
    if (recipe == null)
    {
      throw new Exception("this recipe doesnt exist anymore");
    }
    return _repo.Create(favoriteData);
  }

  internal List<Favorite> GetAllFavorites(string accountId)
  {
    return _repo.Get(accountId);
  }

  internal string DeleteFavorite(int favoriteId, Account userInfo)
  {
    Favorite favorite = _repo.GetById(favoriteId);
    if (favorite.AccountId != userInfo.Id)
    {
      throw new Exception("This Is not Yours To Delete");
    }
    return _repo.Delete(favoriteId);
  }
}
