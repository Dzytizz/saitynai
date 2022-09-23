using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace saitynai_server.Models
{
    public partial class saitynaiContext : DbContext
    {
        public saitynaiContext()
        {
        }

        public saitynaiContext(DbContextOptions<saitynaiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrators { get; set; } = null!;
        public virtual DbSet<Advertisement> Advertisements { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Game> Games { get; set; } = null!;
        public virtual DbSet<Request> Requests { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;database=saitynai;uid=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.36-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_lithuanian_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.ToTable("administrator");

                entity.HasIndex(e => e.FkUserId, "fk_User_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.FkUserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("fk_User_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(63)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Advertisement>(entity =>
            {
                entity.ToTable("advertisement");

                entity.HasIndex(e => e.FkClientId, "creates");

                entity.HasIndex(e => e.EnchangeTo, "exchanging_to");

                entity.HasIndex(e => e.FkGameId, "has");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Condition)
                    .HasColumnType("int(11)")
                    .HasColumnName("condition");

                entity.Property(e => e.Description)
                    .HasMaxLength(511)
                    .HasColumnName("description");

                entity.Property(e => e.EnchangeTo)
                    .HasColumnType("int(11)")
                    .HasColumnName("enchange_to");

                entity.Property(e => e.FkClientId)
                    .HasColumnType("int(11)")
                    .HasColumnName("fk_Client_id");

                entity.Property(e => e.FkGameId)
                    .HasColumnType("int(11)")
                    .HasColumnName("fk_Game_id");

                entity.Property(e => e.Photos)
                    .HasMaxLength(511)
                    .HasColumnName("photos");

                entity.Property(e => e.Price)
                    .HasPrecision(10)
                    .HasColumnName("price");

                entity.Property(e => e.PublishDate)
                    .HasColumnType("timestamp")
                    .HasColumnName("publish_date");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client");

                entity.HasIndex(e => e.FkUserId, "fk_User");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.FkUserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("fk_User_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(63)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(31)
                    .HasColumnName("phone");

                entity.Property(e => e.Surname)
                    .HasMaxLength(63)
                    .HasColumnName("surname");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comment");

                entity.HasIndex(e => e.FkClientId, "creates");

                entity.HasIndex(e => e.FkAdvertisementId, "has");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(511)
                    .HasColumnName("description");

                entity.Property(e => e.FkAdvertisementId)
                    .HasColumnType("int(11)")
                    .HasColumnName("fk_Advertisement_id");

                entity.Property(e => e.FkClientId)
                    .HasColumnType("int(11)")
                    .HasColumnName("fk_Client_id");

                entity.Property(e => e.PublishDate)
                    .HasColumnType("timestamp")
                    .HasColumnName("publish_date");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("game");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(511)
                    .HasColumnName("description");

                entity.Property(e => e.Difficulty)
                    .HasColumnType("int(11)")
                    .HasColumnName("difficulty");

                entity.Property(e => e.MaxPlayers)
                    .HasColumnType("int(11)")
                    .HasColumnName("max_players");

                entity.Property(e => e.MinPlayers)
                    .HasColumnType("int(11)")
                    .HasColumnName("min_players");

                entity.Property(e => e.Photos)
                    .HasMaxLength(511)
                    .HasColumnName("photos");

                entity.Property(e => e.Rules)
                    .HasMaxLength(511)
                    .HasColumnName("rules");

                entity.Property(e => e.Title)
                    .HasMaxLength(63)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("request");

                entity.HasIndex(e => e.FkClientId, "creates");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.AdditionalInfo)
                    .HasMaxLength(511)
                    .HasColumnName("additional_info");

                entity.Property(e => e.FkClientId)
                    .HasColumnType("int(11)")
                    .HasColumnName("fk_Client_id");

                entity.Property(e => e.GameTitle)
                    .HasMaxLength(127)
                    .HasColumnName("game_title");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.Email, "email")
                    .IsUnique();

                entity.HasIndex(e => e.Nickname, "nickname")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(63)
                    .HasColumnName("email");

                entity.Property(e => e.Nickname)
                    .HasMaxLength(63)
                    .HasColumnName("nickname");

                entity.Property(e => e.Password)
                    .HasMaxLength(63)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
