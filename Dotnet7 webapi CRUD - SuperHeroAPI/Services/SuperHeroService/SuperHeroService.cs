using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private static List<SuperHero> superHeros = new List<SuperHero>
            {
                new SuperHero{Id= 1,Name = "SpiderName",FirstName= "Peter",LastName= "parker", Place="NY"},
                new SuperHero{Id=2, Name="DUmmy Boy", FirstName="Danny",LastName="Tummy", Place="China"}
            };
        public List<SuperHero> AddSuperHero(SuperHero obj)
        {
            superHeros.Add(obj);
            return superHeros;
        }

        public List<SuperHero>? DeleteSuperHero(int id)
        {

            var hero = superHeros.Find(x => x.Id == id);
            if (hero == null)
            {
                return null;
            }
            else
            {

                superHeros.Remove(hero);
                return superHeros;

            }
        }

        public List<SuperHero> GetAllSuperHero()
        {
            return superHeros;
        }

        public List<SuperHero>? GetByID(int id)
        {
            var item = superHeros.FindAll(x => x.Id == id);

            if (item == null)
            {
                return null;
            }
            else
            {

                return item;

            }
        }

        public List<SuperHero>? UpdateSuperHero(int id, SuperHero request)
        {

            var hero = superHeros.Find(x => x.Id == id);

            if (hero == null)
            {
                return null;
            }
            else
            {
                hero.Name = request.Name;
                hero.FirstName = request.FirstName;
                hero.LastName = request.LastName;
                hero.Place = request.Place;
                return superHeros;
            }
        }
    }
}
