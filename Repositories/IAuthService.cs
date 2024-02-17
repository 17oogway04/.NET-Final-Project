using backend.Models;

namespace backend.Repositories;

public interface IAuthService{
    User CreateUser(User user);
    string SignIn(string userName, string password);

    
}