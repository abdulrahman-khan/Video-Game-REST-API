using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VideoGamesAPI.Controllers.Data;
using VideoGamesAPI.Models;

namespace VideoGamesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGamesController(VideoGameDBContext context) : ControllerBase
    {
        private readonly VideoGameDBContext _context = context;


        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<VideoGame>>> GetVideoGames()
        {
            return Ok(await _context.VideoGames
                .Include(game => game.VideoGamesDetails)
                .Include(game => game.Developer)
                .Include(game => game.Publisher)
                .Include(game => game.Genres)
                .ToListAsync());
        }


        // get single video game
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<VideoGame>> GetVideoGameById(int id)
        {
            var game = await _context.VideoGames.FindAsync(id);
            if (game is null)
                return NotFound();
            return Ok(game);
        }

        // create video game
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<VideoGame>> AddVideoGame(VideoGame newVideoGame)
        {
            if(newVideoGame is null)
            {
                return BadRequest();
            }

            _context.VideoGames.Add(newVideoGame);
            await _context.SaveChangesAsync(); 

            return CreatedAtAction(nameof(GetVideoGameById), new { id = newVideoGame.Id }, newVideoGame);
        }

        // updating
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVideoGame(int id, VideoGame updatedVideoGame)
        {
            var game = await _context.VideoGames.FindAsync(id);
            if (game is null)
                return NotFound();

            game.Title = updatedVideoGame.Title;
            game.Platform = updatedVideoGame.Platform;
            game.Publisher = updatedVideoGame.Publisher;
            game.Developer = updatedVideoGame.Developer;

            await _context.SaveChangesAsync();

            return NoContent();
        }


        // updating
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideoGame(int id)
        {
            var game = await _context.VideoGames.FindAsync(id);
            if (game is null)
                return NotFound();

            _context.VideoGames.Remove(game);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}











