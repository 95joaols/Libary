using System;

namespace LibraryCore.BookMapp
{
    /// <summary>
    /// this is all position in a DateTime that you can edit
    /// </summary>
    public enum DateTimeEditType : int
    {
        Millennium = 0,
        centenary = 1,
        decade = 2,
        year = 3,
        tenMonths = 4,
        months = 5,
        tenDay = 6,
        day = 7

    }

    /// <summary>
    /// This BookTemple is a temple of book
    /// To make it easyer to make a book and freely change the propety.
    /// <list type="bullet">
    /// <item>
    /// <term>SetASpecialNumberInDateTime</term>
    /// <description>This set a the chosen mumber in the DateTime</description>
    /// </item>
    /// <item>
    /// <term>ConvertToBook</term>
    /// <description>Convert this to Book class</description>
    /// </item>
    /// </list>
    /// </summary>
    public class BookTemple
    {
        public string Title
        {
            get;
            set;
        }
        public string Writer
        {
            get;
            set;
        }
        public DateTime Publication
        {
            get;
            set;
        }

        public BookType Type
        {
            get;
            set;
        }

        /// <summary>
        /// Seting the chosen number <to> in the DateTime
        /// </summary>
        /// <param name="dateTimeEdit">What is the pos in the dateTime</param>
        /// <param name="to">What do you want to set it to</param>
        /// <remarks>
        /// <para>If the datetime is outside the datetime valu(Like 2020-50-70) it will trow a error</para>
        /// </remarks>
        /// <exception cref="System.Exception">Thrown when the datetime is outside the datetime valu </exception>
        public void SetASpecialNumberInDateTime(DateTimeEditType dateTimeEdit, int to)
        {
            //dateTimeCharts = dTC
            char[] dTC = Publication.ToString("yyyyMMdd").ToCharArray();
            dTC[(int) dateTimeEdit] = to.ToString().ToCharArray() [0];

            string yearS = char.GetNumericValue(dTC[0]).ToString() + char.GetNumericValue(dTC[1]).ToString() + char.GetNumericValue(dTC[2]).ToString() + char.GetNumericValue(dTC[3]).ToString();
            string monthsS = char.GetNumericValue(dTC[4]).ToString() + char.GetNumericValue(dTC[5]).ToString() + "";
            string dayS = char.GetNumericValue(dTC[6]).ToString() + char.GetNumericValue(dTC[7]).ToString() + "";

            if (int.TryParse(yearS, out int year) &&
                int.TryParse(monthsS, out int mouths) &&
                int.TryParse(dayS, out int day))
            {
                Publication = new DateTime(year, mouths, day);
            }
        }

        /// <summary>
        /// this will convert this to a Book type
        /// </summary>
        /// <returns>
        /// the book obj of this obj
        /// </returns>
        public Book ConvertToBook()
        {
            switch (Type)
            {
                case BookType.Journal:
                    return new Journal(Title, Writer, Publication);

                case BookType.Novel:
                    return new Novel(Title, Writer, Publication);

                case BookType.Novellcollection:
                    return new Novellcollection(Title, Writer, Publication);

                default:
                    return null;
            }
        }
    }
}