using System.ComponentModel.DataAnnotations;

namespace Members.Contract
{
    public class EmailContract
    {
      
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

    }
}
