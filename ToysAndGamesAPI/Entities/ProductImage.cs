using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToysAndGamesAPI.Entities
{
    [Owned]
    public class ProductImage
    {
        [Key]
        public int Id { get; set; }
        public string ImageName { get; set; }
        public byte[] ImageFile { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
