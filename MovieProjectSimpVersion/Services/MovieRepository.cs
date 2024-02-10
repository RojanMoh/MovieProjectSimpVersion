using Microsoft.AspNetCore.Mvc;
using MovieProjectSimpVersion.Models;
using MovieProjectSimpVersion.Repository;
using MovieProjectSimpVersion.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieProjectSimpVersion.Services
{
    public class MovieRepository : IMovieRepository
    {
        private static List<Movie> _movies = new List<Movie>
            {
                new Movie{Id=1, Title="Titanic",Year=1996,Genre=" classic"},
                new Movie{Id=2, Title="Jurassic Park",Year=1993, Genre="Advanture"},
                new Movie{Id=3, Title="Fight club",Year=1999, Genre="Action"},
                new Movie{Id=4, Title="Frozen",Year=2017, Genre = "Animation"},
            };

        public MovieRepository()
        {
            
        }

        public IEnumerable<Movie> GetAllMovie()
        {
            return _movies;
        }

        public void Add(Movie movie)
        {
            // Generate a new ID for the movie
            int newId = _movies.Count > 0 ? _movies.Max(m => m.Id) + 1 : 1;

            // Set the ID of the movie
            movie.Id = newId;

            // Add the movie to the list
            _movies.Add(movie);
        }

        public void Update(int id, Movie updatedMovie)
        {
            var existingMovie = _movies.FirstOrDefault(m => m.Id == id);
            if (existingMovie != null)
            {
                // Update the existing movie with the new data
                existingMovie.Title = updatedMovie.Title;
                existingMovie.Year = updatedMovie.Year;
                existingMovie.Genre = updatedMovie.Genre;
            }
            else
            {
                throw new KeyNotFoundException($"Movie with ID {id} not found.");
            }
        }
        public void Delete(string title)
        {
            // Remove the movie with the specified title from the list
            var movieToDelete = _movies.FirstOrDefault(m => m.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (movieToDelete != null)
            {
                _movies.Remove(movieToDelete);
            }
            else
            {
                throw new KeyNotFoundException($"Movie with title '{title}' not found.");
            }
        }

        public Movie GetMovie(int id)
        {
            return _movies.FirstOrDefault(m => m.Id == id);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
