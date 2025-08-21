using Microsoft.EntityFrameworkCore;
using SessionService.Models;
using SessionService.Models.Joins;

namespace SessionService.Context
{
    public class SessionServiceDbContext : DbContext
    {
        public SessionServiceDbContext(DbContextOptions<SessionServiceDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// DbSet for sessions.
        /// </summary>
        public DbSet<Session> Sessions { get; set; }

        /// <summary>
        /// DbSet for NPCs.
        /// </summary>
        public DbSet<Npc> Npcs { get; set; }

        /// <summary>
        /// DbSet for locations.
        /// </summary>
        public DbSet<Location> Locations { get; set; }

        /// <summary>
        /// DbSet for organizations.
        /// </summary>
        public DbSet<Organization> Organizations { get; set; }

        /// <summary>
        /// DbSet for campaign-related entities.
        /// </summary>
        public DbSet<Campaign> Campaigns { get; set; }

        /// <summary>
        /// DbSet for characters.
        /// </summary>
        public DbSet<Character> Characters { get; set; }

        /// <summary>
        /// DbSet for dungeon masters.
        /// </summary>
        public DbSet<DungeonMaster> DMs { get; set; }

        /// <summary>
        /// DbSet for players.
        /// </summary>
        public DbSet<Player> Players { get; set; }

        /// <summary>
        /// DbSet for notes.
        /// </summary>
        public DbSet<Note> Notes { get; set; }
        public DbSet<CampaignDungeonMaster> CampaignDungeonMasters { get; set; }
        public DbSet<CampaignPlayer> CampaignPlayers { get; set; }
        public DbSet<LocationOrganization> LocationOrganizations { get; set; }
        public DbSet<LocationSession> LocationSessions { get; set; }
        public DbSet<NpcOrganization> NpcOrganizations { get; set; }
        public DbSet<PlayerSession> PlayerSessions { get; set; }
        public DbSet<OrganizationSession> OrganizationSessions { get; set; }
        public DbSet<DmSession> DmSessions { get; set; }
        public DbSet<SessionNpc> SessionNpcs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Example for CampaignDungeonMaster
            modelBuilder.Entity<CampaignDungeonMaster>()
                .HasKey(x => new { x.CampaignId, x.DungeonMasterId });

            modelBuilder.Entity<CampaignDungeonMaster>()
                .HasOne(x => x.Campaign)
                .WithMany(c => c.CampaignDungeonMasters)
                .HasForeignKey(x => x.CampaignId);

            modelBuilder.Entity<CampaignDungeonMaster>()
                .HasOne(x => x.DungeonMaster)
                .WithMany(dm => dm.CampaignDungeonMasters)
                .HasForeignKey(x => x.DungeonMasterId);

            // Repeat for all other join entities:
            modelBuilder.Entity<CampaignPlayer>()
                .HasKey(x => new { x.CampaignId, x.PlayerId });
            modelBuilder.Entity<CampaignPlayer>()
                .HasOne(x => x.Campaign)
                .WithMany(c => c.CampaignPlayers)
                .HasForeignKey(x => x.CampaignId);
            modelBuilder.Entity<CampaignPlayer>()
                .HasOne(x => x.Player)
                .WithMany(p => p.CampaignPlayers)
                .HasForeignKey(x => x.PlayerId);

            modelBuilder.Entity<LocationOrganization>()
                .HasKey(x => new { x.LocationId, x.OrganizationId });
            modelBuilder.Entity<LocationOrganization>()
                .HasOne(x => x.Location)
                .WithMany(l => l.LocationOrganizations)
                .HasForeignKey(x => x.LocationId);
            modelBuilder.Entity<LocationOrganization>()
                .HasOne(x => x.Organization)
                .WithMany(o => o.LocationOrganizations)
                .HasForeignKey(x => x.OrganizationId);

            modelBuilder.Entity<LocationSession>()
                .HasKey(x => new { x.LocationId, x.SessionId });
            modelBuilder.Entity<LocationSession>()
                .HasOne(x => x.Location)
                .WithMany(l => l.LocationSessions)
                .HasForeignKey(x => x.LocationId);
            modelBuilder.Entity<LocationSession>()
                .HasOne(x => x.Session)
                .WithMany(s => s.LocationSessions)
                .HasForeignKey(x => x.SessionId);

            modelBuilder.Entity<NpcOrganization>()
                .HasKey(x => new { x.NpcId, x.OrganizationId });
            modelBuilder.Entity<NpcOrganization>()
                .HasOne(x => x.Npc)
                .WithMany(n => n.NpcOrganizations)
                .HasForeignKey(x => x.NpcId);
            modelBuilder.Entity<NpcOrganization>()
                .HasOne(x => x.Organization)
                .WithMany(o => o.NpcOrganizations)
                .HasForeignKey(x => x.OrganizationId);

            modelBuilder.Entity<PlayerSession>()
                .HasKey(x => new { x.PlayerId, x.SessionId });
            modelBuilder.Entity<PlayerSession>()
                .HasOne(x => x.Player)
                .WithMany(p => p.PlayerSessions)
                .HasForeignKey(x => x.PlayerId);
            modelBuilder.Entity<PlayerSession>()
                .HasOne(x => x.Session)
                .WithMany(s => s.PlayerSessions)
                .HasForeignKey(x => x.SessionId);

            modelBuilder.Entity<OrganizationSession>()
                .HasKey(x => new { x.OrganizationId, x.SessionId });
            modelBuilder.Entity<OrganizationSession>()
                .HasOne(x => x.Organization)
                .WithMany(o => o.OrganizationSessions)
                .HasForeignKey(x => x.OrganizationId);
            modelBuilder.Entity<OrganizationSession>()
                .HasOne(x => x.Session)
                .WithMany(s => s.OrganizationSessions)
                .HasForeignKey(x => x.SessionId);

            modelBuilder.Entity<DmSession>()
                .HasKey(x => new { x.DungeonMasterId, x.SessionId });
            modelBuilder.Entity<DmSession>()
                .HasOne(x => x.DungeonMaster)
                .WithMany(dm => dm.DmSessions)
                .HasForeignKey(x => x.DungeonMasterId);
            modelBuilder.Entity<DmSession>()
                .HasOne(x => x.Session)
                .WithMany(s => s.DmSessions)
                .HasForeignKey(x => x.SessionId);

            modelBuilder.Entity<Note>()
                .HasOne(n => n.Session)
                .WithMany(s => s.Notes)
                .HasForeignKey(n => n.SessionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SessionNpc>()
                .HasKey(sn => sn.Id);

            modelBuilder.Entity<SessionNpc>()
                .HasIndex(sn => new { sn.SessionId, sn.NpcId })
                .IsUnique();

            modelBuilder.Entity<SessionNpc>()
                .HasOne(sn => sn.Session)
                .WithMany(s => s.SessionNpcs)
                .HasForeignKey(sn => sn.SessionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SessionNpc>()
                .HasOne(sn => sn.Npc)
                .WithMany(n => n.SessionNpcs)
                .HasForeignKey(sn => sn.NpcId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
