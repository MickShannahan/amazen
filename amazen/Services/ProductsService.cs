using System;
using System.Collections.Generic;
using amazen.Models;
using amazen.Repositories;

namespace amazen.Services
{
  public class ProductsService
  {
    private readonly ProductsRepository _repo;

    public ProductsService(ProductsRepository repo)
    {
      _repo = repo;
    }

    internal List<ProductMerchantView> GetAll()
    {
      return _repo.GetAll();
    }
    internal Product Create(Product newProduct)
    {
      int id = _repo.Create(newProduct);
      newProduct.Qty = newProduct.Qty > 0 ? newProduct.Qty : 10;
      newProduct.Id = id;
      return newProduct;
    }

    internal List<ProductMerchantView> GetProductsByMerchantId(int id)
    {
      return _repo.GetProductsByMerchantId(id);
    }
  }
}