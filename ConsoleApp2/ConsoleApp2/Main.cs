using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Actor[] myActors =  {
                new Actor( "Assange", "Julian", new DateTime(1961, 6, 3), 187),
                new Actor( "Paul", "Newmann", new DateTime(1925, 1, 26), 187),
                new Actor( "Becker", "Norma Jean", new DateTime(1926, 5, 1), 187)
        };

            Director[] myDirectors = {
                // month start 0
                new Director("Spielberg", "Steven", new DateTime(1946, 11, 18)),
                new Director("Coen", "Ettan", new DateTime(1957, 8, 21)),
                new Director("Coppolla", "Francis Ford", new DateTime(1939, 3, 7))
        };


            Movie bigLebow = new("The Big Lebowski", 1996);
            Movie eT = new("E.T.", 1982);

            eT.AddActor(myActors[0]);
            eT.AddActor(myActors[2]);
            eT.Director(myDirectors[0]);

            bigLebow.AddActor(myActors[1]);
            bigLebow.AddActor(myActors[2]);
            bigLebow.Director(myDirectors[1]);

            PersonList myPersons = PersonList.Instance;

            foreach (Actor act in myActors)
            {
                myPersons.AddPerson(act);
            }

            foreach (Director director in myDirectors)
            {
                myPersons.AddPerson(director);
            }

            IEnumerable<Person> personIt = myPersons.GetPersonList();
            foreach (Person person in personIt)
            {
                Console.WriteLine(person);

                IEnumerable<Movie> moviesIt;
                if (person is Actor actor)
                {
                    Console.WriteLine("a joué dans les films suivants ");
                    moviesIt = actor.Movies();
                }
                else if (person is Director director)
                {
                    Console.WriteLine("a dirigé les films suivants :");
                    moviesIt = director.Movies();
                }
                else
                {
                    Console.WriteLine("est inconnu et n'a rien à faire ici !!! ");
                    continue;
                }

                foreach (Movie movie in moviesIt)
                {
                    Console.WriteLine(movie);
                }
            }
        }
    }
}
