using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Director : Person
    {
        private List<Movie> directedMovies;

        public Director(String name, String firstname, DateTime birthDate) : base(name, firstname, birthDate)
        {
            
            directedMovies = new List<Movie>();
        }

        public bool addMovie(Movie movie)
        {

            if (directedMovies.Contains(movie))
                return false;

            if (movie.Director() == null)
                movie.Director(this);

            directedMovies.Add(movie);

            return true;

        }

        public IEnumerable <Movie> Movies()
        {
            return directedMovies.AsEnumerable();
        }


    }
}
