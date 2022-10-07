using InstantNoodles.DAL.DbAccess;
using InstantNoodles.DAL.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantNoodles.DAL.Data;
public class NoodleRepository : INoodleRepository
{
	private readonly DapperContext _context;

	public NoodleRepository(DapperContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<NoodleModel>> GetNoodles()
	{
		string query = "SELECT * FROM [Noodle]";

		using IDbConnection connection = _context.CreateConnection();

		var noodles = await connection.QueryAsync<NoodleModel>(query);
		return noodles.ToList();

	}

	public async Task<NoodleModel> GetNoodle(int id)
	{
		string query = "SELECT * FROM [Noodle] WHERE NoodleID = @Id";

        using IDbConnection connection = _context.CreateConnection();

		var noodle = await connection.QuerySingleOrDefaultAsync<NoodleModel>(query, new { id });
		return noodle;
    }
}
