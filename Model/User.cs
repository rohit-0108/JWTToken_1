namespace JWTToken_1.Model
{
    public class User
    {
        public long Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string Role { get; set; }
    }
}
