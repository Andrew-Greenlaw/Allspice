namespace Allspice.Repositories;
public class FavoritesRepository : BaseRepository
{
  public FavoritesRepository(IDbConnection db) : base(db)
  {
  }
  public Favorite Create(Favorite favoriteData)
  {
    string sql = @"
    INSERT INTO favorites(accountId,recipeId)
    VALUES(@AccountId,@RecipeId);
    SELECT LAST_INSERT_ID()
    ;";
    int id = _db.ExecuteScalar<int>(sql, favoriteData);
    Favorite favorite = GetById(id);
    return favorite;

  }
  public Favorite GetById(int Id)
  {
    string sql = @"
    SELECT * FROM favorites f
    WHERE f.id = @id
    ;";
    return _db.Query<Favorite>(sql, new { Id }).FirstOrDefault();
  }

  internal List<FavoritedRecipe> Get(string userId)
  {
    string sql = @"
    SELECT 
    a.*,
    r.*, 
    f.id AS FavoriteId
    FROM favorites f
    JOIN recipes r ON r.id = f.recipeId
    JOIN accounts a ON a.id = r.creatorId
    WHERE f.accountId = @userId
    ;";
    return _db.Query<Account, FavoritedRecipe, FavoritedRecipe>(sql, (account, recipe) =>
    {
      recipe.Creator = account;
      return recipe;
    }, new { userId }).ToList();
  }

  internal string Delete(int FavoriteId)
  {
    string sql = @"
    DELETE FROM favorites f
    WHERE f.id = @FavoriteId
    ;";
    _db.Execute(sql, new { FavoriteId });
    return "You Deleted Your Favorite";
  }
}
