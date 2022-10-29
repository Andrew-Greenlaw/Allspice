using Allspice.Interfaces;
namespace Allspice.Models;

public class ProfilePic
{
  public string Id { get; set; }
  public string Name { get; set; }
  public string Picture { get; set; }
}
public class Profile : ProfilePic, IRepoItem<string>
{
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}
public class Account : Profile
{
  public string Email { get; set; }
}
