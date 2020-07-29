using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using MindPalace.Server.Entities;

namespace MindPalace.Server.Services
{
    public interface ITagsRepository
    {
        void AddTag(Tag Tag);
        Task<IEnumerable<Tag>> GetTagsAsync();
        Task<Tag> GetTagAsync(Guid id);
        void DeleteTag(Tag tag);
        void UpdateTag(Tag tag);
        Task<bool> SaveChangesAsync();
        bool TagExists(Guid id);
    }
}