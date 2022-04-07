namespace AllSpice.Models
{
  public class Recipe
  {
    public int? Id { get; set; }
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public string Catigory { get; set; }
    public string CreatorId { get; set; }
    public string Photo { get; set; }



    // public Account? Creator { get; set; }
  }
}