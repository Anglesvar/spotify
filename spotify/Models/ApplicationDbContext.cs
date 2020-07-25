using Microsoft.EntityFrameworkCore;
using spotify.Models.playlists;
using spotify.Models.songs;
using spotify.Models.UserAuthInfo;
using spotify.Models.UserPlaylistSongs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spotify.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<AdminLogin> adminLogin { get; set; }
        public DbSet<Song> songs { get; set; }
        public DbSet<Playlist> playlists { get; set; }
        public DbSet<UserAuth> userAuth { get; set; }
        public DbSet<UserPlaylistSong> userPlaylistSongs { get; set; }
    }
}
