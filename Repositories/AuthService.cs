using backend.Migrations;
using backend.Models;
using bcrypt = BCrypt.Net.BCrypt;


namespace backend.Repositories;

public class AuthService : IAuthService
{

    private static ArkDbContext _context;

    public AuthService(ArkDbContext context)
    {
        _context = context;
    }

    public User CreateUser(User user)
    {
        _context.Add(user);
        _context.SaveChanges();
        return user;
    }

    public string SignIn(string userName, string password)
    {
        throw new NotImplementedException();
    }
}