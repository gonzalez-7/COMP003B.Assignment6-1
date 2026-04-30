using System.ComponentModel.DataAnnotations;

namespace COMP003B.Assignment6.Models
{
	public class Team
	{
		public int TeamId { get; set; }

		[Required]
		public string TeamName { get; set; } = string.Empty;

		[Required]
		public string City { get; set; } = string.Empty;

		public virtual ICollection<PlayerTeam>? PlayerTeams { get; set; }
	}
}
