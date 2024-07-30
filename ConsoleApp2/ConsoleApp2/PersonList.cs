using ConsoleApp2;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Security;

namespace ConsoleApp2
{
    public class PersonList
    {
        private static PersonList instance;
        private readonly Dictionary<string, Person> personMap;

        private PersonList()
        {
            personMap = new Dictionary<string, Person>();
        }

        public static PersonList Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PersonList();
                }
                return instance;
            }
        }

        public void AddPerson(Person person)
        {
            if (person == null)
            {
                throw new InvalidParameterException("Person cannot be null");
            }
            personMap[person.Name] = person;
        }

        public IEnumerable<Person> GetPersonList()
        {
            return personMap.Values;
        }
    }
}
