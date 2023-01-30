using ToysAndGamesAPI.Entities;

namespace ToysAndGamesAPI.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? AgeRestriction { get; set; }
        public string Company { get; set; }
        public decimal Price { get; set; }
        public int ProductImageId { get; set; }
        public string ImageName { get; set; }
        public byte[] ImageFile { get; set; }        
    }
}
