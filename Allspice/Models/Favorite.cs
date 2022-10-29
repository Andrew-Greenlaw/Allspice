namespace Allspice.Models;

public class Favorite : Recipe
{
  public int id { get; set; }
  public string accountId { get; set; }
  public int recipeId { get; set; }
}