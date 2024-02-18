using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
  
        public void Delete(string title)
        {
            var existingMovie = _movies.FirstOrDefault(m => m.Title == title);
            _movies.Remove(existingMovie);
        }


    }
}
