using spotify.Models;
using spotify.Models.songs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spotify.Repository.Songs
{
    public class SongRepository: ISongRepository
    {
        private readonly ApplicationDbContext _db;
        public SongRepository(ApplicationDbContext database)
        {
            this._db = database;
        }
        public List<Song> SearchSongBySongName(string songName)
        {
            List<Song> allSongs = new List<Song>();
            string songNameLowerCase = songName.ToLower();
            allSongs = _db.songs.Where(a => a.SongName.ToLower().Contains(songNameLowerCase)).ToList();

            return allSongs;
        }

        public List<Song> SearchSongByArtistName(string artistName)
        {
            List<Song> allSongs = new List<Song>();
            string artistNameLowerCase = artistName.ToLower();
            allSongs = _db.songs.Where(a => a.SongArtist.ToLower().Contains(artistNameLowerCase)).ToList();
            
            return allSongs;
        }
        public List<Song> SearchSongByAlbumName(string albumName)
        {
            List<Song> allSongs = new List<Song>();
            string albumNameLowerCase = albumName.ToLower();
            allSongs = _db.songs.Where(a => a.SongAlbum.ToLower().Contains(albumNameLowerCase)).ToList();

            return allSongs;
        }

        public List<Song> GetAllSongs()
        {
            List<Song> allSongs = new List<Song>();
            allSongs = _db.songs.ToList();

            return allSongs;
        }
        public Song GetSongById(int id)
        {
            Song song = _db.songs.Where(a => a.Id == id).FirstOrDefault();
            return song;
        }
    }
}
