using MindPalace.Server.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindPalace.Server.Services
{
    public interface ILinksRepository
    {
        void AddLink(Link link);
        Task<IEnumerable<Link>> GetLinksAsync();
        Task<Link> GetLinkAsync(Guid id);
        void DeleteLink(Link link);
        void UpdateLink(Link link);
        Task<bool> SaveChangesAsync();
        bool LinkExists(Guid id);
    }
}