using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MindPalace.Server.Entities
{
    public class Tag
    {
        public Guid Id { get; set; }

        [MaxLength(25)]
        public string Name { get; set; }

        public List<LinkTag> LinkTags { get; set; } = new List<LinkTag>();
    }
}