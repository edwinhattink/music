using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Model
{
	public class Genre
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public List<Track> Tracks { get; set; }
	}
}
