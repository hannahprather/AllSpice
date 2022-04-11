using AllSpice.Models;
using System.Data;
using Dapper;
using System;

namespace AllSpice.Services
{
  public class IngredientsRepository
  {
    private readonly IDbConnection _db;


    internal Ingredient GetById(int id)
    {
      string sql = "SELECT * FROM ingredients WHERE id = @id;";
      return _db.QueryFirstOrDefault<Ingredient>(sql, new { id });
    }

    //create ingredient
    internal Ingredient Create(Ingredient ingredientData)
    {
      string sql = @"
    INSERT INTO ingredients
    (name,quantity,recipeId)
    VALUE
    (@Name,@Quantity,@RecipeId);
    SELECT LAST_INSERT_ID();
    ";
      int id = _db.ExecuteScalar<int>(sql, ingredientData);
      ingredientData.Id = id;
      return ingredientData;
    }


    internal object Remove(int id)
    {
      string sql = @"
      DELETE FROM ingredients WHERE id = @id LIMIT 1;
      ";
      int rowsAffected = _db.Execute(sql, new { id });
      if (rowsAffected > 0)
      {
        return "delorted ingredient";
      }
      throw new Exception("couldnt be delorted");
    }
  }
}