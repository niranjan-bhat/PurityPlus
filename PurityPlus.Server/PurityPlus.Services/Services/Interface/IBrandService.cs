using PurityPlus.Database.Entity;
using PurityPlus.Services.Classes;
using PurityPlus.Services.DTO;
using PurityPlus.Services.FilterParams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurityPlus.Services.Interface
{
    public interface IBrandService
    {
        void AddBrand(BrandDTO brand);
        void UpdateBrand(BrandDTO brand);
        PagedResponse<BrandDTO> GetAllBrands(PaginationFilter PaginationFilter, BrandFilter BrandFilter);
    }
}
