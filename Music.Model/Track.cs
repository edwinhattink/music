using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Model
{
	public class Track
	{
		public int Id { get; set; }
		public int Number { get; set; }
		public string Name { get; set; }

		public string FileName { get; set; }

		public int DiscId { get; set; }
		public Disc Disc { get; set; }

		public int GenreId { get; set; }
		public Genre Genre { get; set; }

		public List<Contribution> Contributions { get; set; }
	}
}
