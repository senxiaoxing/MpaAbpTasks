using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyAbp.Authorization.MovieTickets
{
    public class MovieTicket : Entity, IHasCreationTime
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

        public DateTime CreationTime { get; set; }
    }
}
