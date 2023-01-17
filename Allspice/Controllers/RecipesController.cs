namespace Allspice.Controllers;
[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
  private readonly RecipesService _rs;
  private readonly Auth0Provider _auth0provider;
  private readonly IngredientsService _is;

  public RecipesController(RecipesService rs, Auth0Provider auth0provider, IngredientsService @is)
  {
    _rs = rs;
    _auth0provider = auth0provider;
    _is = @is;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe newRecipe)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      newRecipe.CreatorId = userInfo.Id;
      Recipe createdRecipe = _rs.CreateRecipe(newRecipe);
      return Ok(createdRecipe);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpGet]
  public ActionResult<List<FavoritedRecipe>> GetAllRecipes()
  {
    try
    {
      List<FavoritedRecipe> recipes = _rs.GetAllRecipes();
      return Ok(recipes);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpGet("{recipeId}")]
  [Authorize]
  public ActionResult<Recipe> GetRecipeById(int recipeId)
  {
    try
    {
      Recipe recipe = _rs.GetById(recipeId);
      return Ok(recipe);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{recipeId}/ingredients")]
  public ActionResult<List<Ingredient>> GetIngredientsByRecipeId(int recipeId)
  {
    try
    {
      List<Ingredient> ingredients = _is.GetIngredientsByRecipe(recipeId);
      return Ok(ingredients);

    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{recipeId}")]
  [Authorize]
  public async Task<ActionResult<Recipe>> EditRecipe([FromBody] Recipe recipeData, int recipeId)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      recipeData.CreatorId = userInfo.Id;
      recipeData.Id = recipeId;
      Recipe recipe = _rs.EditRecipe(recipeData);
      return Ok(recipe);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpDelete("{recipeId}")]
  [Authorize]
  public async Task<ActionResult<Recipe>> DeleteRecipe(int recipeId)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      string recipe = _rs.DeleteRecipe(recipeId, userInfo);
      return Ok(recipe);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}