using InstantNoodles.DAL.DbAccess;
using InstantNoodles.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantNoodles.DAL.Data;
public class NoodleData
{
	private readonly ISqlDataAccess _db;

	public NoodleData(ISqlDataAccess db)
	{
		_db = db;
	}

	public Task<IEnumerable<NoodleModel>> GetNoodles()
	{
		return _db.LoadData<NoodleModel, dynamic>("PPSP_GetAll", new { });
	}
	public async Task<NoodleModel?> GetNoodle(int id)
	{
		var results = await _db.LoadData<NoodleModel, dynamic>("PPSP_Get", new {NoodleID = id});
		return results.FirstOrDefault();
	}
	public Task InsertNoodle(NoodleModel noodle)
	{
		return _db.SaveData("PPSP_Create", new { Name = noodle.Name, Meat = noodle.Meat, Vegetable = noodle.Vegetable, Sauce = noodle.Sauce });
	}
	public Task UpdateNoodle(NoodleModel noodle)
	{
		return _db.SaveData("PPSP_Update", noodle);
	}
	public Task DeleteNoodle(int id)
	{
		return _db.SaveData("PPSP_Delete", new { NoodleID = id });
	}
}
