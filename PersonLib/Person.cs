using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLib
{
    /// <summary>
    /// Model that contains all the properties and backing fields
    /// necessary to identify a person with actions and formatting.
    /// </summary>
    public class Person : ICloneable
    {
        #region fields and properties

        // Backing fields for the properties
        private int _ID;
        private string _LastName;
        private string _FirstName;
        private DateTime _DOB;

        // Object for the GetAge() method Time Span 
        private TimeSpan diff;

        /// <summary>
        /// ID (int) for the Person
        /// Must be 9 digits in Length
        /// Private Set
        /// </summary>
        public int ID
        {
            get
            {
                return _ID;
            }

            private set
            {
                if (value.ToString().Length == 9)
                {
                    _ID = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("ID", "The ID must be 9 digits");
                }                
            }
        }

        /// <summary>
        /// LastName (string) for the Person
        /// Must not be empty or blank
        /// </summary>
        public string LastName 
        {
            get
            {
                return _LastName;
            }

            set
            {
                if (value.ToString().Trim().Length > 0)
                {
                    _LastName = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Last Name", "The Last Name must not be empty");                  
                }
            }
        }

        /// <summary>
        /// FirstName (string) for the Person
        /// Must not be empty or blank
        /// </summary>
        public string FirstName 
        {
            get
            {
                return _FirstName;
            }

            set
            {
                if (value.ToString().Trim().Length > 0)
                {
                    _FirstName = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Last Name", "The Last Name must not be empty");                  
                }
            }
        }

        /// <summary>
        /// DOB (DateTime) for the Person
        /// Must not be in the future
        /// </summary>
        public DateTime DOB 
         {
            get
            {
                return _DOB;
            }

            set
            {
                if (value <= DateTime.Now)
                {
                    _DOB = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("DOB", "The DOB cannot be in the future");                  
                }
            }
        }

        #endregion fields and properties

        #region constructors

        /// <summary>
        /// fully-parameterized constructor
        /// </summary>
        /// <param name="id">ID (int) of the Peron</param>
        /// <param name="lastName">LastName (string) of the Person</param>
        /// <param name="firstName">FirstName (string) of the Person</param>
        /// <param name="dob">DOB (DateTime) of the Person</param>
        internal Person(int id, string lastName, string firstName, DateTime dob)
        {
            ID = id;
            LastName = lastName;
            FirstName = firstName;
            DOB = dob;
        }

        /// <summary>
        /// copy constructor
        /// </summary>
        /// <param name="other">Object (Person) to copy (shallow) objects</param>
        public Person(Person other)
        {
            ID = other.ID;
            LastName = other.LastName;
            FirstName = other.FirstName;
            DOB = other.DOB;
        }

        #endregion constructors

        #region methods

        /// <summary>
        /// Shallow Clone This
        /// </summary>
        /// <returns>Object (Person) shallow clone of this</returns>
        public object Clone()
        {
            return new Person(this);
        }

        /// <summary>
        /// Method that returns the age of the person in years based on the 
        /// difference between the current date and their DOB.
        /// </summary>
        /// <returns>Age (int) </returns>
        public int GetAge()
        {
            diff = DateTime.Now.Subtract(DOB);
            return diff.Days / 365;
        }

        /// <summary>
        /// Returns the person’s ID (last 4 digits only) 
        /// in the following format:XXX-XX-1234
        /// </summary>
        /// <returns>string</returns>
        public string GetFormattedID()
        {
            return $"XXX-XX-" + ID.ToString().Substring(5);
        }

        /// <summary>
        /// Displays the person object information in a 
        /// consistent, tabular format.
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            return $"{GetFormattedID(),-11} {LastName, -15} {FirstName, -10} {GetAge(),3}";
        }

        /// <summary>
        /// Displays a header appropriate for 
        /// the output of the Person object ToString()
        /// </summary>
        /// <returns>String</returns>
        public static string GetHeader()
        {
            return $"{"ID",-11} {"Last Name",-15} {"First Name",-10} {"Age",3}";
        }

        #endregion methods

    } // end of class
} // end of namespace
