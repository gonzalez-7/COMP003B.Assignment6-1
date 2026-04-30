using COMP003B.Assignment6.Models;
using Microsoft.EntityFrameworkCore;

namespace COMP003B.Assignment6.Data
{
	public class SoccerTeamContext : DbContext
	{
		public SoccerTeamContext(DbContextOptions<SoccerTeamContext> options) : base(options) { }

		
		//
		public DbSet<Player> Players { get; set; }
		public DbSet<Team> Teams { get; set; }
		public DbSet<PlayerTeam> PlayerTeams { get; set; }
	}
}
