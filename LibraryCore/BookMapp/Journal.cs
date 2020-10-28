using System;

namespace LibraryCore.BookMapp
{
    public class Journal : Book
    {
        public override BookType Type => BookType.Journal;

        public Journal(string titel, string writer, DateTime publication)
        {
            Title = titel;
            Writer = writer;
            Publication = publication;
        }

        public override string ToString()
        {
            return $"[Journal]\t\t{Title}\t{Writer}\t{Publication.Date.ToString("yyyy-MM-dd")}";
        }
    }
}