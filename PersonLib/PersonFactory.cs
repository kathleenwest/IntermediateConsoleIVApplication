using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLib
{ 
    /// <summary>
    /// This model as the factory to create Person objects. It is
    /// implemented using the Singleton design pattern.
    /// </summary>
    public class PersonFactory
    {
        #region fields and properties

        private static PersonFactory _Instance = null;

        /// <summary>
        /// Singleton Pattern
        /// Creates Person Factory
        /// </summary>
        public static PersonFactory Instance
        {
            get
            {
                return _Instance;
            }

            private set
            {
                _Instance = value;
            }
        }

        #endregion fields and properties

        #region constructors

        /// <summary>
        /// Singleton Constructor
        /// </summary>
        static PersonFactory()
        {
            _Instance = new PersonFactory();
        }

        /// <summary>
        /// Private Constructor
        /// Used only by the Singleton
        /// </summary>
        private PersonFactory()
        {
        }

        #endregion constructors

        /// <summary>
        /// Creates a Person object through the instance of
        /// the PersonFactory instance (Singleton)
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="LastName"></param>
        /// <param name="FirstName"></param>
        /// <param name="DOB"></param>
        /// <returns>Object (Person)</returns>
        public Person Create(int ID, string LastName, string FirstName, DateTime DOB)
        {
            return new Person(ID, LastName,FirstName,DOB);
        }

    } // end of class
} // end of namespace
