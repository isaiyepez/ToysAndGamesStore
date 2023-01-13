namespace ToysAndGamesAPI.Entities
{
    public interface IProductRepository
    {
        Task<List<Product>> AllProducts();

        Task<Product> GetProduct(int Id);

        Task<bool> SaveAll();

        void AddProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(int Id);
    }
}
