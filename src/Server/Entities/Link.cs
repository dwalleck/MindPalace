using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using MindPalace.Server.Entities;

namespace MindPalace.Server.Entities
{
    public class Link
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Url { get; set; }

        public List<Tag> Tags { get; set; }
    }
}