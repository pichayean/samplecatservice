using samplecatservice.Entities;
using StackExchange.Redis;
using System.Text.Json;

namespace samplecatservice.Repository;
public class CatRepository: IRepository
{
    private readonly IDatabase _db;
    private readonly string REDIS_CAT_KEY = "samplecatsservice";

    public CatRepository(IConnectionMultiplexer redis)
    {
        _db = redis.GetDatabase();
    }

    public async Task<CatEntity> InsertAsync(CatEntity cat)
    {
        var oldCats = (await GetAsync()).ToList();
        oldCats.Add(cat);
        var cats = JsonSerializer.Serialize(oldCats);
        await SetDataAsync(cats);
        return cat;
    }

    public async Task UpdateAsync(CatEntity cat)
    {
        var oldCats = (await GetAsync()).ToList();
        oldCats.Remove(oldCats.First(_=>_.Id == cat.Id));
        oldCats.Add(cat);
        var cats = JsonSerializer.Serialize(oldCats);
        await SetDataAsync(cats);
    }

    public async Task RemoveAsync(CatEntity cat)
    {
        var oldCats = (await GetAsync()).ToList();
        oldCats.Remove(oldCats.First(_=>_.Id == cat.Id));
        var cats = JsonSerializer.Serialize(oldCats);
        await SetDataAsync(cats);
    }

    public async Task<IEnumerable<CatEntity>> GetAsync()
    {
        var catsData = await _db.StringGetAsync(REDIS_CAT_KEY);
        if (!catsData.HasValue)
            return new List<CatEntity>();

        var cats = JsonSerializer.Deserialize<IEnumerable<CatEntity>>(catsData.ToString());
        if (cats == null)
            return new List<CatEntity>();
        return cats;
    }

    private async Task SetDataAsync(string data) => await _db.StringSetAsync(REDIS_CAT_KEY, data);
}