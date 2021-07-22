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
  public class ProductsController : ControllerBase
  {

    private readonly ProductsService _ps;
    private readonly AccountService _acs;

    public ProductsController(ProductsService ps, AccountService acs)
    {
      _ps = ps;
      _acs = acs;
    }

    [HttpGet]
    public ActionResult<List<ProductMerchantView>> GetAll()
    {
      try
      {
        return Ok(_ps.GetAll());
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    async public Task<ActionResult<Product>> Create([FromBody] Product newProduct)
    {
      try
      {
        Account account = await HttpContext.GetUserInfoAsync<Account>();
        newProduct.CreatorId = account.Id;
        return Ok(_ps.Create(newProduct));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}