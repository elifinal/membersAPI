using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MembersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private static Register rg = new Register();


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
        public async Task<ActionResult> LoginAsync(Register register)
        {
            var checkUser = await _context.Set<Register>().FirstOrDefaultAsync(x => x.Password == register.Password);
            

        }


    }
}
