using AutoMapper;
using PurityPlus.Database.Entity;
using PurityPlus.Database.Repository;
using PurityPlus.Services.Classes;
using PurityPlus.Services.DTO;
using PurityPlus.Services.FilterParams;
using PurityPlus.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurityPlus.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public IAwsS3Service _awsS3Service { get; }
        public PaginationService<Product, ProductDTO> _paginationService { get; }
        public ProductService(IUnitOfWork unitOfWork, IAwsS3Service awsS3Service, IMapper mapper, PaginationService<Product, ProductDTO> paginationService)
        {
            this._unitOfWork = unitOfWork;
            _awsS3Service = awsS3Service;
            this._mapper = mapper;
            _paginationService = paginationService;
        }



        public async Task<bool> AddProduct(ProductDTO product)
        {
            try
            {
                var newProduct = new Product();
                newProduct.Name = product.Name;
                newProduct.Description = product.Description;
                newProduct.CategoryId = product.CategoryId;
                newProduct.BrandId = product.BrandId;
                newProduct.StockQuantity = product.StockQuantity;
                newProduct.Price = product.Price;
                newProduct.DiscountedPrice = product.DiscountedPrice;
                newProduct.CreatedAt = DateTime.UtcNow;
                newProduct.UpdatedAt = DateTime.UtcNow;

                List<string> imgUrls = new List<string>();
                foreach (var url in product.ImageUrl)
                {
                    imgUrls.Add(await _awsS3Service.UploadProductImage(url));
                }
                newProduct.ImageUrl = imgUrls.ToArray();

                _unitOfWork.GetRepository<Product>().Add(newProduct);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public ProductDTO GetProductById(Guid ProductId)
        {
            var product = _unitOfWork.GetRepository<Product>().GetWithInclude(x => x.Brand, x => x.Category).Where(x => x.ProductId == ProductId)?.FirstOrDefault();
            return _mapper.Map<ProductDTO>(product);
        }

        public PagedResponse<ProductDTO> GetProducts(PaginationFilter paginationFilter, ProductFilter productFilter)
        {
            IQueryable<Product> query = _unitOfWork.GetRepository<Product>().GetWithInclude(x => x.Category, x => x.Brand).OrderByDescending(x => x.CreatedAt);

            if (!string.IsNullOrEmpty(productFilter.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(productFilter.Name.ToLower()));
            }
            if (!string.IsNullOrEmpty(productFilter.BrandName))
            {
                query = query.Where(x => string.Equals(x.Brand.Name.ToLower(), productFilter.BrandName.ToLower()));
            }
            if (!string.IsNullOrEmpty(productFilter.CategoryName))
            {
                query = query.Where(x => string.Equals(x.Category.Name.ToLower(), productFilter.CategoryName.ToLower()));
            }
            if (productFilter.CategoryId.HasValue)
            {
                query = query.Where(x => x.CategoryId == productFilter.CategoryId.Value);
            }
            if (productFilter.BrandId.HasValue)
            {
                query = query.Where(x => x.BrandId == productFilter.BrandId.Value);
            }

            return _paginationService.GetPagedResponse(query, paginationFilter);
        }

        public ProductDTO UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
