using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ToysAndGamesAPI.Data;
using ToysAndGamesAPI.DTOs;

namespace ToysAndGamesAPI.Entities
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public ProductRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> AllProducts()
        {
          return await _dataContext.Products
                .ProjectTo<ProductDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

        }

        public void AddProduct(ProductDTO productDto)
        {
           
                Product product = _mapper.Map<Product>(productDto);
                _dataContext.Products.Add(product);           

        }

        public void DeleteProduct(int Id)
        {
            _dataContext.Products.Remove(_dataContext.Products.Find(Id));
            
        }

        public async Task<ProductDTO> GetProduct (int Id)
        {
            return await _dataContext.Products                
                .Where(prod => prod.Id == Id)
                .ProjectTo<ProductDTO>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public void UpdateProduct(ProductDTO productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            _dataContext.Products.Update(product);            
        }

        public async Task<bool> SaveAll()
        {           
            return await _dataContext.SaveChangesAsync() > 0;
          
        }
            
    }
}
