using Microsoft.AspNetCore.Antiforgery;
using MyAbp.Controllers;

namespace MyAbp.Web.Host.Controllers
{
    public class AntiForgeryController : MyAbpControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
