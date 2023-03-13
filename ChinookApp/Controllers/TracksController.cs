using ChinookApp.Data;
using ChinookApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChinookApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TracksController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public TracksController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTracks([FromQuery] string genre, [FromQuery] string name)
        {
            IQueryable<Track> tracks = _context.Set<Track>();
            if (!string.IsNullOrEmpty(genre))
            {
                tracks = tracks.Where(t => t.Genre.Contains(genre));
            }
            if (!string.IsNullOrEmpty(name))
            {
                tracks = tracks.Where(t => t.Name.Contains(name));
            }
            return Ok(tracks.ToList());
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTrack(int id, [FromBody] Track track)
        {
            if (id != track.Id)
            {
                return BadRequest();
            }
            _context.Entry(track).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(track);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTrack(int id)
        {
            Track? track = _context.Set<Track>().Find(id);
            if (track == null)
            {
                return NotFound();
            }
            _context.Set<Track>().Remove(track);
            _context.SaveChanges();
            return NoContent();
        }
    }

}
