namespace Allspice.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class FavoritesController : ControllerBase
{
  private readonly FavoritesService _fs;
  private readonly Auth0Provider _auth0provider;

  public FavoritesController(FavoritesService fs, Auth0Provider auth0provider)
  {
    _fs = fs;
    _auth0provider = auth0provider;
  }

  [HttpPost]
  public async Task<ActionResult<Favorite>> CreateFavorite([FromBody] Favorite favoriteData)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      favoriteData.AccountId = userInfo.Id;
      Favorite favorite = _fs.CreateFavorite(favoriteData);
      return Ok(favorite);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpDelete("{favoriteId}")]
  public async Task<ActionResult<Favorite>> DeleteFavorite(int favoriteId)
  {
    try
    {
      Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
      string favorite = _fs.DeleteFavorite(favoriteId, userInfo);
      return Ok(favorite);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
