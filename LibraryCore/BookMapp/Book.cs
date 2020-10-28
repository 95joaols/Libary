using System;

namespace LibraryCore.BookMapp
{
    /// <summary>
    /// The <c>Book</c> class.
    /// Is the the abstract class for its sub classes
    /// <list type="bullet">
    /// <item>
    /// <term>CSVFormat</term>
    /// <description>Get the CSV format ot the class</description>
    /// </item>
    /// <item>
    /// <term>Searchable</term>
    /// <description>give all test that you shud Search on</description>
    /// </item>
    /// <item>
    /// <term>ToString</term>
    /// <description>get a description of the class</description>
    /// </item>
    /// </list>
    public abstract class Book
    {
        public string Title
        {
            get;
            protected set;
        }
        public string Writer
        {
            get;
            protected set;
        }
        public DateTime Publication
        {
            get;
            protected set;
        }
        /// <summary>
        /// Get the CSV format ot the class
        /// </summary>
        /// <returns>
        /// CSV String
        /// </returns>
        public string CSVFormat => $"{(int)Type},{Title},{Writer},{Publication}";

        public abstract BookType Type
        {
            get;
        }
        /// <summary>
        /// this is if you want to easy Search the book
        /// </summary>
        /// <returns>
        /// get the core that you can Search on
        /// </returns>
        /// <remarks>
        /// this can be mixed of upper and lower case
        /// </remarks>
        public string Searchable()
        {
            return Title + Writer + Publication;
        }

        /// <summary>
        /// this send ToString() to the sub class of book
        /// </summary>
        /// <returns>
        /// get a description of the class
        /// </returns>
        public abstract override string ToString();
    }
}