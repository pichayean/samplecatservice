using samplecatservice.Entities;

namespace samplecatservice.Repository;
public interface IRepository
{
    public CatEntity Insert(CatEntity cat);

    public void Update(CatEntity cat);

    public void Remove(CatEntity cat);

    public IEnumerable<CatEntity> Get();
}