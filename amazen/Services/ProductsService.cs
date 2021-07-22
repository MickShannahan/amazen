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

    public Product GetOne(int id)
    {
      Product product = _repo.GetOne(id);
      if (product != null)
      {
        return product;
      }
      throw new Exception("That object by id does not exist");
    }

    internal Product Update(Product update)
    {
      Product original = GetOne(update.Id);
      if (original.CreatorId == update.CreatorId)
      {
        update.Name = update.Name ?? original.Name;
        update.Price = update.Price > 0.00 ? update.Price : original.Price;
        update.ImgUrl = update.ImgUrl ?? original.ImgUrl;
        update.Qty = original.Qty;
        if (_repo.Update(update) > 0)
        {
          return update;
        }
        throw new Exception("something bad happened, might want call past mick");
      }
      throw new Exception("you are not allowe to update this");
    }
  }
}