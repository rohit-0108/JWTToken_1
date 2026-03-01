namespace JWTToken_1.Model
{
    public class RefreshToken
    {
        public int Id { get; set; }
        // ramdonly generated string that will be used to identify the refresh token
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsRevoked { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
