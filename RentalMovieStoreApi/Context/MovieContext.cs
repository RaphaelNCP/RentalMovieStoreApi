using Microsoft.EntityFrameworkCore;
using RentalMovieStoreApi.Entities;

namespace RentalMovieStoreApi.Context;

public class MovieContext(DbContextOptions<MovieContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies { get; set; }
}
