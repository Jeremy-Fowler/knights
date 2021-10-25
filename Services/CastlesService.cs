using System.Collections.Generic;
using knights.Models;
using knights.Repositories;

namespace knights.Services
{
  public class CastlesService
  {
    private readonly CastlesRepository _cr;

    public CastlesService(CastlesRepository cr)
    {
      _cr = cr;
    }

    public List<Castle> Get()
    {
      return _cr.Get();
    }

    public Castle Get(int id)
    {
      return _cr.Get(id);
    }

    public Castle Create(Castle data)
    {
      return _cr.Create(data);
    }
  }
}