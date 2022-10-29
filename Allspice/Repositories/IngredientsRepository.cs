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
    VALUES(@Name,@Quantity,@RecipeId);
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

  internal List<Ingredient> Get(int RecipeId)
  {
    string sql = @"
    SELECT * FROM ingredients
    WHERE recipeId = @RecipeId
    ;";
    return _db.Query<Ingredient>(sql, new { RecipeId }).ToList();
  }
  internal string Delete(int ingredientId)
  {
    string sql = @"
    DELETE FROM ingredients WHERE Id = @ingredientId LIMIT 1
    ;";
    _db.Execute(sql, new { ingredientId });
    return "You deleted this Ingredient";
  }
}
