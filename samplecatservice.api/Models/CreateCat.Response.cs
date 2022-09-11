using samplecatservice.Entities;

namespace samplecatservice.api.Models
{
    public class CreateCatResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public DateTime CreatedDate { get; set; }
        public CreateCatResponse(CatEntity cat)
        {
            this.Id = cat.Id;
            this.Name = cat.Name;
            this.Color = cat.Color;
            this.CreatedDate = cat.CreatedDate;
        }

        public CatEntity ToEntity()
        {
            return new CatEntity()
            {
                Id = this.Id,
                Name = this.Name,
                Color = this.Color,
                CreatedDate = this.CreatedDate,
            };
        }
    }
}
