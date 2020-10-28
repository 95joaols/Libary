using System;

namespace LibraryCore.BookMapp
{
    public class Novel : Book
    {
        public override BookType Type => BookType.Novel;

        public Novel(string titel, string writer, DateTime publication)
        {
            Title = titel;
            Writer = writer;
            Publication = publication;
        }

        public override string ToString()
        {
            return $"[Novel]\t\t\t{Title}\t{Writer}\t{Publication.Date.ToString("yyy-MM-dd")}";
        }
    }
}