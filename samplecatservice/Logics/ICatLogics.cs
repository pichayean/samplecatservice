using samplecatservice.Entities;

namespace samplecatservice.Logics
{
    public interface ICatLogics
    {
        Task<IEnumerable<CatEntity>> GetAllCatsAsync();
        Task<CatEntity> GetCatByIdAsync(Guid id);
        Task<IEnumerable<CatEntity>> GetYoungCatsAsync();
        Task<IEnumerable<CatEntity>> GetTeenCatsAsync();
        Task<IEnumerable<CatEntity>> GetOldCatsAsync();
        Task<CatEntity> NewCatAsync(CatEntity cat);
        Task UpdateCatAsync(CatEntity cat);
        Task RemoveCatAsync(string id);
    }
}