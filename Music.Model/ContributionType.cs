using System.Collections.Generic;

namespace Music.Model
{
	public class ContributionType
	{
		public int Id { get; set; }
		public string Type { get; set; }

		public List<Contribution> Contributions;
	}
}
