namespace MovieProjectSimpVersion.Models
{
    public class MovieViewModel
    {
        public IEnumerable<Movie>? Movies { get; set; }
        
        
            // Properties for movie details
            public string Title { get; set; }
            public string Year { get; set; }
            public string Genre { get; set; }
        

    }
}
