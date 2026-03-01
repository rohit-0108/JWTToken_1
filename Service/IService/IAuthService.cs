using JWTToken_1.Model;

namespace JWTToken_1.Service.IService
{
    public interface IAuthService
    {
        Task<string> Register(User user);
        Task<object> Login(LoginDto loginDto);
        Task<object> RefreshToken(string refreshToken);
    }
}
