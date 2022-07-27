using System.ComponentModel.DataAnnotations;

namespace MembersAPI
{
    public class EmailRequestHist
    {
        public int Id  { get; set; }
        [Required]
        public string UserEmail { get; set; }
        public DateTime RequestTime { get; set; }

    }
}
