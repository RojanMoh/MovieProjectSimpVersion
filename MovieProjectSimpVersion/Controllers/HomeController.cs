using Microsoft.AspNetCore.Mvc;
using MovieProjectSimpVersion.Models;
using MovieProjectSimpVersion.Repository;
using MovieProjectSimpVersion.Services;
using System;
using System.Diagnostics;

namespace MovieProjectSimpVersion.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieRepository _movRepository;

        public HomeController(ILogger<HomeController> logger, IMovieRepository movieRepository)
        {
            _logger = logger;
            _movRepository = movieRepository;
        }

        public IActionResult Index()
        {
            var movies = _movRepository.GetAllMovie();
            var model = new MovieViewModel() { Movies = movies };
            return View(model);
        }

        // Action method to handle the request for getting movie details
        public IActionResult GetAllMovie()
        {
            var movies = _movRepository.GetAllMovie();
            return View(movies);

        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] MovieViewModel movieViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int yearResult = Int32.Parse(movieViewModel.Year);

                    // Extract the movie details from the view model
                    var newMovie = new Movie
                    {
                        Title = movieViewModel.Title,
                        Year = yearResult,
                        Genre = movieViewModel.Genre
                    };

                    // Add the new movie to the repository
                    _movRepository.Add(newMovie);

                    return Ok(); // Return 200 OK status if successful
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred while adding movie");
                    return BadRequest(); // Return 400 Bad Request status if an error occurs
                }
            }

            return BadRequest(); // Return 400 Bad Request status if model state is invalid
        }

   
        
            [HttpPost]
            public IActionResult DeleteMovie([FromBody] MovieViewModel movieViewModel)
            {
                try
                {
                    // Delete the movie from the repository
                    _movRepository.Delete(movieViewModel.Title);
                    

                    return Ok(); // Return 200 OK status if successful
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred while deleting movie");
                    return BadRequest(); // Return 400 Bad Request status if an error occurs
                }
            }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
