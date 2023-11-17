using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> GetAllSuperHero();
        Task<SuperHero?> GetByID(int id);
        Task<List<SuperHero>> AddSuperHero(SuperHero obj);
        Task<List<SuperHero>?> UpdateSuperHero(int id, SuperHero request);
        Task<List<SuperHero>?> DeleteSuperHero(int id);

    }
}
