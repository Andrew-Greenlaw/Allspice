using Allspice.Interfaces;
namespace Allspice.Models;
public class Ingredient : IRepoItem<int>
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string Name { get; set; }
  public string quantity { get; set; }
  public int recipeId { get; set; }
}