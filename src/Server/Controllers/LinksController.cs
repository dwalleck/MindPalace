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
    public class LinksController : ControllerBase
    {
        private readonly ILinksRepository _repo;
        private readonly IMapper _mapper;

        public LinksController(ILinksRepository repo, IMapper mapper)
        {
            _repo = repo ??
                throw new ArgumentNullException(nameof(repo));
             _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Link>>> GetLinks()
        {
            var links = await _repo.GetLinksAsync();
            return Ok(links);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Link>> GetLink(Guid id)
        {
            var link = await _repo.GetLinkAsync(id);
            if (link == null)
            {
                return NotFound();
            }
            return Ok(link);
        }

        [HttpPost]
        public async Task<ActionResult<Link>> CreateLink(LinkToCreateDto link)
        {
            if (link == null)
            {
                throw new ArgumentNullException(nameof(link));
            }

            var linkEntity = _mapper.Map<Link>(link);
            _repo.AddLink(linkEntity);
            await _repo.SaveChangesAsync();

            var linkToReturn = _mapper.Map<LinkDto>(linkEntity);
            return CreatedAtAction(
                "GetLink",
                new { id = linkToReturn.Id },
                linkToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLink(Guid id, LinkToUpdateDto activity)
        {
            var linkEntity = await _repo.GetLinkAsync(id);
            if (linkEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(activity, linkEntity);
            _repo.UpdateLink(linkEntity);
            await _repo.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<LinkDto>> DeleteLink(Guid id)
        {
            var link = await _repo.GetLinkAsync(id);
            if (link == null)
            {
                return NotFound();
            }
            _repo.DeleteLink(link);
            await _repo.SaveChangesAsync();
            return _mapper.Map<LinkDto>(link);
        }
    }
}