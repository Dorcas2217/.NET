using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp2
{
    internal class Person 
    {
        private static readonly long serialVersionUID = 1L;

        private readonly String name;
	private readonly String firstname;
	private readonly DateTime birthDate;
	
	public String getName()
        {
            return name;
        }

        public String getFirstname()
        {
            return firstname;
        }

        public String getBirthDate()
        {
             
            return birthDate.ToString();
        }


        public Person(String name, String firstname, DateTime birthDate)
        {
            this.name = name;
            this.firstname = firstname;
            this.birthDate = birthDate;
        }

       
    public  String ToString()
        {
      
            return "Person [name = " + name + ", firstname = " + firstname + ", birthDate =  " + getBirthDate() + "]";
        }
    }

   

    
    
}
