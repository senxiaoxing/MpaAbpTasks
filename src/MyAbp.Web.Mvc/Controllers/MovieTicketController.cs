using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyAbp.Controllers;
using MyAbp.Movie;

namespace MyAbp.Web.Mvc.Controllers
{
    public class MovieTicketController : MyAbpControllerBase
    {
        private readonly IMovieTicketAppService _movieTicketAppService;

        public MovieTicketController(IMovieTicketAppService movieTicketAppService)
        {
            this._movieTicketAppService = movieTicketAppService;
        }

        public IActionResult Index()
        {
            var model = _movieTicketAppService.GetAllMovieTicket();
            return View(model);
        }
    }
}