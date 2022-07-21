using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MembersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {

 
        private readonly DataContext _context;

        public RegisterController(DataContext context)
        {
            _context = context;
        }



        [HttpPost]
        public async Task<ActionResult> RegisterAsync(Register register)
        {
            _context.registers.Add(register);
            await _context.SaveChangesAsync();
            return Ok(await _context.registers.ToListAsync());
        }

        [HttpPost("Login")]
        // login model
       // 
        public async Task<ActionResult> LoginAsync(User user)
        {
            var checkUser = await _context.Set<Register>().FirstOrDefaultAsync(x => x.Password == user.Password && x.Email == user.Email);

            if (checkUser != null)
            {
                return Ok(200);
            }
            else 
            {
                return BadRequest("Kişi yok");
            }

        }


    }
}
