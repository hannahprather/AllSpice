namespace AllSpice.Models
{
  public class Recipe
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public string Category { get; set; }
    public string creatorId { get; set; }
    public string Photo { get; set; }
    public Account? Creator { get; set; }
  }

  public class RecipeViewModel : Recipe
  {
    public string? AccountId { get; set; }
    // may not need this account id
    public int? FavoriteId { get; set; }
  }
}