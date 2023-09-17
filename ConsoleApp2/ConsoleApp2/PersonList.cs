using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class PersonList
    {
        private static PersonList instance;
        private Dictionary<String, Person> personMap;

        private PersonList()
        {
            personMap = new Dictionary<string, Person>();
        }

        public static PersonList getInstance()
        {

            if (instance == null)
                instance = new PersonList();

            return instance;
        }

        public void addPerson(Person person)
        {
            if (person == null)
                throw new ArgumentException();
            personMap.Add(person.getName(), person);
        }

        public IEnumerable<Person> personList()
        {
            return personMap.Values.AsEnumerable();
        }
    }
}
