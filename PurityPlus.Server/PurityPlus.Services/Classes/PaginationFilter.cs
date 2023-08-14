namespace PurityPlus.Services.Classes
{
    public class PaginationFilter
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 15;
        public string? SortOrder { get; set; }
    }
}
