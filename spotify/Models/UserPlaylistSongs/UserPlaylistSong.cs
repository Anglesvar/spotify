
using spotify.Models.playlists;
using spotify.Models.songs;

namespace spotify.Models.UserPlaylistSongs
{
    public class UserPlaylistSong
    {
        public int Id { get; set; }
        public Song Song { get; set; }
        public Playlist Playlist { get; set; }
        public int OwnerId { get; set; }
        public int PlaylistId { get; internal set; }
        public int SongId { get; internal set; }
    }
}
