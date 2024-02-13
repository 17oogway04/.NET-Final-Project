using backend.Migrations;
using backend.Models;
using bcrypt = BCrypt.Net.BCrypt;


namespace backend.Repositories;

public class AuthService : IAuthService
{

    private static ArkDbContext _context;
    private static IConfiguration _config;

    public AuthService(ArkDbContext context, IConfiguration config)
    {
        _config = config;
        _context = context;
    }

    public User CreateUser(User user)
    {
        var passwordHash = bcrypt.HashPassword(user.Password);
        user.Password = passwordHash;

        _context.Add(user);
        _context.SaveChanges();
        return user;
    }

    public string SignIn(string userName, string password)
    {
        var user = _context.Users.SingleOrDefault(x => x.UserName == userName);
        var verified = false;

        if(user != null)
        {
            verified = bcrypt.Verify(password, user.Password);
        }

        if(user == null || !verified)
        {
            return String.Empty;
        }

        return "";
    }
}