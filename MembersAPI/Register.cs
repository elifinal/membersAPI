namespace MembersAPI
{
    public class Register
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string FirsName { get; set; } 
        public string LastName { get; set; }

        // password veri tipi değiştirildi yeni db oluşturuldu.[elif]
        public string Password { get; set; }

    }
}
