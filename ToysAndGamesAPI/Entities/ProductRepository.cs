using Microsoft.EntityFrameworkCore;
using ToysAndGamesAPI.Data;

namespace ToysAndGamesAPI.Entities
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dataContext;


        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        Task<List<Product>> IProductRepository.AllProducts()
        {
          return _dataContext.Products.ToListAsync();

        }

        public void AddProduct(Product product)
        {
            _dataContext.Products.Add(product);           
        }

        public void DeleteProduct(int Id)
        {
            _dataContext.Products.Remove(_dataContext.Products.Find(Id));
            
        }

        public Task<Product> GetProduct(int Id)
        {
            return _dataContext.Products.FirstOrDefaultAsync(prod => prod.Id == Id);
        }

        public void UpdateProduct(Product product)
        {
            _dataContext.Products.Update(product);
            
        }

        public async Task<bool> SaveAll()
        {           
            return await _dataContext.SaveChangesAsync() > 0;
          
        }
            
    }
}
