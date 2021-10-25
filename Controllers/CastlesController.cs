using System.Collections.Generic;
using knights.Models;
using knights.Services;
using Microsoft.AspNetCore.Mvc;

namespace knights.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CastlesController : ControllerBase
  {
    private readonly CastlesService _cs;

    public CastlesController(CastlesService cs)
    {
      _cs = cs;
    }

    [HttpGet]
    public ActionResult<List<Castle>> GetAllCastles()
    {
      try
      {
         var castles = _cs.Get();
         return Ok(castles);  
      }
      catch (System.Exception e)
      {
          
          return BadRequest(e.Message);
      }
    }
    [HttpGet("{castleId}")]
    public ActionResult<Castle> GetCastleById(int castleId)
    {
      try
      {
          var castle = _cs.Get(castleId);
          return Ok(castle); 
      }
      catch (System.Exception e)
      {
          
          return BadRequest(e.Message);
      }
    }
    [HttpPost]
    public ActionResult<Castle> CreateCastle([FromBody] Castle data)
    {
      try
      {
          var castle = _cs.Create(data);
          return Ok(castle); 
      }
      catch (System.Exception e)
      {
          
          return BadRequest(e.Message);
      }
    }
  }
}