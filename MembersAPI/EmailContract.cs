using System.ComponentModel.DataAnnotations;

namespace MembersAPI
{
    public class EmailContract
    {
      
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

    }
}
