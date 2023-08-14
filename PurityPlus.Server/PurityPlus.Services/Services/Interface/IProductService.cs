using PurityPlus.Database.Entity;
using PurityPlus.Services.Classes;
using PurityPlus.Services.DTO;
using PurityPlus.Services.FilterParams;

namespace PurityPlus.Services.Interface
{
    public interface IProductService
    {
        PagedResponse<ProductDTO> GetProducts(PaginationFilter paginationFilter, ProductFilter productFilter);

        Task<bool> AddProduct(ProductDTO product);
        ProductDTO UpdateProduct(Product product);
        ProductDTO GetProductById(Guid ProductId);
    }
}
