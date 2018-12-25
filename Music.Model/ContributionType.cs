using System;
using System.Collections.Generic;
using System.Text;

namespace Music.Model
{
	public class ContributionType
	{
		public int Id { get; set; }
		public string Type { get; set; }

		public List<Contribution> Contributions;
	}
}
