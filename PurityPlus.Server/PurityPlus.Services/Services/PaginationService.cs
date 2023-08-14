using AutoMapper;
using PurityPlus.Services.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurityPlus.Services.Services
{
    public class PaginationService<T, Tdto> where T : class where Tdto : class
    {
        private readonly IMapper _mapper;

        public PaginationService(IMapper mapper)
        {
            this._mapper = mapper;
        }

        public PagedResponse<Tdto> GetPagedResponse(IQueryable<T> QuerableData, PaginationFilter paginationFilter)
        {
            var pagedResponse = new PagedResponse<Tdto>();
            pagedResponse.CurrentPage = paginationFilter.PageNumber;
            pagedResponse.PageSize = paginationFilter.PageSize;

            var quiredData = QuerableData.Skip((pagedResponse.CurrentPage - 1) * pagedResponse.PageSize).Take(pagedResponse.PageSize).AsEnumerable();
            pagedResponse.TotalRecords = QuerableData.Count();

            pagedResponse.CurrentPageStartIndex = pagedResponse.TotalRecords == 0 ? 0 : ((pagedResponse.CurrentPage - 1) * pagedResponse.PageSize) + 1;
            pagedResponse.CurrentPageEndIndex = pagedResponse.TotalRecords == 0 ? 0 : (pagedResponse.CurrentPageStartIndex + quiredData.Count() - 1);

            pagedResponse.Data = _mapper.Map<IEnumerable<T>, IEnumerable<Tdto>>(quiredData);
            return pagedResponse;

        }
    }
}
