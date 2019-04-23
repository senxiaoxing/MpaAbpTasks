using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyAbp.Tasks.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyAbp.Tasks
{
    public interface ITaskAppService : IApplicationService
    {
        Task<ListResultDto<TaskListDto>> GetAll(GetAllTasksInput input);

        Task Create(CreateTaskInput input);
    }
}
