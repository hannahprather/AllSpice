using System;
using System.Collections.Generic;
using AllSpice.Models;
using AllSpice.Repositories;

namespace AllSpice.Services
{
  public class RecipesService
  {
    private readonly RecipesRepository _recipesRepo;

    public RecipesService(RecipesRepository recipesRepo)
    {
      _recipesRepo = recipesRepo;
    }

    internal List<Recipe> GetAll()
    {
      return _recipesRepo.GetAll();
    }

    internal Recipe GetById(int id)
    {
      Recipe found = _recipesRepo.GetById(id);
      if (found == null)
      {
        throw new Exception("invaild Id");
      }
      return found;
    }

    internal List<Ingredient> GetIngredients(int id)
    {
      return _recipesRepo.GetIngredients(id);
    }
    internal Recipe Create(Recipe recipeData)
    {
      throw new NotImplementedException();
    }


    internal string Remove(int id, Account userInfo)
    {
      Recipe recipe = _recipesRepo.GetById(id);
      if (recipe.creatorId != userInfo.Id)
      {
        throw new Exception("this isnt your recipe fool!");
      }
      return _recipesRepo.Remove(id);
    }
  }
}
