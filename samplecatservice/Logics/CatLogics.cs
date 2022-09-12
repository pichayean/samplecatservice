using samplecatservice.Entities;
using samplecatservice.Repository;
using System.Data.Entity;

namespace samplecatservice.Logics
{
    public class CatLogics : ICatLogics
    {
        private readonly IRepository _catRepository;
        public CatLogics(IRepository catRepository)
        {
            _catRepository = catRepository;
        }

        public async Task<IEnumerable<CatEntity>> GetAllCatsAsync()
        {
            return await _catRepository.GetAsync();
        }

        public async Task<CatEntity> GetCatByIdAsync(Guid id)
        {
            var cat = (await _catRepository.GetAsync()).FirstOrDefault(_ => _.Id == id);
            if (cat == null)
                throw new Exception("This cat not found ^^!");
            return cat;
        }

        public async Task<CatEntity> NewCatAsync(CatEntity cat)
        {
            cat.Id = Guid.NewGuid();
            cat.CreatedDate = DateTime.Now;
            return await _catRepository.InsertAsync(cat);
        }

        public async Task RemoveCatAsync(string id)
        {
            var cat = (await _catRepository.GetAsync()).FirstOrDefault(_ => _.Id == new Guid(id));
            if (cat == null)
                throw new Exception("This cat not found ^^!");

            await _catRepository.RemoveAsync(cat);
        }

        public async Task UpdateCatAsync(CatEntity cat)
        {
            var catInRow = (await _catRepository.GetAsync()).FirstOrDefault(_ => _.Id == cat.Id);
            if (catInRow == null)
                throw new Exception("This cat not found ^^!");

            catInRow.Name = cat.Name;
            catInRow.Color = cat.Color;
            await _catRepository.UpdateAsync(catInRow);
        }

        public async Task<IEnumerable<CatEntity>> GetYoungCatsAsync()
        {
            return (await _catRepository.GetAsync())
                 .Where(_ => DbFunctions.DiffYears(_.CreatedDate, DateTime.Now) <= 3);
        }

        public async Task<IEnumerable<CatEntity>> GetTeenCatsAsync()
        {
            return (await _catRepository.GetAsync())
             .Where(_ => DbFunctions.DiffYears(_.CreatedDate, DateTime.Now) > 3
             && DbFunctions.DiffMonths(_.CreatedDate, DateTime.Now) <= 6);
        }

        public async Task<IEnumerable<CatEntity>> GetOldCatsAsync()
        {
            return (await _catRepository.GetAsync())
             .Where(_ => DbFunctions.DiffYears(_.CreatedDate, DateTime.Now) > 6);
        }
    }
}
