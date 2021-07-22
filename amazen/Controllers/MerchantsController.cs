using System.Collections.Generic;
using System.Threading.Tasks;
using amazen.Models;
using amazen.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace amazen.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class MerchantsController : ControllerBase
  {
    private readonly MerchantsService _ms;

    private readonly AccountService _acs;

    private readonly ProductsService _ps;

    public MerchantsController(MerchantsService ms, AccountService acs, ProductsService ps)
    {
      _ms = ms;
      _acs = acs;
      _ps = ps;
    }

    [HttpPost]
    [Authorize]
    async public Task<ActionResult<Merchant>> Create([FromBody] Merchant newMerchant)
    {
      try
      {
        Account account = await HttpContext.GetUserInfoAsync<Account>();
        newMerchant.CreatorId = account.Id;
        return Ok(_ms.Create(newMerchant));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpGet("{id}")]
    public ActionResult<Merchant> GetOne(int id)
    {
      try
      {
        return Ok(_ms.GetOne(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/products")]
    public ActionResult<List<ProductMerchantView>> GetProductsByMerchantId(int id)
    {
      try
      {
        return Ok(_ps.GetProductsByMerchantId(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    async public Task<ActionResult<string>> Delete(int id)
    {
      try
      {
        Account account = await HttpContext.GetUserInfoAsync<Account>();
        return Ok(_ms.Delete(id, account.Id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    async public Task<ActionResult<Merchant>> Update(int id, [FromBody] Merchant update)
    {
      try
      {
        Account account = await HttpContext.GetUserInfoAsync<Account>();
        update.CreatorId = account.Id;
        update.Id = id;
        return Ok(_ms.Update(id, update));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }


}