using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AllSpice.Models;
using Dapper;

namespace AllSpice.Repositories
{
  public class RecipesRepository
  {
    private readonly IDbConnection _db;

    public RecipesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Recipe> GetAll()
    {
      string sql = @"
      Select 
      r.*
      a.*
      From recipes r
      JOIN accounts a Where a.id = g.creatorId;
      ";
      return _db.Query<Recipe, Account, Recipe>(sql, (r, account) =>
      {
        r.Creator = account;
        return r;
      }).ToList();
    }

    internal Recipe GetById(int id)
    {
      string sql = @"
      SELECT
    r.*
    a.*
    FROM recipes r
    JOIN accounts a ON r.creatorId = a.id
    WHERE r.id = @id
    ";
      return _db.Query<Recipe, Account, Recipe>(sql, (r, a) =>
      {
        r.Creator = a;
        return r;
      }, new { id }).FirstOrDefault();
    }

    internal List<Ingredient> GetIngredients(int id)
    {
      string sql = @"
      SELECT
     i.*
     
      FROM ingredients i
       WHERE i.recipeId = @id;
      ";
      return _db.Query<Ingredient>(sql, new { id }).ToList();
    }

    internal Recipe Create(Recipe recipeData)
    {
      string sql = @"
    INSERT INTO recipes
    (title,subtitle,category,creatorId,picture)
    VALUE
    (@Title,@Subtitle,@Category,@CreatorId,@Picture);
    SELECT LAST_INSERT_ID();
    ";
      int id = _db.ExecuteScalar<int>(sql, recipeData);
      recipeData.Id = id;
      return recipeData;
    }

    internal void Edit(Recipe origional)
    {
      string sql = @"
      UPDATE recipes
      SET
       title = @Title,
       subtitle = @Subtitle,
       category = @Category,
       picture = @Picture
      WHERE id = @Id;";
      _db.Execute(sql, origional);
    }


    internal string Remove(int id)
    {
      string sql = @"
  Delete FROM recipes WHERE id = @id LIMIT 1;
  ";
      int rowsAffected = _db.Execute(sql, new { id });
      if (rowsAffected > 0)
      {
        return "delorted";
      }
      throw new Exception("this recipe could not be deleted");
    }

  }



}