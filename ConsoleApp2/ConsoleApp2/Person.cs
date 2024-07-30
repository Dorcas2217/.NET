using System;
using System.Globalization;

namespace ConsoleApp2
{
    [Serializable]
    public class Person
    {
        private readonly string name;
        private readonly string firstname;
        private readonly DateTime birthDate;

        public virtual string Name => name;
        public string Firstname => firstname;

        public string BirthDate
        {
            get
            {
                return birthDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
            }
        }

        public Person(string name, string firstname, DateTime birthDate)
        {
            this.name = name;
            this.firstname = firstname;
            this.birthDate = birthDate;
        }

        public override string ToString()
        {
            return $"Person [name = {Name}, firstname = {Firstname}, birthDate = {BirthDate}]";
        }
    }
}
