namespace Allspice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IngredientsController : ControllerBase
{
  private readonly IngredientsService _is;
  private readonly Auth0Provider _auth0provider;

  public IngredientsController(IngredientsService @is, Auth0Provider auth0provider)
  {
    _is = @is;
    _auth0provider = auth0provider;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Ingredient>> CreateIngredient([FromBody] Ingredient ingredientData)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      Ingredient ingredient = _is.CreateIngredient(ingredientData, userInfo);
      return Ok(ingredient);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpDelete("{ingredientId}")]
  [Authorize]
  public async Task<ActionResult<Ingredient>> DeleteIngredient(int ingredientId)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      string ingredient = _is.DeleteIngredient(ingredientId, userInfo);
      return Ok(ingredient);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
