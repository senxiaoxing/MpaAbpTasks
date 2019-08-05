using Abp.AutoMapper;
using MyAbp.Authorization.MovieTickets;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyAbp.Movie.Dto
{
    [AutoMapTo(typeof(MovieTicket))]
    public class MovieTicketInputDto
    {
        public const int MaxLength = 20;

        [Required]
        [MaxLength(MaxLength)]
        public string MovieName { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        [Required]
        [MaxLength(MaxLength)]
        public string MovieActor { get; set; }

        public decimal Money { get; set; }
    }
}
