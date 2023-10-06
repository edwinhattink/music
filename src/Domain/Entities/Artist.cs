using System.Collections.Generic;

namespace Music.Model
{ 
	public class Artist
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;

		public List<Contribution> Contributions { get; set; } = new List<Contribution>();

		public List<DiscContribution> DiscContributions { get; set; } = new List<DiscContribution>();
	}
}
