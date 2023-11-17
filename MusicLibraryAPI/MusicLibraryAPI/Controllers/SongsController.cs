using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicLibraryAPI.Data;
using MusicLibraryAPI.Models;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace MusicLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicLibraryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MusicLibraryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Songs
        [HttpGet]
        public IActionResult Get()
        {
            var song = _context.Songs.ToList();
            return StatusCode(200, song);
        }

        // GET: api/Song/4
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var song = _context.Songs.Find(id);
            if (song == null)
            {
                return NotFound();
            }
            return StatusCode(200, song);
        }

        //POST: api/Songs
        [HttpPost]
        public IActionResult Post([FromBody] Song song)
        {
            _context.Songs.Add(song);
            _context.SaveChanges();
            return StatusCode(201, song);
        }

        //Put: api/Songs/7
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Song UpdatedSong)
        {
            var ExistingSong = _context.Songs.Find(id);
            if (ExistingSong == null)
            {
                return NotFound();
            }
            ExistingSong.Title = UpdatedSong.Title;
            ExistingSong.Artist = UpdatedSong.Artist;
            ExistingSong.Album = UpdatedSong.Album;
            ExistingSong.Genre = UpdatedSong.Genre;
            ExistingSong.ReleaseDate = UpdatedSong.ReleaseDate;
            _context.Songs.Update(UpdatedSong);
            _context.SaveChanges();
            return StatusCode(200, ExistingSong);
        }

        //DELETE: api/Songs/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            var removedId = _context.Songs.Find(Id);
            _context.Songs.Remove(removedId);
            _context.SaveChanges();
            return NoContent();
        }
    }
}