using System.ComponentModel.DataAnnotations;

namespace MembersAPI
{
    public class Register : IValidatableObject

    {
        public int ID { get; set; }
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }

        [Range(3, 99)]
        public string Password { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Password.Length < 3)
            {
                yield return new ValidationResult("Parola minimum 3 karakterden oluşmalı");
            }
        }
    }
}
