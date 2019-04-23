using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using MyAbp.Authorization.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyAbp.Tasks.Dto
{
    public class GetAllTasksInput
    {
        public TaskState? State { get; set; }
    }

    [AutoMapFrom(typeof(Task))]
    public class TaskListDto : EntityDto, IHasCreationTime
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreationTime { get; set; }

        public TaskState State { get; set; }

        public Guid? AssignedPersonId { get; set; }

        public string AssignedPersonName { get; set; }
    }

    [AutoMapTo(typeof(Task))]
    public class CreateTaskInput
    {
        [Required]
        [StringLength(Task.MaxTitleLength)]
        public string Title { get; set; }

        [StringLength(Task.MaxDescriptionLength)]
        public string Description { get; set; }

        public Guid? AssignedPersonId { get; set; }
    }
}
