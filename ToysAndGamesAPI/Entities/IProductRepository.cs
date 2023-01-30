using ToysAndGamesAPI.DTOs;

namespace ToysAndGamesAPI.Entities
{
    public interface IProductRepository
    {
        Task<List<ProductDTO>> AllProducts();

        Task<ProductDTO> GetProduct(int Id);

        Task<bool> SaveAll();

        void AddProduct(ProductDTO product);

        void UpdateProduct(ProductDTO product);

        void DeleteProduct(int Id);
    }
}
