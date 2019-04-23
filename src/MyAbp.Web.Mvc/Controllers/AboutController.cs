using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using MyAbp.Controllers;

namespace MyAbp.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : MyAbpControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
