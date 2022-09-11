using samplecatservice.Entities;

namespace samplecatservice.Logics
{
    public interface ICatLogics
    {
        IEnumerable<CatEntity> GetAllCats();
        CatEntity GetCatById(Guid id);
        IEnumerable<CatEntity> GetYoungCats();
        IEnumerable<CatEntity> GetTeenCats();
        IEnumerable<CatEntity> GetOldCats();
        CatEntity NewCat(CatEntity cat);
        void UpdateCat(CatEntity cat);
        void RemoveCat(string id);
    }
}