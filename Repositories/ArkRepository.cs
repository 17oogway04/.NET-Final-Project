using backend.Migrations;
using backend.Models;

namespace backend.Repositories;

public class ArkRepository : IArkRepository
{

    public readonly ArkDbContext _context;

    public ArkRepository(ArkDbContext context)
    {
        _context = context;
    }

    public Arks CreateArk(Arks newArk)
    {
        _context.Arks.Add(newArk);
        _context.SaveChanges();
        return newArk;
    }

    public void DeleteArkById(int userId)
    {
        var arks = _context.Arks.Find(userId);
        if(arks != null){
            _context.Arks.Remove(arks);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Arks> GetAllArks()
    {
        return _context.Arks.ToList();
    }

    public Arks? GetArkById(int userId)
    {
        return _context.Arks.SingleOrDefault(u => u.ArkId == userId);
    }

    public Arks? UpdateArk(Arks newArk)
    {
        var originalArk = _context.Arks.Find(newArk.ArkId);
        if(originalArk != null){
            originalArk.Name = newArk.Name;
            originalArk.Content = newArk.Content;
            originalArk.ImgUrl = newArk.ImgUrl;
            originalArk.Location = newArk.Location;
            _context.SaveChanges();
        }

        return originalArk;
    }
}