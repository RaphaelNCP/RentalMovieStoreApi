using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalMovieStoreApi.Context;
using RentalMovieStoreApi.Entities;

namespace RentalMovieStoreApi.Controllers;
[Route("[controller]")]
[ApiController]
public class MoviesController(MovieContext context) : ControllerBase
{
    private readonly MovieContext _context = context;

    [HttpPost]
    public IActionResult RegisterMovie(Movie movie)
    {
        _context.Movies.Add(movie);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
    }

    [HttpGet]
    public IActionResult GetAllMovies()
    {
        return Ok(_context.Movies.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetMovie(int id)
    {
        Movie movie = _context.Movies.Find(id);

        if (movie == null) return NotFound();

        return Ok(movie);
    }

    [HttpGet("search")]
    public IActionResult SearchMovie(string title)
    {
        List<Movie> movies = _context.Movies.Where(m => m.Title.Contains(title)).ToList();

        if (movies.Count == 0) return NotFound();

        return Ok(movies);

    }

    [HttpPut("{id}")]
    public IActionResult UpdateMovie(int id, Movie movie)
    {
        Movie currentMovie = _context.Movies.Find(id);
        if (currentMovie == null) return NotFound();

        currentMovie.Title = movie.Title;
        currentMovie.Director = movie.Director;
        currentMovie.Genre = movie.Genre;
        currentMovie.ReleaseYear = movie.ReleaseYear;
        currentMovie.ParentalRating = movie.ParentalRating;

        _context.Movies.Update(currentMovie);
        _context.SaveChanges();

        return Ok(currentMovie);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id)
    {
        Movie movie = _context.Movies.Find(id);
        if (movie == null) return NotFound();
        _context.Movies.Remove(movie);
        _context.SaveChanges();
        return Ok();
    }


}
