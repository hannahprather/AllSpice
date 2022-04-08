using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AllSpice.Models;
using AllSpice.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AllSpice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class RecipesController : ControllerBase
  {
    private readonly RecipesService _rs;

    public RecipesController(RecipesService rs)
    {
      _rs = rs;
    }

    [HttpGet]
    public ActionResult<List<Recipe>> GetAll()
    {
      try
      {
        List<Recipe> recipes = _rs.GetAll();
        return Ok(recipes);
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Recipe>> Create([FromBody] Recipe recipeData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        recipeData.creatorId = userInfo.Id;
        Recipe recipe = _rs.Create(recipeData);
        recipe.Creator = userInfo;
        return Created($"api/recipes/{recipe.Id}", recipe);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}