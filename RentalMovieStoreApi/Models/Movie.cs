using RentalMovieStoreApi.Models;

namespace RentalMovieStoreApi.Entities;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public EnumGenreMovie Genre { get; set; }
    public int ReleaseYear { get; set; }
    public EnumParentalRatingMovie ParentalRating { get; set; }

}
