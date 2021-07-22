using System;
using amazen.Models;
using amazen.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace amazen.Services
{
  public class MerchantsService
  {
    private readonly MerchantsRepository _repo;

    public MerchantsService(MerchantsRepository repo)
    {
      _repo = repo;
    }

    public Merchant Create(Merchant newMerchant)
    {
      int id = _repo.Create(newMerchant);
      newMerchant.Id = id;
      return newMerchant;
    }

    public Merchant GetOne(int id)
    {
      Merchant merchant = _repo.GetOne(id);
      if (merchant != null)
      {
        return merchant;
      }
      throw new Exception("That object by id does not exist");
    }

    internal string Delete(int id, string userId)
    {
      Merchant merchant = GetOne(id);
      if (merchant?.CreatorId == userId)
      {
        if (_repo.Delete(id) > 0)
        {
          return "She gone";
        }
        return "Bad Merchant Id";
      }
      return "You are not the owner of that";
    }

    internal Merchant Update(int id, Merchant update)
    {
      Merchant original = GetOne(id);
      if (original.CreatorId == update.CreatorId)
      {
        original.Name = update.Name != null ? update.Name : original.Name;
        original.Category = update.Category != null ? update.Category : original.Category;

        if (_repo.Update(update) > 0)
        {
          return update;
        }
        throw new Exception("id something bad happened here with the SQL");

      }
      throw new Exception("you are not the owner");
    }
  }
}