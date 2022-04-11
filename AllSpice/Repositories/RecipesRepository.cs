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
      Join accounts a Where a.id = g.creatorId;
      ";
      return _db.Query<Recipe, Account, Recipe>(sql, (r, account) =>
      {
        r.Creator = account;
        return r;
      }).ToList();
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




  }



}