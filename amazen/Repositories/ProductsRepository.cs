using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using amazen.Models;
using Dapper;

namespace amazen.Repositories
{
  public class ProductsRepository
  {
    private readonly IDbConnection _db;

    public ProductsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal List<ProductMerchantView> GetAll()
    {
      string sql = @"
      SELECT 
      p.*,
      m.*
      FROM products p
      Join merchants m ON p.merchantId = m.id;";
      return _db.Query<ProductMerchantView, Merchant, ProductMerchantView>(sql, (p, m) =>
      {
        p.Merchant = m;
        return p;
      }, splitOn: "id").ToList();
    }

    internal int Create(Product newProduct)
    {
      string sql = @"
      INSERT INTO products
      (name,price,imgUrl,qty,merchantId,creatorId)
      VALUES
      (@Name, @Price, @ImgUrl, 10, @MerchantId, @CreatorId);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newProduct);
    }

    internal Product GetOne(int id)
    {
      string sql = @"
      SELECT * FROM products
      WHERE id = @id;
      ";
      return _db.QueryFirstOrDefault<Product>(sql, new { id });
    }

    internal List<ProductMerchantView> GetProductsByMerchantId(int id)
    {
      string sql = @"
      SELECT 
      p.*,
      m.*,
      a.*
      FROM products p
      Join merchants m ON p.merchantId = m.id
      Join accounts a ON p.creatorId = a.id
      WHERE p.merchantId = @id;";
      return _db.Query<ProductMerchantView, Merchant, Account, ProductMerchantView>(sql, (p, m, a) =>
       {
         p.Merchant = m;
         p.Creator = a;
         return p;
       }, new { id }, splitOn: "id").ToList();
    }

    internal int Update(Product update)
    {
      string sql = @"
      UPDATE products SET 
      name = @Name,
      price = @Price,
      imgUrl = @ImgUrl,
      qty = @Qty
      WHERE id = @Id;";
      return _db.Execute(sql, update);
    }
  }
}