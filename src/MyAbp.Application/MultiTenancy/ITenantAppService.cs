using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyAbp.MultiTenancy.Dto;

namespace MyAbp.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

