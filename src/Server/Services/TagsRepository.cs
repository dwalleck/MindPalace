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
    public class TagsRepository : ITagsRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<LinksRepository> _logger;

        public TagsRepository(ApplicationDbContext context,
            ILogger<LinksRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void AddTag(Tag tag)
        {
            if (tag == null)
            {
                throw new ArgumentNullException(nameof(tag));
            }
            _context.Tags.Add(tag);
        }

        public async Task<IEnumerable<Tag>> GetTagsAsync()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<Tag> GetTagAsync(Guid id)
        {
            return await _context.Tags.FindAsync(id);
        }

        public void DeleteTag(Tag tag)
        {
            _context.Tags.Remove(tag);
        }

        public void UpdateTag(Tag tag)
        {
            _context.Entry(tag).State = EntityState.Modified;
        }

        public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;

        public bool TagExists(Guid id) => _context.Tags.Any(t => t.Id == id);
    }
}