using samplecatservice.Entities;
using samplecatservice.Repository;
using System.Data.Entity;

namespace samplecatservice.Logics
{
    public class CatLogics : ICatLogics
    {
        private readonly CatRepository _catRepository;
        public CatLogics(CatRepository catRepository)
        {
            _catRepository = catRepository;
        }

        public IEnumerable<CatEntity> GetAllCats()
        {
            return _catRepository.Get();
        }

        public CatEntity GetCatById(Guid id)
        {
            var cat = _catRepository.Get().FirstOrDefault(_ => _.Id == id);
            if (cat == null)
                throw new Exception("This cat not found ^^!");
            return cat;
        }

        public CatEntity NewCat(CatEntity cat)
        {
            cat.Id = Guid.NewGuid();
            cat.CreatedDate = DateTime.Now;
            return _catRepository.Insert(cat);
        }

        public void RemoveCat(string id)
        {
            var cat = _catRepository.Get().FirstOrDefault(_ => _.Id == new Guid(id));
            if (cat == null)
                throw new Exception("This cat not found ^^!");

            _catRepository.Remove(cat);
        }

        public void UpdateCat(CatEntity cat)
        {
            var catInRow = _catRepository.Get().FirstOrDefault(_ => _.Id == cat.Id);
            if (catInRow == null)
                throw new Exception("This cat not found ^^!");

            catInRow.Name = cat.Name;
            catInRow.Color = cat.Color;
            _catRepository.Update(catInRow);
        }

        public IEnumerable<CatEntity> GetYoungCats()
        {
            return _catRepository.Get()
             .Where(_ => DbFunctions.DiffYears(_.CreatedDate, DateTime.Now) <= 3);
        }

        public IEnumerable<CatEntity> GetTeenCats()
        {
            return _catRepository.Get()
             .Where(_ => DbFunctions.DiffYears(_.CreatedDate, DateTime.Now) > 3
             && DbFunctions.DiffMonths(_.CreatedDate, DateTime.Now) <= 6);
        }

        public IEnumerable<CatEntity> GetOldCats()
        {
            return _catRepository.Get()
             .Where(_ => DbFunctions.DiffYears(_.CreatedDate, DateTime.Now) > 6);
        }
    }
}
