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
            try
            {
                _context.registers2.Add(register);
                await _context.SaveChangesAsync();
                return Ok(await _context.registers2.ToListAsync());
            }
            catch (Exception e)
            {
                return Ok(e);
            }
           
        }

        [HttpPost("Login")]
        // login model
       // 
        public async Task<ActionResult> LoginAsync(Register register)
        {
            var checkUser = await _context.Set<Register>().FirstOrDefaultAsync(x => x.Password == register.Password);

            return null;
        }

        //Get all users [elif]
        [HttpGet]

        public async Task<ActionResult<List<Register>>> GetUsers()
        {
            try
            {
                return Ok(await _context.registers2.ToListAsync());

            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }

        // User search by Email [elif]
        [HttpGet("Email")]
        
        public async Task<ActionResult<Register>> GetUser(string Email)
        {
            asdas();
            var user = await _context.registers2.FirstOrDefaultAsync(h => h.Email == Email);
            //if user exist
            if (user == null)
                return StatusCode(409, "User not found.");// NotFound();

            return Ok(user);
        }








    }
}
