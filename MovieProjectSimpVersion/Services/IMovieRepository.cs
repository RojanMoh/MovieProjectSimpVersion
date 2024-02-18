using MovieProjectSimpVersion.Models;

namespace MovieProjectSimpVersion.Repository
{
    public interface IMovieRepository
    {
        // CRUD operations
        void Add(Movie movie);
        //void Update(int id, Movie updatedMovie);
       // void Delete(int id);
        IEnumerable<Movie> GetAllMovie();
        //Movie GetMovie(int id);
        void Delete(string title);
    }
}
