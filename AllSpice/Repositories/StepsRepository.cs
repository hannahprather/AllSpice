using System.Data;

namespace allspice.Repositories
{
  public class StepsRepository
  {

    private readonly IDbConnection _db;

    public StepsRepository(IDbConnection db)
    {
      _db = db;
    }

  }
}