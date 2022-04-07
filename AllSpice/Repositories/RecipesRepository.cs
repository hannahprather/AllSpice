using System.Data;

namespace AllSpice.Repositories
{
  public class RecipiesRepository
  {
    private readonly IDbConnection _db;

    public RecipiesRepository(IDbConnection db)
    {
      _db = db;
    }

  }
}