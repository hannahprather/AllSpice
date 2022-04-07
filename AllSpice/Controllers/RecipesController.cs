using AllSpice.Services;
using Microsoft.AspNetCore.Mvc;

namespace AllSpice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class RecipesController : ControllerBase
  {
    private readonly RecipiesService _rs;

    public RecipesController(RecipiesService rs)
    {
      _rs = rs;
    }


  }

}