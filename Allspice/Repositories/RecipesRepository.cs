namespace Allspice.Repositories;

public class RecipesRepository : BaseRepository
{
  public RecipesRepository(IDbConnection db) : base(db)
  {
  }

  internal Recipe CreateRecipe(Recipe newRecipe)
  {
    string sql = @"
    INSERT INTO recipes(title,instructions,img,category,creatorId)
    VALUES(@Title,@Instructions,@Img,@Category,@CreatorId);
    SELECT LAST_INSERT_ID();";
    int recipeId = _db.ExecuteScalar<int>(sql, newRecipe);
    Recipe recipe = GetById(recipeId);
    return recipe;
  }

  internal List<Recipe> Get()
  {
    string sql = @"
    SELECT
    r.*,
    COUNT(f.id) AS FavoritesCount,
    a.*
    FROM recipes r
    JOIN accounts a ON a.id = r.creatorId
    LEFT JOIN favorites f ON f.recipeId = r.id
    GROUP BY r.id
;";
    return _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) =>
    {
      recipe.Creator = profile;
      return recipe;
    }
    ).ToList();
  }


  public Recipe GetById(int recipeId)
  {
    string sql = @"
    SELECT
    r.*,
    a.*
    FROM recipes r
    JOIN accounts a ON a.Id = r.creatorId
    WHERE r.id = @recipeId
    ;";
    return _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) =>
    {
      recipe.Creator = profile;
      return recipe;
    }, new { recipeId }).FirstOrDefault();
  }
  internal Recipe Update(Recipe recipeData)
  {
    string sql = @"
    UPDATE recipes SET
    title = @Title,
    instructions = @Instructions,
    img = @Img,
    category = @Category
    WHERE Id = @id
    ;";
    int rowsEffected = _db.Execute(sql, recipeData);
    if (rowsEffected == 0)
    {
      throw new Exception("something went wrong nothing was changed");
    }
    return recipeData;
  }

  internal string Delete(int recipeId)
  {
    string sql = "DELETE FROM recipes WHERE Id = @recipeId";
    _db.Execute(sql, new { recipeId });
    return "You Deleted this recipe";
  }
}