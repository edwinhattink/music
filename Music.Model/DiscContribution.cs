using System;
using System.Collections.Generic;
using System.Text;

namespace Music.Model
{
    public class DiscContribution
    {
        public int Id { get; set; }

        public int DiscId { get; set; }
        public Disc Disc { get; set; }

        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
