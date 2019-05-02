using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        private readonly IRepository<Authorization.MovieTickets.MovieTicket> _movieTicketRepository;

        public MovieTicketAppService(IRepository<Authorization.MovieTickets.MovieTicket> movieTicketRepository)
        {
            _movieTicketRepository = movieTicketRepository;
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
            var query = _movieTicketRepository.GetAll().OrderBy(t => t.CreationTime).AsNoTracking();
            var totalCount = await query.CountAsync();
            //默认的分页方式
            //var models = await query.Skip(input.SkipCount).Take(input.MaxResultCount).ToListAsync();

            //ABP提供了扩展方法PageBy分页方式, 此版本尚未實現
            var models = await query.ToListAsync();

            if (models.Count() == 0)
            {
                return new DataTablesPagedOutputDto<MovieTicketDto>(0, new List<MovieTicketDto>());
            }
            var items = models.MapTo<List<MovieTicketDto>>();
            return new DataTablesPagedOutputDto<MovieTicketDto>(totalCount, items);
        }
    }
}
