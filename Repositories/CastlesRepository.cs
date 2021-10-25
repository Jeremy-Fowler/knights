using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using knights.Models;

namespace knights.Repositories
{
  public class CastlesRepository
  {
    private readonly IDbConnection _db;

    public CastlesRepository(IDbConnection db)
    {
      _db = db;
    }

    public List<Castle> Get()
    {
      return _db.Query<Castle>("SELECT * FROM castles;").ToList();
    }

    public Castle Get(int id)
    {
      return _db.QueryFirstOrDefault<Castle>("SELECT * FROM castles WHERE id = @id", new { id });
    }

    public Castle Create(Castle data)
    {
      var sql = @"
      INSERT INTO castles(
        name
      )
      VALUES(
        @Name
      );
      SELECT LAST_INSERT_ID();
      ";
      var id = _db.ExecuteScalar<int>(sql, data);
      data.Id = id;
      return data;
    }
  }
}