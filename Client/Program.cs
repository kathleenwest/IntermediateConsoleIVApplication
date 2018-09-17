using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonLib;

namespace Client
{
    /// <summary>
    /// Main Client Console Application
    /// Interacts with PersonLib to Create
    /// Person objects using a FactoryMethod through a
    /// Singleton instance
    /// </summary>
    class Program
    {   
        /// <summary>
        /// Main method for TestDriver
        /// </summary>
        /// <param name="args">No arguments processed</param>
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();          // List of Person objects
            PersonFactory factory = PersonFactory.Instance;     // Singleton FactoryMethod pattern
            Person clone = null;                                // Person object used for cloning
           
            // Create 5+ Person Objects and Place in List
            persons.Add(factory.Create(314887771, "West", "Kathleen", new DateTime(1981, 01, 19)));
            persons.Add(factory.Create(314887772, "West", "Jared", new DateTime(1978, 09, 18)));
            persons.Add(factory.Create(314887773, "Wendling", "Caralyn", new DateTime(1981, 09, 15)));
            persons.Add(factory.Create(314887774, "Williams", "Dannie", new DateTime(1947, 11, 25)));
            persons.Add(factory.Create(314887775, "Wendling", "Carson", new DateTime(2014, 02, 25)));
            persons.Add(factory.Create(314887776, "Wendling", "Owen", new DateTime(2017, 03, 18)));

            // Create a Clone of Owen called Oliver. Actually Oliver is a real-life twin of Owen!
            clone = persons.Last().Clone() as Person;
            clone.FirstName = "Oliver";
            persons.Add(clone);

            // Create a clone of myself
            clone = persons.Find(n => n.FirstName == "Kathleen").Clone() as Person;
            clone.LastName = "Williams";
            persons.Add(clone);

            // Output the Header for Persons List
            Console.WriteLine(Person.GetHeader());

            // Ouput List of each Person
            foreach (Person item in persons)
            {
                Console.WriteLine(item.ToString());
            }

            // Wait for the User Input
            Console.Write("Press <ENTER> to quit...");
            Console.ReadLine();

        } // end of method
    } // end of class
} // end of namespace
