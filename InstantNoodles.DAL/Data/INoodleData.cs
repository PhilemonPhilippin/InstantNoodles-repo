using InstantNoodles.DAL.Models;

namespace InstantNoodles.DAL.Data;
public interface INoodleData
{
    Task DeleteNoodle(int id);
    Task<NoodleModel?> GetNoodle(int id);
    Task<IEnumerable<NoodleModel>> GetNoodles();
    Task InsertNoodle(NoodleModel noodle);
    Task UpdateNoodle(NoodleModel noodle);
}