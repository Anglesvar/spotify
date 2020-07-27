using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using spotify.Repository.Songs;

namespace spotify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class SongController : ControllerBase
    {
        private readonly ISongRepository repository;
        public SongController(ISongRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost("searchbysongname")]
        public IActionResult SearchBySongName(string songName)
        {
            return Ok(repository.SearchSongBySongName(songName));
        }

        [HttpPost("searchbysongartist")]
        public IActionResult SearchSongArtistName(string artistName)
        {
            return Ok(repository.SearchSongByArtistName(artistName));
        }
        [HttpPost("searchbysongalbum")]
        public IActionResult SearchSongAlbumName(string songAlbum)
        {
            return Ok(repository.SearchSongByAlbumName(songAlbum));
        }

        [HttpGet("allsongs")]
        public IActionResult GetAllSongs()
        {
            return Ok(repository.GetAllSongs());        
        }
        [HttpPost("getsongbyid")]
        public IActionResult GetSongById(int id)
        {
            return Ok(repository.GetSongById(id));
        }

        [HttpPost("excludedSongs")]
        public IActionResult GetExcludedSongs(int playListId)
        {
            return Ok(repository.GetSongsExcludedFromAllSongs(playListId));
        }
    }
}
