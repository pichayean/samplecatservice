using samplecatservice.Entities;

namespace samplecatservice.api.Models
{
    public class CatResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public DateTime CreatedDate { get; set; }

        public CatResponse(CatEntity cat)
        {
            this.Id = cat.Id;
            this.Name = cat.Name;
            this.Color = cat.Color;
            this.CreatedDate = cat.CreatedDate;
        }
    }
}
