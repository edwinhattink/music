using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Model
{
	public class Album
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public int ReleaseYear { get; set; }
		public string Image { get; set; }

		public List<Disc> Discs { get; set; }
	}
}
