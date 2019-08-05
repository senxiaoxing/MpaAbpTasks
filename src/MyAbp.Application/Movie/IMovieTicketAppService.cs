using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyAbp.Authorization.MovieTickets;
using MyAbp.Movie.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyAbp.Movie
{
    public interface IMovieTicketAppService : IApplicationService
    {
        Task CreateMovie(MovieTicketInputDto input);

        Task UpdateMovie(MovieTicketUpdateDto input);

        Task DeleteMovie(int id);

        Task<MovieTicket> GetById(int id);

        IList<MovieTicketDto> GetAllMovieTicket();

        Task<PagedResultDto<MovieTicketDto>> GetAllMovieTicketPage(MovieInputDto input);
    }
}
