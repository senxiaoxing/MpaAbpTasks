using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyAbp.Controllers;
using MyAbp.Movie;
using MyAbp.Movie.Dto;
using MyAbp.Web.Models.MovieTicket;

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

        public async Task<ActionResult> EditMovieTicketModal(int movieId)
        {
            var movie = await _movieTicketAppService.GetById(movieId);
            var model = new EditMovieTicketModalViewModel
            {
                Movie = ObjectMapper.Map<MovieTicketDto>(movie)
            };

            return View("_EditMovieTicketModal", model);
        }
    }
}