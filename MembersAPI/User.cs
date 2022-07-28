

using System.ComponentModel.DataAnnotations;

namespace MembersAPI
{
    public class User
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        
    }
}
