using AllSpice.Repositories;

namespace AllSpice.Services
{
  public class RecipiesService
  {
    private readonly RecipiesRepository _recipiesRepo;
    public RecipiesService(RecipiesRepository recipiesRepo)
    {
      _recipiesRepo = recipiesRepo;
    }
  }
}