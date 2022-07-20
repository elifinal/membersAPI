using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MembersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heros = new List<SuperHero>
            {

                new SuperHero{
                    Id = 1,
                    Name="kadir",
                    FirsName = "corleone",
                    LastName = "avşar",
                    Place ="gop"

                },

                new SuperHero{
                    Id = 2,
                    Name="Iron Man",
                    FirsName = "Tony",
                    LastName = "Stark",
                    Place ="Long"

                }
            };

        private readonly DataContext _context;
        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(await _context.superHeroes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = await _context.superHeroes.FindAsync(id);
            if (hero == null)
                return BadRequest("Kahraman yok");
            return Ok(hero);

        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> Post(SuperHero hero)
        {

            _context.superHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return Ok(await _context.superHeroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero req)
        {
            var hero = heros.Find(x => x.Id == req.Id);
            if (hero == null)
                return BadRequest("Kahraman yok");

            hero.Name = req.Name;
            hero.FirsName = req.FirsName;
            hero.LastName = req.LastName;
            hero.Place = req.Place;
            return Ok(heros);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            var hero = heros.Find(x => x.Id == id);
            if (hero == null)
                return BadRequest("Kahraman yok");

            heros.Remove(hero);
            return Ok(hero);
        }




    }
}
