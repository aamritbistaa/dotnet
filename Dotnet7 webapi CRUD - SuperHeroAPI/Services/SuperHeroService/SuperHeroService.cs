using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        //private static List<SuperHero> superHeros = new List<SuperHero>
        //    {
        //        new SuperHero{Id= 1,Name = "SpiderName",FirstName= "Peter",LastName= "parker", Place="NY"},
        //        new SuperHero{Id=2, Name="DUmmy Boy", FirstName="Danny",LastName="Tummy", Place="China"}
        //    };

        private readonly DataContext _context;
        public SuperHeroService(DataContext context)
        {
            _context = context;
            
        }
        public async Task<List<SuperHero>> GetAllSuperHero()
        {
            var heros = await _context.Table_SuperHeros.ToListAsync();
            return heros;
        }

        public async Task<SuperHero?> GetByID(int id)
        {
            var item = await _context.Table_SuperHeros.FindAsync(id);

            if (item == null)
            {
                return null;
            }
            else
            {

                return item;

            }
        }
        public async Task<List<SuperHero>> AddSuperHero(SuperHero obj)
        {
            await _context.Table_SuperHeros.AddAsync(obj);
            await _context.SaveChangesAsync();
            return await _context.Table_SuperHeros.ToListAsync();
        }

        public async Task<List<SuperHero>?> DeleteSuperHero(int id)
        {

            var hero = await _context.Table_SuperHeros.FindAsync(id);
            if (hero == null)
            {
                return null;
            }
            else
            {
                _context.Table_SuperHeros.Remove(hero);
                await _context.SaveChangesAsync();
                return await _context.Table_SuperHeros.ToListAsync();

            }
        }

        

        public async Task<List<SuperHero>?> UpdateSuperHero(int id, SuperHero request)
        {

            var hero = await _context.Table_SuperHeros.FindAsync(id);

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

                await _context.SaveChangesAsync();
                return await _context.Table_SuperHeros.ToListAsync();
            }
        }
    }
}
