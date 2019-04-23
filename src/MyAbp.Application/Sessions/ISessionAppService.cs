using System.Threading.Tasks;
using Abp.Application.Services;
using MyAbp.Sessions.Dto;

namespace MyAbp.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
