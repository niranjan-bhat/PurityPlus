using AutoMapper;
using PurityPlus.Database.Entity;
using System.ComponentModel.DataAnnotations;

namespace PurityPlus.Services.Classes
{
    public class PagedResponse<T> where T : class
    {
        public int CurrentPage { get; set; } = 1;
        public int TotalRecords { get; set; }
        public int PageSize { get; set; } = 15;
        public int CurrentPageStartIndex { get; set; }
        public int CurrentPageEndIndex { get; set; }
        public IEnumerable<T> Data { get; set; }
        public string Error { get; set; }
    }
}
