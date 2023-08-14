using PurityPlus.Services.Classes;
using PurityPlus.Services.DTO;
using PurityPlus.Services.FilterParams;

namespace PurityPlus.Services.Interface
{
    public interface ICategoryService
    {
        void AddCategory(CategoryDTO category);

        PagedResponse<CategoryDTO> GetAllCategories(PaginationFilter filter,CategoryFilter categoryFilter);
    }
}
