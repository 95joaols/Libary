using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Faker;
using LibraryCore.BookMapp;

namespace LibraryCore
{
    /// <summary>
    /// The <c>Library</c> class.
    /// Contains all Book and prosessing the list
    /// <list type="bullet">
    /// <item>
    /// <term>GetListOfBooksSearch</term>
    /// <description>get the list of books on what you are searching on</description>
    /// </item>
    /// <item>
    /// <term>GetListAllBooks</term>
    /// <description>Get all books that is in the <c>Library</c></description>
    /// </item>
    /// <item>
    /// <term>AddBook(Book </term>
    /// <description>add a book to the <c>Library</c></description>
    /// </item>
    /// <item>
    /// <term>AddBook(List Book)</term>
    /// <description>add a list of book to the <c>Library</c></description>
    /// </item>
    /// </list>
    /// </summary>
    public class Library
    {
        private List<Book> books = new List<Book>();
        private const string FilePath = "LibaryBooksData.csv";

        public Library()
        {
            Load();
            if (books.Count < 5)
            {
                GenerateNewBook(5 - books.Count);
            }
        }

        /// <summary>
        /// get string from user and get a list if it match to (titel,Writer,Publication) and is not casesenity
        /// </summary>
        /// <returns>
        /// You will get all books that matsch the search
        /// </returns>
        /// <remarks>
        /// if the search if \"\" you will get all books
        /// </remarks>
        /// <param name="search"></param>
        public List<Book> GetListOfBooksSearch(String search)
        {
            List<Book> whereList = books.Where(book => book.Searchable().ToLower()
                    .Contains(search.ToLower()))
                .OrderBy(book => book.Writer)
                .ThenByDescending(book => book.Publication).ToList();

            //Return New list and new book so it cant motdifie the origenal
            List<Book> ReturnList = new List<Book>();
            foreach (Book book in whereList)
            {
                ReturnList.Add(CreateBook(book.Type, book.Title, book.Writer, book.Publication));
            }
            return ReturnList;
        }

        /// <summary>
        /// Get all books that is in the <c>Library</c>
        /// </summary>
        /// <returns>
        /// Get the list book that is in the libary
        /// </returns>
        public List<Book> GetListAllBooks()
        {
            //Return New list and new book so it cant motdifie the origenal
            List<Book> ReturnList = new List<Book>();
            foreach (Book book in books)
            {
                ReturnList.Add(CreateBook(book.Type, book.Title, book.Writer, book.Publication));
            }
            return books;
        }

        /// <summary>
        /// this take a book and validate if it is ok it add it to the list if not retun falce
        /// </summary>
        /// <returns>
        /// reruns if the book is valled and added to the list
        /// </returns>
        /// <param name="book">The book you want to add in the list</param>
        public bool AddBook(Book book, bool save = true)
        {
            if (book == null || String.IsNullOrWhiteSpace(book.Title) || String.IsNullOrWhiteSpace(book.Writer))
            {
                return false;
            }
            else
            {
                books.Add(book);
                if (save)
                {
                    return Save();
                }
                return true;
            }
        }

        /// <summary>
        /// this take a list book and validate if it is ok it add it to the list
        /// </summary>
        /// <returns>
        /// reruns is true if all book is valed and added
        /// </returns>
        /// <param name="boosk">The list of book you want to add in the list</param>
        public bool AddBook(List<Book> books)
        {
            bool AllOK = true;
            foreach (Book book in books)
            {
                if (!AddBook(book))
                {
                    AllOK = false;
                }
            }
            return AllOK;
        }

        private bool Save()
        {
            // List<string> bookCSV = books.Select(book => book.CSVFormat).ToList();
            List<string> save = new List<string>();
            save.Add(books[books.Count - 1].CSVFormat);
            try
            {
                File.AppendAllLines(FilePath, save);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool Load()
        {
            bool allOK = true;

            string[] rowBooks;
            try
            {
                rowBooks = File.ReadAllLines(FilePath);

            }
            catch
            {
                return false;
            }
            foreach (string rowbook in rowBooks)
            {
                //(int)BookType,titel,writer,publication
                string[] bookRow = rowbook.Split(',');
                if (int.TryParse(bookRow[0], out int bookTypeInt) &&
                    DateTime.TryParse(bookRow[3], out DateTime publication))
                {
                    BookType bookType = (BookType) bookTypeInt;

                    AddBook(CreateBook(bookType, bookRow[1], bookRow[2], publication), false);
                    continue;
                }
                else
                {
                    allOK = false;
                }
                continue;
            }
            return allOK;
        }
        private void GenerateNewBook(int n)
        {
            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                BookType bookType = (BookType) random.Next(0, Enum.GetValues(typeof(BookType)).Length);
                string titel = Faker.InternetFaker.Domain().Split('.') [0];
                string writer = NameFaker.Name();
                DateTime publication = Faker.DateTimeFaker.DateTime(DateTime.Parse("1700-01-01"), DateTime.Now);

                AddBook(CreateBook(bookType, titel, writer, publication));
            }
        }

        private Book CreateBook(BookType bookType, string titel, string writer, DateTime publication)
        {
            Book book = null;
            switch (bookType)
            {
                case BookType.Journal:
                    book = new Journal(titel, writer, publication);
                    break;
                case BookType.Novel:
                    book = new Novel(titel, writer, publication);
                    break;
                case BookType.Novellcollection:
                    book = new Novellcollection(titel, writer, publication);
                    break;
                default:
                    break;
            }
            return book;
        }
    }
}