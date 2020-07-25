﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using spotify.Repository.PlayList;
using spotify.Request.PlayList;

namespace spotify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayListController : ControllerBase
    {
        private readonly IPlayListRepository repository;
        public PlayListController(IPlayListRepository repository)
        {
            this.repository = repository;
        }
        [HttpPost("addplaylist")]
        public IActionResult PostAddPlayList(AddPlayListRequest playListData)
        {
            var result = repository.CreateNewPlayList(playListData);
            if (result)
            {
                return Ok("PlayList Creation Successful");
            }
            return BadRequest("Duplicate PlayList creation not allowed");
        }

        [HttpPost("addsongtoplaylist")]
        public IActionResult PostSongToPlayList(AddSongToPlayListRequest songData)
        {
            if (repository.AddSongToPlayList(songData))
                return Ok("success");
            else
                return BadRequest("Failure");
        }
        [HttpDelete("deletesongfromplaylist")]
        public IActionResult DeleteSongFromPlayList(DeleteSongFromPlayListRequest songData)
        {
            return Ok(repository.DeleteSongFromPlayList(songData));
        }

        [HttpDelete("deleteplaylist")]
        public IActionResult DeletePlayList(int playListId)
        {
            if(repository.DeletePlayList(playListId))
                return Ok("PlayList Deleted");
            return BadRequest("Error Deleting PlayList");
        }
        [HttpPut("updateplaylistname")]
        public IActionResult UpdatePlayList(UpdatePlayListRequest playListData)
        {
            if(repository.UpdatePlayList(playListData))
                return Ok("Update Successful");
            return BadRequest("Problem Encountered, try again!");
        }

        [HttpPost("getsongsbyplaylist")]
        public IActionResult GetSongsByPlayList(int id)
        {
            return Ok(repository.GetSongsByPlayListId(id));
        }

        [HttpPost("getallplaylists")]
        public IActionResult GetPlayLists(int ownerId)
        {
            return Ok(repository.GetPlayLists(ownerId));
        }
    }
}