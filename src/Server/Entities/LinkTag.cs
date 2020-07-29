using System;

namespace MindPalace.Server.Entities
{
    public class LinkTag
    {
        public Guid LinkId { get; set; }
        public Link Link { get; set; }

        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
    }
}