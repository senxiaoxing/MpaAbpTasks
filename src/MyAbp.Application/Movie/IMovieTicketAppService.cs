using Abp.Application.Services;
using MyAbp.Movie.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAbp.Movie
{
    public interface IMovieTicketAppService : IApplicationService
    {
        IList<MovieTicketDto> GetAllMovieTicket();
    }
}
