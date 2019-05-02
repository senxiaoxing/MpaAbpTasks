using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyAbp.Authorization.MovieTickets;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAbp.Movie.Dto
{
    [AutoMapFrom(typeof(MovieTicket))]
    public class MovieTicketDto : EntityDto
    {
        public string MovieName { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        
        public string MovieActor { get; set; }

        public decimal Money { get; set; }
    }
}
