using Microsoft.EntityFrameworkCore;
using spotify.Models;
using spotify.Models.playlists;
using spotify.Models.songs;
using spotify.Models.UserPlaylistSongs;
using spotify.Request.PlayList;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace spotify.Repository.PlayList
{
    public class PlayListRepository : IPlayListRepository
    {
        private readonly ApplicationDbContext _db;
        public PlayListRepository(ApplicationDbContext database)
        {
            this._db = database;
        }
        public bool CreateNewPlayList(AddPlayListRequest playListData)
        {
            if (playListData != null)
            {
                Playlist newPlaylist = new Playlist();
                newPlaylist.PlayListName = playListData.PlayListName;
                newPlaylist.OwnerId = playListData.OwnerId;
                _db.playlists.Add(newPlaylist);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool AddSongToPlayList(AddSongToPlayListRequest data)
        {
            if (data != null)
            {
                UserPlaylistSong songToPlayList = new UserPlaylistSong();
                songToPlayList.OwnerId = data.OwnerId;
                songToPlayList.PlaylistId = data.PlaylistId;
                songToPlayList.SongId = data.SongId;

                _db.userPlaylistSongs.Add(songToPlayList);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool DeleteSongFromPlayList(DeleteSongFromPlayListRequest data)
        {
            if (data != null)
            {
                UserPlaylistSong song = new UserPlaylistSong();
                song = _db.userPlaylistSongs.Where(a => a.SongId == data.SongId && a.PlaylistId == data.PlaylistId).FirstOrDefault();
                _db.userPlaylistSongs.Remove(song);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool DeletePlayList(int id)
        {
            if (id != 0)
            {
                Playlist playlist = new Playlist();
                playlist = _db.playlists.Find(id);
                _db.playlists.Remove(playlist);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        //UpdatePlayList method Updates the Name of the PlayList only
        //OwnerId is a must
        public bool UpdatePlayList(UpdatePlayListRequest data)  
        {
            var playlist = _db.playlists.Where(a => a.Id == data.Id && a.OwnerId == data.OwnerId).FirstOrDefault();
            if (playlist != null && data != null)
            {
                playlist.PlayListName = string.IsNullOrEmpty(data.PlayListName) ? playlist.PlayListName : data.PlayListName;
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Song> GetSongsByPlayListId(int playListId)
        {
            List<Song> allSongsByPlayListId = new List<Song>();
            List<UserPlaylistSong> songs = _db.userPlaylistSongs.Include("Song").Where(a => a.PlaylistId == playListId).ToList();

            foreach(UserPlaylistSong record in songs)
            {
                allSongsByPlayListId.Add(record.Song);  
            }
            return allSongsByPlayListId;
        }
        public List<Playlist> GetPlayLists(int ownerId)
        {
            List<Playlist> allPlayLists = new List<Playlist>();
            allPlayLists = _db.playlists.Where(a => a.OwnerId == ownerId).ToList();

            return allPlayLists;
        }
    }
}
