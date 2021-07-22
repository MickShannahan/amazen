using System;
using System.Data;
using amazen.Models;
using Dapper;

namespace amazen.Repositories
{
  public class MerchantsRepository
  {
    private readonly IDbConnection _db;

    public MerchantsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal int Create(Merchant newMerchant)
    {
      string sql = @"
      INSERT INTO Merchants
      (  name, category, creatorId )
      VALUES
      (@Name, @Category, @CreatorId);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newMerchant);
    }

    internal Merchant GetOne(int id)
    {
      string sql = @"
      SELECT * FROM Merchants
      WHERE id = @id;";
      return _db.QueryFirstOrDefault<Merchant>(sql, new { id });
    }

    internal int Delete(int id)
    {
      string sql = @"
      DELETE FROM Merchants
      WHERE id = @id;";
      return _db.Execute(sql, new { id });
    }

    internal int Update(Merchant update)
    {
      string sql = @"
     UPDATE Merchants SET
     name = @Name,
     category = @Category
     WHERE id = @Id;";
      return _db.Execute(sql, update);
    }
  }
}