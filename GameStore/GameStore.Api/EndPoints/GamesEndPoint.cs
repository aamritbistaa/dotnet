using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.EndPoints;

public static class GamesEndpoints
{

    //     private static readonly List<GameDto> games = [
    //         new GameDto(1, "Fifa","Sports",19.99M,new DateOnly(2002,8,15)),
    //     new GameDto(2, "Dota","Strategy",9.99M,new DateOnly(2012,12,20)),
    //     new GameDto(3, "Sims","Simulation",112.95M,new DateOnly(2018,9,2)),
    //     new GameDto(4, "Mine","Adventure",24.99M,new DateOnly(2021,8,5)),
    // ];

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games").WithParameterValidation();


        group.MapGet("/", async (GameStoreContext dbContext) =>
        {
            return await dbContext.Games.Include(game => game.Genre).Select(game => game.ConvertToGameSummaryDto()).ToListAsync();
        });

        //GET /games/1
        group.MapGet("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            // GameDto? game = games.Find(item => item.Id == id);
            Game? game = await dbContext.Games.FindAsync(id);

            if (game is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(game.ConvertToGameDetailsDto());
        }).WithName("GetGame");

        // POST /games
        group.MapPost("/", async (CreateGameDto newGame, GameStoreContext dbContext) =>
        {
            // if (string.IsNullOrEmpty(newGame.Name))
            //     return Results.BadRequest("Name is required ");

            // GameDto game = new(
            //     Id: games.Count + 1,
            //     Name: newGame.Name,
            //     Genre: newGame.Genre,
            //     Price: newGame.Price,
            //     ReleaseDate: newGame.ReleaseDate
            // );
            // games.Add(game);

            Game game = newGame.ConvertToEntity();


            await dbContext.Games.AddAsync(game);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute("GetGame", new { id = game.Id }, game.ConvertToGameDetailsDto());
        });

        //PUT /games
        group.MapPut("/{id}", async (int id, UpdateGameDto editGame, GameStoreContext dbContext) =>
        {
            // var index = games.FindIndex(game => game.Id == id);
            // if (index == -1)
            // {
            //     return Results.NotFound();
            // }
            // games[index] = new GameSummaryDto(
            //     id,
            //     Name: editGame.Name,
            //     Genre: editGame.Genre,
            //     Price: editGame.Price,
            //     ReleaseDate: editGame.ReleaseDate
            // );
            var existingGame = await dbContext.Games.FindAsync(id);
            if (existingGame is null)
            {
                return Results.NotFound();
            }
            dbContext.Entry(existingGame).CurrentValues.SetValues(editGame.ConvertToEntity(id));
            await dbContext.SaveChangesAsync();
            return Results.Ok();
        });

        group.MapDelete("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            // games.RemoveAll(game => game.Id == id);

            var item = await dbContext.Games.FindAsync(id);
            if (item is null)
            {
                return Results.NotFound();
            }

            // await dbContext.Games.Remove(item);
            // await dbContext.SaveChangesAsync();

            await dbContext.Games.Where(game => game.Id == id).ExecuteDeleteAsync();

            return Results.NoContent();
        });

        return group;
    }

}