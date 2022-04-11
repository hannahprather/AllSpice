using AllSpice.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AllSpice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class IngredientsController : ControllerBase
  {
    private readonly IngredientsService _is;
    public IngredientsController(IngredientsService @is)
    {

    }
  }
}