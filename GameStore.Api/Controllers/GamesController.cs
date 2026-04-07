using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class GamesController : ControllerBase
{
    private readonly GameStoreContext _context;

    public GamesController(GameStoreContext context)
    {
        _context = context;
    }

    // GET /games
    [HttpGet]
    public IEnumerable<GameDto> GetAll()
    {
        return _context.Games.Select(game => new GameDto(
            game.Id, game.Name, game.Genre, game.Price, game.ReleaseDate));
    }

    // GET /games/1
    [HttpGet("{id}")]
    public ActionResult<GameDto> GetById(int id)
    {
        var game = _context.Games.Find(id);
        if (game is null) return NotFound();

        return new GameDto(game.Id, game.Name, game.Genre, game.Price, game.ReleaseDate);
    }

    // POST /games
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public ActionResult<GameDto> Create(CreateGameDto newGame)
    {
        Game game = new()
        {
            Name = newGame.Name,
            Genre = newGame.Genre,
            Price = newGame.Price,
            ReleaseDate = newGame.ReleaseDate
        };

        // 3. Add to Database and Save
        _context.Games.Add(game);
        _context.SaveChanges();

        var gameDto = new GameDto(game.Id, game.Name, game.Genre, game.Price, game.ReleaseDate);
        return CreatedAtAction(nameof(GetById), new { id = game.Id }, gameDto);
    }

    // PUT /games/1
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin,Moderator")]
    public ActionResult Update(int id, UpdateGameDto updatedGame)
    {
        var existingGame = _context.Games.Find(id);
        if (existingGame is null) return NotFound();

        // 4. Update the game properties
        existingGame.Name = updatedGame.Name;
        existingGame.Genre = updatedGame.Genre;
        existingGame.Price = updatedGame.Price;
        existingGame.ReleaseDate = updatedGame.ReleaseDate;

        _context.SaveChanges();

        return NoContent();
    }

    // DELETE /games/1
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public ActionResult Delete(int id)
    {
        var existingGame = _context.Games.Find(id);
        if (existingGame is null) return NotFound();

        // 5. Remove from database
        _context.Games.Remove(existingGame);
        _context.SaveChanges();

        return NoContent();
    }
}
