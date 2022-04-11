using AllSpice.Models;
using AllSpice.Services;

namespace AllSpice.Repositories
{
  public class IngredientsService
  {
    private readonly IngredientsRepository _ingredentsRepo;
    private readonly RecipesService _rs;
    public IngredientsService(IngredientsRepository ingredientsRepo, RecipesService rs)
    {
      _rs = rs;
      _ingredentsRepo = ingredientsRepo;
    }

    internal Ingredient Create(Ingredient ingredientData, Account userInfo)
    {
      Recipe recipe = _rs.GetById(ingredientData.RecipeId);
      ingredientData.RecipeId = recipe.Id;
      if (recipe.creatorId != userInfo.Id)
      {
        throw new System.Exception("THIS ISNT YOUR RECIPEEEE!!!");
      }
      return _ingredentsRepo.Create(ingredientData);
    }

    internal object Remove(Account userInfo, int id)
    {
      Ingredient ingredient = _ingredentsRepo.GetById(id);
      Recipe recipe = _rs.GetById(ingredient.RecipeId);
      if (recipe.creatorId != userInfo.Id)
      {
        throw new System.Exception("Cant delort if it aint yours");
      }
      return _ingredentsRepo.Remove(id);
    }
  }
}