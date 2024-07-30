using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Movie
    {
        private String title;
        private int releaseYear;
        private List<Actor> actors;
        private Director director;


        public Movie(string title, int releaseYear)
        {
            actors = new List<Actor>();
            this.title = title;
            this.releaseYear = releaseYear;
        }

        public Director Director()
        {
            return director;
        }
        public void Director(Director director)
        {
            if (director == null)
                return;
            this.director = director;
            director.addMovie(this);
        }

        public string Title()
        {
            return title;
        }
        public void Title(String title)
        {
            this.title = title;
        }
        public int ReleaseYear()
        {
            return releaseYear;
        }
        public void ReleaseYear(int releaseYear)
        {
            this.releaseYear = releaseYear;
        }

        public bool AddActor(Actor actor)
        {
            if (actors.Contains(actor))
                return false;

            actors.Add(actor);
            if (!actor.ContainsMovie(this))
                actor.AddMovie(this);

            return true;
        }

        public bool ContainsActor(Actor actor)
        {
            return actors.Contains(actor);
        }

        
    public override string ToString()
        {
            return "Movie [title=" + title + ", releaseYear=" + releaseYear + "]";
        }

    }
}
