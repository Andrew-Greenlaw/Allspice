namespace Allspice.Repositories;
public class IngredientsRepository : BaseRepository
{
  public IngredientsRepository(IDbConnection db) : base(db)
  {
  }
  public Ingredient Create(Ingredient ingredientData)
  {
    string sql = @"
    INSERT INTO ingredients(name,quantity,recipeId)
    VALUES(@name,@Quantity,@RecipeId);
    SELECT LAST_INSERT_ID()
    ;";
    int ingredientId = _db.ExecuteScalar<int>(sql, ingredientData);
    Ingredient ingredient = GetById(ingredientId);
    return ingredient;
  }
  // REVIEW ASK CAN I SELECT THE ENTIRE INGREDIETS AND RETURN WITH LAST_INSERT_ID
  public Ingredient GetById(int ingredientId)
  {
    string sql = @"
    SELECT * FROM ingredients
    WHERE Id = @ingredientId
    ;";
    return _db.Query<Ingredient>(sql, new { ingredientId }).FirstOrDefault();
  }

  internal List<Ingredient> Get(int recipeId)
  {
    string sql = @"
    SELECT * FROM ingredients
    WHERE recipeId = @recipeId
    ;";
    return _db.Query<Ingredient>(sql, new { recipeId }).ToList();
  }
}
