namespace FlickClick_ClassLibary.Models
{
    public class UserModel
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string TelefonNummer { get; set; }
        public bool IsMember { get; set; } = true;
        public bool IsManager { get; set; } = false;
    }
}
