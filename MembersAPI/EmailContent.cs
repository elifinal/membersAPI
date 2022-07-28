using System.ComponentModel.DataAnnotations;

namespace MembersAPI
{
    public class EmailContent
    {
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }

    }
}
