using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MindPalace.Server.Services;
using MindPalace.Server.Entities;
using MindPalace.Shared.Dtos;
using AutoMapper;

namespace MindPalace.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagsRepository _repo;
        private readonly IMapper _mapper;

        public TagsController(ITagsRepository repo, IMapper mapper)
        {
            _repo = repo ??
                throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ??
               throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tag>>> GetTags()
        {
            var tags = await _repo.GetTagsAsync();
            return Ok(tags);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tag>> GetTag(Guid id)
        {
            var tag = await _repo.GetTagAsync(id);
            if (tag == null)
            {
                return NotFound();
            }
            return Ok(tag);
        }

        [HttpPost]
        public async Task<ActionResult<Tag>> CreateLink(TagToCreateDto tag)
        {
            if (tag == null)
            {
                throw new ArgumentNullException(nameof(tag));
            }

            var tagEntity = _mapper.Map<Tag>(tag);
            _repo.AddTag(tagEntity);
            await _repo.SaveChangesAsync();

            var linkToReturn = _mapper.Map<LinkDto>(tagEntity);
            return CreatedAtAction(
                "GetLink",
                new { id = linkToReturn.Id },
                linkToReturn);
        }
    }
}