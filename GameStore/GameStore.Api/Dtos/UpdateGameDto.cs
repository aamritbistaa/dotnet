using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

public record class UpdateGameDto
(
    [Required][StringLength(50)] string Name,
    [Required] int GenreId,
    [Required][Range(1, 50)] decimal Price,
    [Required] DateOnly ReleaseDate
);