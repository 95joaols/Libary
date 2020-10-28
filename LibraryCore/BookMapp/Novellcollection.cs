using System;

namespace LibraryCore.BookMapp
{
    public class Novellcollection : Book
    {
        public override BookType Type => BookType.Novellcollection;

        public Novellcollection(string titel, string writer, DateTime publication)
        {
            Title = titel;
            Writer = writer;
            Publication = publication;
        }

        public override string ToString()
        {
            return $"[Novellcollection]\t{Title}\t{Writer}\t{Publication.Date.ToString("yyy-MM-dd")}";
        }
    }
}