using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MindPalace.Server.Contexts;
using MindPalace.Server.Entities;

namespace MindPalace.Server.Services
{
    public class LinksRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<LinksRepository> _logger;

        public LinksRepository(ApplicationDbContext context,
            ILogger<LinksRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void AddLink(Link link)
        {
            if (link == null)
            {
                throw new ArgumentNullException(nameof(link));
            }
            _context.Links.Add(link);
        }

        public async Task<IEnumerable<Link>> GetLinksAsync()
        {
            return await _context.Links.ToListAsync();
        }

        public async Task<Link> GetLinkAsync(Guid id)
        {
            return await _context.Links.FindAsync(id);
        }

        public void DeleteLink(Link link)
        {
            _context.Links.Remove(link);
        }

        public void UpdateLink(Link link)
        {
            _context.Entry(link).State = EntityState.Modified;
        }

        public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;

        public bool ActivityExists(Guid id) => _context.Links.Any(l => l.Id == id);
    }
}