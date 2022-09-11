using samplecatservice.Entities;

namespace samplecatservice.api.Models
{
    public class CreateCatRequest
    {
        public string Name { get; set; }
        public string Color { get; set; }

        public CatEntity ToEntity()
        {
            return new CatEntity()
            {
                Name = this.Name,
                Color = this.Color,
            };
        }
    }
}
