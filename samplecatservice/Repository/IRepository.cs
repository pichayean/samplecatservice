using samplecatservice.Entities;

namespace samplecatservice.Repository;
public interface IRepository
{
    public Task<CatEntity> InsertAsync(CatEntity cat);

    public Task UpdateAsync(CatEntity cat);

    public Task RemoveAsync(CatEntity cat);

    public Task<IEnumerable<CatEntity>> GetAsync();
}