using InstantNoodles.DAL.DbAccess;
using InstantNoodles.DAL.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

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

	public async Task<NoodleModel> InsertNoodle(NoodleModel noodle)
	{
		var query = "INSERT INTO [Noodle] (Name, Meat, Vegetable, Sauce) VALUES (@Name, @Meat, @Vegetable, @Sauce)" + 
			"SELECT CAST(SCOPE_IDENTITY() as int)";

		var parameters = new DynamicParameters();
		parameters.Add("Name", noodle.Name, DbType.String);
        parameters.Add("Meat", noodle.Meat, DbType.String);
        parameters.Add("Vegetable", noodle.Vegetable, DbType.String);
        parameters.Add("Sauce", noodle.Sauce, DbType.Boolean);

		using var connection = _context.CreateConnection();

		int id = await connection.QuerySingleAsync<int>(query, parameters);

		var createdNoodle = new NoodleModel()
		{
			NoodleID = id,
			Name = noodle.Name,
			Meat = noodle.Meat,
			Vegetable = noodle.Vegetable,
			Sauce = noodle.Sauce,
		};

		return createdNoodle;
	}

	public async Task UpdateNoodle(int id, NoodleModel noodle)
	{
		var query = "UPDATE [Noodle] SET Name = @Name, Meat = @Meat, Vegetable = @Vegetable, Sauce = @Sauce WHERE NoodleID = @Id";

		var parameters = new DynamicParameters();
		parameters.Add("Id", id, DbType.Int32);
		parameters.Add("Name", noodle.Name, DbType.String);
        parameters.Add("Meat", noodle.Meat, DbType.String);
        parameters.Add("Vegetable", noodle.Vegetable, DbType.String);
        parameters.Add("Sauce", noodle.Sauce, DbType.Boolean);

		using var connection = _context.CreateConnection();

		await connection.ExecuteAsync(query, parameters);
    }
	
	public async Task DeleteNoodle(int id)
	{
		var query = "DELETE FROM [Noodle] WHERE NoodleID = @Id";

        using var connection = _context.CreateConnection();

		await connection.ExecuteAsync(query, new { id });
    }
}
