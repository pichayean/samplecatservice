using samplecatservice.Entities;
using System.Text.Json;

namespace samplecatservice.Repository;
public class CatRepository
{
    private List<CatEntity> Cats;

    public CatRepository()
    {
        if (Cats == null) 
            Cats = new List<CatEntity>();
    }

    public CatEntity Insert(CatEntity cat)
    {
        Cats.Add(cat);
        return cat;
    }

    public void Update(CatEntity cat)
    {
        var _cat = Cats.First(_ => _.Id.Equals(cat.Id));
        _cat.Name = cat.Name;
        _cat.Color = cat.Color;
    }

    public void Remove(CatEntity cat)
    {
        Cats.Remove(cat);
    }

    public IEnumerable<CatEntity> Get()
    {
        return Cats;
    }
}