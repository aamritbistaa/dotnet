﻿using GameStore.Api.Dtos;
using GameStore.Api.Entities;

namespace GameStore.Api.Mapping;

public static class GameMapping
{
    public static Game ConvertToEntity(this CreateGameDto game)
    {
        return new Game()
        {

            Name = game.Name,
            GenreId = game.GenreId,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate

        };
    }
    public static Game ConvertToEntity(this UpdateGameDto game, int id)
    {
        return new Game()
        {
            Id = id,
            Name = game.Name,
            GenreId = game.GenreId,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate

        };
    }

    public static GameSummaryDto ConvertToGameSummaryDto(this Game game)
    {
        return new(
                game.Id,
                game.Name,
                game.Genre!.Name,
                game.Price,
                game.ReleaseDate
            );
    }
    public static GameDetailsDto ConvertToGameDetailsDto(this Game game)
    {
        return new(
                game.Id,
                game.Name,
                game.GenreId,
                game.Price,
                game.ReleaseDate
            );
    }

}
