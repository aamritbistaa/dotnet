using GameStore.Api.Data;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.EndPoints;

public static class GenreEndpoints
{

    public static RouteGroupBuilder MapGenresEndPoints(this WebApplication app)
    {

        var group = app.MapGroup("genre");
        group.MapGet("/", async (GameStoreContext dbContext) =>
        {
            return await dbContext.Genres.Select(genre => genre.ConvertToDto()).ToListAsync();


        });
        return group;
    }
}
