using backend.Models;

namespace backend.Repositories;

public interface IArkRepository
{
    IEnumerable<Arks> GetAllArks();
    Arks? GetArkById(int userId);
    Arks CreateArk(Arks newArk);
    Arks? UpdateArk(Arks newArk);
    void DeleteArkById(int userId);
    
    User? GetUserById(int userId);

}