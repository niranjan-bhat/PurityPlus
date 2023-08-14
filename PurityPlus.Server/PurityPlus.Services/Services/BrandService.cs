using PurityPlus.Database.Entity;
using PurityPlus.Database.Repository;
using PurityPlus.Services.Classes;
using PurityPlus.Services.DTO;
using PurityPlus.Services.FilterParams;
using PurityPlus.Services.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurityPlus.Services.Services
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrandService(IUnitOfWork unitOfWork, PaginationService<Brand,BrandDTO> PaginationService)
        {
            this._unitOfWork = unitOfWork;
            this._paginationService = PaginationService;
        }

        public PaginationService<Brand, BrandDTO> _paginationService { get; }

        public void AddBrand(BrandDTO brand)
        {
            var newBrand = new Brand();
            newBrand.Name = brand.Name;
            newBrand.Description = brand.Description;
            newBrand.LogoUrl = brand.LogoUrl;
            newBrand.CreatedAt = DateTime.UtcNow;
            newBrand.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.GetRepository<Brand>().Add(newBrand);
            _unitOfWork.SaveChanges();
        }

        public PagedResponse<BrandDTO> GetAllBrands(PaginationFilter PaginationFilter, BrandFilter BrandFilter)
        {
            IQueryable<Brand> query = _unitOfWork.GetRepository<Brand>().QueryAll().OrderByDescending(x => x.CreatedAt);

            if (!string.IsNullOrEmpty(BrandFilter.BrandName))
            {
                query = query.Where(x => x.Name.ToLower().Contains(BrandFilter.BrandName.ToLower()));
            }
            
            return _paginationService.GetPagedResponse(query, PaginationFilter);
        }

        public void UpdateBrand(BrandDTO brand)
        {
            throw new NotImplementedException();
        }
    }
}
