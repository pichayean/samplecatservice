using samplecatservice.Entities;

namespace samplecatservice.api.Models
{
    public class UpdateCatRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public DateTime CreatedDate { get; set; }
        public CatEntity ToEntity()
        {
            return new CatEntity()
            {
                Id = this.Id,
                Name = this.Name,
                Color = this.Color,
                CreatedDate = this.CreatedDate
            };
        }
    }
}
