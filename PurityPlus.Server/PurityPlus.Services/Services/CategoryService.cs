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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PaginationService<Category, CategoryDTO> _paginationService { get; }

        public CategoryService(IUnitOfWork unitOfWork, PaginationService<Category, CategoryDTO> PaginationService)
        {
            this._unitOfWork = unitOfWork;
            this._paginationService = PaginationService;
        }


        public void AddCategory(CategoryDTO category)
        {
            var newCategory = new Category();
            newCategory.Name = category.Name;
            newCategory.Description = category.Description;
            newCategory.ParentCategoryId = category.ParentCategoryId;
            newCategory.CreatedAt = DateTime.UtcNow;
            newCategory.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.GetRepository<Category>().Add(newCategory);
            _unitOfWork.SaveChanges();

        }

        public PagedResponse<CategoryDTO> GetAllCategories(PaginationFilter filter, CategoryFilter categoryFilter)
        {
            IQueryable<Category> query = _unitOfWork.GetRepository<Category>().QueryAll().OrderByDescending(x => x.CreatedAt);

            if (!string.IsNullOrEmpty(categoryFilter.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(categoryFilter.Name.ToLower()));
            }

            return _paginationService.GetPagedResponse(query, filter);
        }
    }
}
