using spotify.Models.playlists;
using spotify.Models.songs;
using spotify.Request.PlayList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spotify.Repository.PlayList
{
    public interface IPlayListRepository
    {
        public bool CreateNewPlayList(AddPlayListRequest data);
        public bool AddSongToPlayList(AddSongToPlayListRequest data);
        public bool DeleteSongFromPlayList(DeleteSongFromPlayListRequest data);
        public bool DeletePlayList(int id);
        public bool UpdatePlayList(UpdatePlayListRequest data);
        public List<Song> GetSongsByPlayListId(int playListId);
        public List<Playlist> GetPlayLists(int ownerId);
    }
}
