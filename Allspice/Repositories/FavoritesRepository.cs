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

  internal List<Favorite> Get(string AccountId)
  {
    string sql = @"
    SELECT * FROM favorites f
    WHERE f.accountId = @AccountId
    ;";
    return _db.Query<Favorite>(sql, new { AccountId }).ToList();
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
