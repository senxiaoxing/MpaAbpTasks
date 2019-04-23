using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyAbp.Lookup
{
    public interface ILookupAppService : IApplicationService
    {
        Task<ListResultDto<ComboboxItemDto>> GetPeopleComboboxItems();
    }
}
