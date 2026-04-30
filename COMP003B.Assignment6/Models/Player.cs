using System.ComponentModel.DataAnnotations;

namespace COMP003B.Assignment6.Models
{
	public class Player
	{
		public int PlayerId { get; set; }

		[Required]
		public string Name { get; set; } = string.Empty;

		[Required]
		public string Position {  get; set; } = string.Empty;

		public int JerseyNumber { get; set; }

		public int Age { get; set; }

		public virtual ICollection<PlayerTeam>? PlayerTeams { get; set; }
	}
}
