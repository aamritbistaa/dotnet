using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
                List<SuperHero> GetAllSuperHero();
        List<SuperHero>? GetByID(int id);
        List<SuperHero> AddSuperHero(SuperHero obj);
        List<SuperHero>? UpdateSuperHero(int id, SuperHero request);
        List<SuperHero>? DeleteSuperHero(int id);

    }
}
