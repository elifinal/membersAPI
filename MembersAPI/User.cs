using System.ComponentModel.DataAnnotations;

namespace MembersAPI
{
    public class User : IValidatableObject
    {
        [Required]
        public string Email { get; set; }
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
