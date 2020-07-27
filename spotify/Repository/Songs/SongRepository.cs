using Microsoft.EntityFrameworkCore;
using spotify.Models;
using spotify.Models.songs;
using spotify.Models.UserPlaylistSongs;
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

                
                allSongs = _db.songs.Where(a => a.SongName.ToLower().Contains(songName)).ToList();
            
           
            return allSongs;
        }

        public List<Song> SearchSongByArtistName(string artistName)
        {
            List<Song> allSongs = new List<Song>();
            
            allSongs = _db.songs.Where(a => a.SongArtist.ToLower().Contains(artistName)).ToList();
            
            return allSongs;
        }
        public List<Song> SearchSongByAlbumName(string albumName)
        {
            List<Song> allSongs = new List<Song>();
            
            allSongs = _db.songs.Where(a => a.SongAlbum.ToLower().Contains(albumName)).ToList();

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
        public List<Song> GetSongsExcludedFromAllSongs(int playListId)
        {
            //userPlaylist
            //songs
            List<Song> allSongsByPlayListId = new List<Song>();
            List<UserPlaylistSong> songs = _db.userPlaylistSongs.Include("Song").Where(a => a.PlaylistId == playListId).ToList();

            foreach (UserPlaylistSong record in songs)
            {
                allSongsByPlayListId.Add(record.Song);
            }
            List<int> songId = new List<int>();
            foreach (Song song in allSongsByPlayListId)
            {
                songId.Add(song.Id);
            }
            List<Song> allSongs = new List<Song>();
            allSongs = _db.songs.ToList();
            List<Song> ResultSongs = new List<Song>();
                ResultSongs = _db.songs.ToList();
            foreach (Song song in allSongs)
            {
                foreach(int existingSong in songId)
                {
                    if (song.Id == existingSong)
                        ResultSongs.Remove(song);
                }
            }
            return ResultSongs;
        }
    }
}
