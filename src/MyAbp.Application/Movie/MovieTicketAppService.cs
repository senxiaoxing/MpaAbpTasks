using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAbp.Authorization.MovieTickets;
using MyAbp.Dtos;
using MyAbp.Movie.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbp.Movie
{
    public class MovieTicketAppService : MyAbpAppServiceBase, IMovieTicketAppService
    {
        private readonly IRepository<MovieTicket> _movieTicketRepository;

        public MovieTicketAppService(IRepository<MovieTicket> movieTicketRepository)
        {
            _movieTicketRepository = movieTicketRepository;
        }

        public async Task CreateMovie(MovieTicketInputDto input)
        {
            var movie = ObjectMapper.Map<MovieTicket>(input);
            await _movieTicketRepository.InsertAsync(movie);
        }

        public async Task UpdateMovie(MovieTicketUpdateDto input)
        {
            var movie = ObjectMapper.Map<MovieTicket>(input);
            await _movieTicketRepository.UpdateAsync(movie);
        }

        public async Task DeleteMovie(int id)
        {
            var movie = _movieTicketRepository.Get(id);
            if(movie != null)
            {
                await _movieTicketRepository.DeleteAsync(movie);
            }
        }

        public async Task<MovieTicket> GetById(int id)
        {
            var movie = await _movieTicketRepository.GetAsync(id);

            return ObjectMapper.Map<MovieTicket>(movie);
        }

        public IList<MovieTicketDto> GetAllMovieTicket()
        {
            var models = _movieTicketRepository.GetAll()
                .OrderByDescending(o => o.CreationTime);

            var Dtos = Mapper.Map<IList<MovieTicketDto>>(models);

            return Dtos;
        }

        public async Task<PagedResultDto<MovieTicketDto>> GetAllMovieTicketPage(MovieInputDto input)
        {
            var query = _movieTicketRepository.GetAll();
            var totalCount = await query.CountAsync();
            //默认的分页方式
            //var models = await query.Skip(input.SkipCount).Take(input.MaxResultCount).ToListAsync();

            //ABP提供了扩展方法PageBy分页方式
            var models = await query.OrderBy(t => t.StartTime).AsNoTracking().PageBy(input).ToListAsync();

            if (models.Count() == 0)
            {
                return new DataTablesPagedOutputDto<MovieTicketDto>(0, new List<MovieTicketDto>());
            }
            var items = models.MapTo<List<MovieTicketDto>>();
            return new DataTablesPagedOutputDto<MovieTicketDto>(totalCount, items);
        }
    }
}
