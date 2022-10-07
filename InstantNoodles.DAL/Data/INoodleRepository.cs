using InstantNoodles.DAL.Models;

namespace InstantNoodles.DAL.Data;
public interface INoodleRepository
{
    Task<IEnumerable<NoodleModel>> GetNoodles();
    Task<NoodleModel> GetNoodle(int id);
}