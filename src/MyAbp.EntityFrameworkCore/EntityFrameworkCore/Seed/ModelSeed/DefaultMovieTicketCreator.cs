using Microsoft.EntityFrameworkCore;
using MyAbp.Authorization.MovieTickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyAbp.EntityFrameworkCore.Seed.ModelSeed
{
    public class DefaultMovieTicketCreator
    {
        private readonly MyAbpDbContext _context;

        public DefaultMovieTicketCreator(MyAbpDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateDefaultMovieTicket();
        }

        private void CreateDefaultMovieTicket()
        {
            // Default movieTicket
            var defaultMovieTicket = new MovieTicket
            {
                MovieName = "復仇者聯盟4：終局之戰",
                MovieActor = "小羅伯特·唐尼",
                StartTime = new DateTime(2019, 04, 15),
                EndTime = new DateTime(2019, 06, 15),
                Money = 59.0m
            };
            
            var MovieTickets = _context.MovieTickets.IgnoreQueryFilters().Any(t => t.MovieName == defaultMovieTicket.MovieName);
            if (MovieTickets)
            {
                return;
            }
            _context.MovieTickets.Add(defaultMovieTicket);
            _context.SaveChanges();
        }
    }
}
