using spotify.Models.songs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spotify.Repository.Songs
{
    public interface ISongRepository
    {
        public List<Song> SearchSongBySongName(string songName);
        public List<Song> SearchSongByArtistName(string artistName);
        public List<Song> SearchSongByAlbumName(string albumName);
        public List<Song> GetAllSongs();
        public Song GetSongById(int id);
        public List<Song> GetSongsExcludedFromAllSongs(int playlistId);
    }
}
