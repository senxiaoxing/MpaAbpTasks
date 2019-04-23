using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAbp.Controllers;
using MyAbp.Lookup;
using MyAbp.Tasks;
using MyAbp.Tasks.Dto;
using MyAbp.Web.Models.People;
using MyAbp.Web.Models.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyAbp.Web.Controllers
{
    public class TasksController : MyAbpControllerBase
    {
        private readonly ITaskAppService _taskAppService;
        private readonly ILookupAppService _lookupAppService;

        public TasksController(ITaskAppService taskAppService, ILookupAppService lookupAppService)
        {
            _taskAppService = taskAppService;
            _lookupAppService = lookupAppService;
        }

        public async Task<ActionResult> Index(GetAllTasksInput input)
        {
            var output = await _taskAppService.GetAll(input);
            var model = new IndexViewModel(output.Items)
            {
                SelectedTaskState = input.State
            };
            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            var peopleSelectListItems = (await _lookupAppService.GetPeopleComboboxItems()).Items
                .Select(p => p.ToSelectListItem())
                .ToList();

            peopleSelectListItems.Insert(0, new SelectListItem { Value = string.Empty, Text = L("Unassigned"), Selected = true });

            return View("_EditTaskModal", new CreateTaskViewModel(peopleSelectListItems));
        }
    }
}
