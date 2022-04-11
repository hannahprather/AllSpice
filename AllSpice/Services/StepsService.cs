using allspice.Repositories;

namespace AllSpice.Services
{

  public class StepsService
  {
    private readonly StepsRepository _stepsRepo;
    private readonly RecipesService _rs;
    public StepsService(StepsRepository stepsRepo, RecipesService rs)
    {
      _stepsRepo = stepsRepo;
      _rs = rs;
    }


  }
}