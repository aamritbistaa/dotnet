using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;
public record class CreateGameDto(

    [Required][StringLength(50)] string Name,
    [Required] int GenreId,
    [Required][Range(1, 50)] decimal Price,
    [Required] DateOnly ReleaseDate
);

// public class CreateGameDto
// {
//     public string Name { get; }
//     public string Genre { get; }
//     public decimal Price { get; }
//     public DateOnly ReleaseDate { get; }

//     public CreateGameDto(string Name, string Genre, decimal Price, DateOnly ReleaseDate)
//     {
//         this.Name = Name;
//         this.Genre = Genre;
//         this.Price = Price;
//         this.ReleaseDate = ReleaseDate;

//     }
// }