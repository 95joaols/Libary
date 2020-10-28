using System;
using System.Collections.Generic;
using System.ComponentModel;
using LibraryCore;
using LibraryCore.BookMapp;

namespace LibraryConsole
{
    /// <summary>
    /// This i bylding all the Menu in this app
    /// <list type="bullet">
    /// <item>
    /// <term>ScrollableAndSelectableMenu</term>
    /// <description>This is use when you want to make a Menu you can skroll in(Like main Menu)</description>
    /// </item>
    /// <item>
    /// <term>AddBooksMenu</term>
    /// <description>This Menu will let the user to creake new books</description>
    /// </item>
    /// <item>
    /// <term>SearchableMenu</term>
    /// <description>This list all book and let the user search books</description>
    /// </item>
    /// </list>
    internal class Menu
    {
        const ConsoleColor SelektedColor = ConsoleColor.Blue;
        const ConsoleColor instructionColor = ConsoleColor.Red;

        const string instructionEnter = "press enter to chose the selekted option";
        const string instructionWrire = "you can use your keybord to write";
        const string instructionMoveUpAndDown = "use your up/down arrowkey to move up or down";
        const string instructionMovesideways = "use your Side Arrowkey to sideways or tab";
        const string instructionUpAndDowneChangeType = "use your up/down arrowkey to change the type";
        const string instructionUpAndDowneChangedate = "use your arrowkey to change the Date or press numer key";
        const string instructionEnterToGoBack = "press enter to go back";

        const string instructionEnterSave = "press enter to save and go back";

        /// <summary>
        /// This is the enum that is the main Menu
        /// </summary>
        public enum MainMenu : int
        {
            [Description("List and search books")]
            ListSearhBooks = 0, [Description("Add new books")]

            NewBooks = 1, [Description("Exit the program")]
            Exit = 2,
        }

        /// <summary>
        /// Create a Menu that you can scroll and select in <T> enum of chose
        /// </summary>
        /// <returns>
        /// the int Option in the enum
        /// </returns>
        /// <remarks>
        /// the enum most have to be int
        /// </remarks>
        /// <typeparamref name="T">
        /// The ennum thay you want Buld the Menu
        /// </typeparamref>
        public int ScrollableAndSelectableMenu<T>()
        {
            Array enumOptions = Enum.GetValues(typeof(T));

            int OptionIndex = 0;
            int maxIndex = enumOptions.Length - 1;
            ConsoleKeyInfo keyInfo;
            do
            {
                Console.Clear();
                Console.ForegroundColor = instructionColor;
                Console.WriteLine(capitalizeTheFirstLetter(instructionMoveUpAndDown) +
                    " and " + instructionEnter + ".");
                Console.WriteLine();
                Console.ResetColor();
                ConsoleLine();

                ListEnumWhidSelect(OptionIndex, enumOptions);

                do
                {
                    keyInfo = Console.ReadKey(true);
                    GetIndexWithKey(ref OptionIndex, keyInfo, maxIndex);
                } while (keyInfo.Key != ConsoleKey.Enter && keyInfo.Key != ConsoleKey.UpArrow && keyInfo.Key != ConsoleKey.DownArrow);

            }
            while (keyInfo.Key != ConsoleKey.Enter);

            return OptionIndex;
        }

        /// <summary>
        /// start the proseting to let the user adds books
        /// </summary>
        /// <param name="library">the libery you want to ad in.</param>
        public void AddBooksMenu(Library library)
        {
            //[0.y]Type,[1,y]title,[2.y]Writer,[3-10,y]DateTimeEditType
            TwoDIndex twoDIndex = new TwoDIndex();

            //DateTimeEditType dateTimeEditType; // = (DateTimeEditType) (twoDIndex.X - 3);
            List<BookTemple> bookTemples = new List<BookTemple>();
            bookTemples.Add(new BookTemple());

            //Seting up the type enum info like the max index in booktype
            int bookTypeMaxIndex = Enum.GetValues(typeof(BookType)).Length - 1;

            int maxRows = ((Console.WindowHeight - 9) / 2);
            int curentRow = 0;

            ConsoleKeyInfo keyInfo;

            do
            {
                //Make the editIndex in the limit
                twoDIndex.X = CheckAddIndex(twoDIndex.X, ref twoDIndex.Y, twoDIndex.MaxEditColum, ref curentRow, maxRows, bookTemples);
                //Make it easyer to know whitch we are edit on
                BookTemple curentEdit = bookTemples[twoDIndex.Y];

                Console.Clear();
                //Wriew out instration to user
                WriteAddBooksInstraion((int) twoDIndex.X);
                ConsoleLine();
                WriteHeder();
                ConsoleLine();

                WriteOutBookTemple(bookTemples, twoDIndex, curentRow, maxRows);

                keyInfo = Console.ReadKey(true);

                //This is so I can make ehe enum to be in ref(it is geting togeder att the end)
                int xRef = (int) twoDIndex.X;

                switch (twoDIndex.X)
                {
                    case EditColum.ChangeBookType: //Edit Type of book
                        ChangeBookType(curentEdit, keyInfo, bookTypeMaxIndex);
                        break;
                    case EditColum.Title: //Edit Title
                        string title = curentEdit.Title;
                        UserStringBuilder(keyInfo, ref title);
                        curentEdit.Title = title;
                        UpDowneControlProses(bookTemples, curentEdit, keyInfo, ref twoDIndex.Y, ref xRef);
                        break;
                    case EditColum.writer: //Edit writer
                        string writer = curentEdit.Writer;
                        UserStringBuilder(keyInfo, ref writer);
                        curentEdit.Writer = writer;
                        UpDowneControlProses(bookTemples, curentEdit, keyInfo, ref twoDIndex.Y, ref xRef);
                        break;
                    case EditColum.Millennium: //Edit DateTime
                    case EditColum.centenary:
                    case EditColum.decade:
                    case EditColum.year:
                    case EditColum.tenMonths:
                    case EditColum.months:
                    case EditColum.tenDay:
                    case EditColum.day:
                        ChangeDayTimeOnEdit(keyInfo, curentEdit, ref xRef);
                        break;

                    default:
                        break;
                }
                lefRihgtControl(keyInfo, ref xRef, ref twoDIndex.Y, twoDIndex.MaxEditColum);

                if (xRef > twoDIndex.MaxEditColum)
                {
                    twoDIndex.X = (EditColum) 0;
                    twoDIndex.Y++;

                    if (twoDIndex.Y > bookTemples.Count - 1)
                    {
                        bookTemples.Add(new BookTemple());
                    }
                }
                else if (xRef < 0)
                {
                    twoDIndex.X = (EditColum) twoDIndex.MaxEditColum;
                    twoDIndex.Y--;
                }
                else
                {
                    twoDIndex.X = (EditColum) xRef;
                }

            } while (keyInfo.Key != ConsoleKey.Enter && keyInfo.Key != ConsoleKey.Escape);

            //Cunvert the edit to book and seend it in library
            List<Book> booksToAdd = new List<Book>();
            foreach (BookTemple bookTemple in bookTemples)
            {
                booksToAdd.Add(bookTemple.ConvertToBook());
            }
            library.AddBook(booksToAdd);
        }

        /// <summary>
        /// start the proseting to let the user search books.
        /// </summary>
        /// <param name="library">the libery you want to search in.</param>
        public void SearchableMenu(Library library)
        {
            ConsoleKeyInfo keyInfo;
            string lastsearch = "";
            string search = "";
            int curentRow = 0;
            List<Book> books = library.GetListOfBooksSearch(search);

            do
            {
                if (lastsearch != search)
                {
                    books = library.GetListOfBooksSearch(search);
                    lastsearch = search;
                }
                int maxRows = Console.WindowHeight - 8;

                Console.Clear();
                Console.ForegroundColor = instructionColor;
                Console.WriteLine(instructionWrire + " and " + instructionEnterToGoBack);
                Console.ResetColor();
                Console.WriteLine();
                ConsoleLine();

                Console.WriteLine($"Searching on :{search}");
                WriteHeder();
                ConsoleLine();

                if (curentRow != 0)
                {
                    string topRow = PreperTextInColum("▲", 4);
                    topRow += PreperTextInColum("▲", 4);
                    topRow += PreperTextInColum("▲", 4);
                    topRow += PreperTextInColum("▲", 4);
                    Console.WriteLine(topRow);
                }
                for (int i = curentRow; i < maxRows + curentRow; i++)
                {

                    if (i < books.Count)
                    {
                        Book book = books[i];
                        if (search != "")
                        {
                            WriteInColumSearcingSplit(book.Writer, 4, search);
                            WriteInColumSearcingSplit(book.Title, 4, search);
                            Console.Write(PreperTextInColum(CodeToolsBox.GetEnumDescription(book.Type), 4));
                            WriteInColumSearcingSplit(book.Publication.ToString("yyyy/MM/ss"), 4, search);
                            Console.WriteLine();
                        }
                        else
                        {
                            WriteOutBoksInColums(book);
                        }
                    }
                }
                if (curentRow + maxRows < books.Count - 1)
                {
                    string bottomRow = PreperTextInColum("▼", 4);
                    bottomRow += PreperTextInColum("▼", 4);
                    bottomRow += PreperTextInColum("▼", 4);
                    bottomRow += PreperTextInColum("▼", 4);
                    Console.Write(bottomRow);
                }

                keyInfo = Console.ReadKey(true);
                UpDowneControl(keyInfo, ref curentRow, true);

                UserStringBuilder(keyInfo, ref search);
                if (lastsearch != search)
                {
                    curentRow = 0;
                }

                if (books.Count < maxRows)
                {
                    curentRow = 0;
                }
                else if (curentRow + maxRows > books.Count - 1)
                {
                    curentRow = (books.Count - 1) - maxRows;
                }

                if (curentRow < 0)
                {
                    curentRow = 0;
                }

            }
            while (keyInfo.Key != ConsoleKey.Enter);
        }

        private void WriteHeder()
        {
            string textToWritw = PreperTextInColum("Writer", 4);
            textToWritw += PreperTextInColum("Title", 4);
            textToWritw += PreperTextInColum("Type", 4);
            textToWritw += PreperTextInColum("Publication", 4);
            Console.WriteLine(textToWritw);
        }

        private string capitalizeTheFirstLetter(string input)
        {
            return char.ToUpper(input[0]) + input.Substring(1);
        }

        private void WriteAddBooksInstraion(int indexX)
        {
            Console.ForegroundColor = instructionColor;
            Console.Write(capitalizeTheFirstLetter(instructionMovesideways));
            if (indexX == 0)
            {
                Console.Write(" and " + instructionUpAndDowneChangeType);
            }
            else if (indexX > 2 && indexX < 11)
            {
                Console.Write(" and " + instructionUpAndDowneChangedate);
            }
            else if (indexX == 1 || indexX == 2)
            {
                Console.Write(" and " + instructionMoveUpAndDown + " if all collum is ok and " + instructionWrire);
            }
            Console.WriteLine(" " + instructionEnterSave);
            Console.WriteLine();
            Console.ResetColor();
        }

        private void WriteOutBoksInColums(Book book)
        {
            //The first is what type the book is and we wont be search on
            string textToWritw = PreperTextInColum(book.Writer, 4);
            textToWritw += PreperTextInColum(book.Title, 4);
            textToWritw += PreperTextInColum(CodeToolsBox.GetEnumDescription(book.Type), 4);
            textToWritw += PreperTextInColum(book.Publication.ToString("yyyy/MM/ss"), 4);

            Console.WriteLine(textToWritw);
        }

        private string PreperTextInColum(string writing, int maxColum)
        {
            writing = FixTextToColum(writing, maxColum);
            return writing;
        }
        private void WriteInColumSearcingSplit(string writing, int maxColum, string search)
        {
            writing = FixTextToColum(writing, maxColum);
            if (search != "" && writing.ToLower().Contains(search.ToLower()))
            {
                search = search.ToLower();
                string writingLower = writing.ToLower();
                string curentWriten = "";

                foreach (string splitedString in writingLower.Split(search, StringSplitOptions.None))
                {
                    string stringToWrite = writing.Substring(writingLower.IndexOf(splitedString), splitedString.Length);

                    AddMakeSearh(writing, search, ref curentWriten);
                    Console.Write(stringToWrite);
                    curentWriten += stringToWrite;
                    AddMakeSearh(writing, search, ref curentWriten);
                }
            }
            else
            {
                Console.Write(writing);
            }
        }
        private string FixTextToColum(string writing, int maxColum)
        {
            if (writing == null)
            {
                writing = "";
            }
            int columSise = Console.WindowWidth / maxColum;
            if (writing.Length > columSise - 1)
            {
                writing = writing.Remove(columSise - 4);
                writing += "...";
            }
            else
            {
                for (int i = writing.Length; i < columSise - 1; i++)
                {
                    writing += " ";
                }
            }
            return writing;
        }

        private void ConsoleLine()
        {
            string filings = "";
            for (int i = 0; i < Console.WindowWidth - 1; i++)
            {
                filings += "\u2500";
            }
            Console.WriteLine(filings);
        }
        private EditColum CheckAddIndex(EditColum x, ref int y, int maxX, ref int curentRow, int maxRows, List<BookTemple> bookTemples)
        {
            if (x < 0) x = 0;
            if ((int) x > maxX) x = (EditColum) maxX;
            if (y < 0) y = 0;
            if (y > bookTemples.Count - 1) bookTemples.Add(new BookTemple());
            if (bookTemples.Count < maxRows) curentRow = 0;
            if (maxRows + curentRow < y + 1) curentRow++;
            if (curentRow > y) curentRow--;

            return x;
        }

        private void UpDowneControlProses(List<BookTemple> bookTemples, BookTemple curentEdit, ConsoleKeyInfo keyInfo, ref int y, ref int x)
        {
            UpDowneControl(keyInfo, ref y, true);
            if (y > bookTemples.Count - 1)
            {
                bookTemples.Add(new BookTemple());
                x = 0;
            }
        }

        private void WriteOutBookTemple(List<BookTemple> bookTemples, TwoDIndex twoDIndex, int curentRow, int maxRows)
        {
            if (curentRow != 0)
            {
                string topRow = PreperTextInColum("▲", 4);
                topRow += PreperTextInColum("▲", 4);
                topRow += PreperTextInColum("▲", 4);
                topRow += PreperTextInColum("▲", 4);
                Console.WriteLine(topRow);
                ConsoleLine();
            }
            for (int i = curentRow; i < maxRows + curentRow; i++)
            {
                if (i < bookTemples.Count)
                {
                    BookTemple bookTemple = bookTemples[i];
                    if (twoDIndex.Y == bookTemples.IndexOf(bookTemple))
                    {
                        WriteOutCurentEditRow(twoDIndex.X, bookTemple);
                    }
                    else
                    {
                        string textToWritw = PreperTextInColum(bookTemple.Writer, 4);
                        textToWritw += PreperTextInColum(bookTemple.Title, 4);
                        textToWritw += PreperTextInColum(bookTemple.Type.ToString(), 4);
                        textToWritw += PreperTextInColum(bookTemple.Publication.ToString("yyyy-MM-dd"), 4);
                        Console.WriteLine(textToWritw);
                    }
                    ConsoleLine();
                }
            }
            if (curentRow + maxRows < bookTemples.Count)
            {
                string bottomRow = PreperTextInColum("▼", 4);
                bottomRow += PreperTextInColum("▼", 4);
                bottomRow += PreperTextInColum("▼", 4);
                bottomRow += PreperTextInColum("▼", 4);
                Console.WriteLine(bottomRow);
            }
        }
        private void WriteOutCurentEditRow(EditColum editColum, BookTemple bookTemple)
        {
            if (editColum == EditColum.writer)
            {
                Console.BackgroundColor = SelektedColor;
            }
            Console.Write(PreperTextInColum(bookTemple.Writer, 4));
            Console.ResetColor();

            if (editColum == EditColum.Title)
            {
                Console.BackgroundColor = SelektedColor;
            }
            Console.Write(PreperTextInColum(bookTemple.Title, 4));
            Console.ResetColor();

            if (editColum == EditColum.ChangeBookType)
            {
                Console.BackgroundColor = SelektedColor;
            }
            Console.Write(PreperTextInColum(bookTemple.Type.ToString(), 4));
            Console.ResetColor();

            char[] dTC = bookTemple.Publication.ToString("yyyyMMdd").ToCharArray();
            if (editColum == EditColum.Millennium)
            {
                Console.BackgroundColor = SelektedColor;
            }
            Console.Write(dTC[(int) DateTimeEditType.Millennium].ToString());
            Console.ResetColor();

            if (editColum == EditColum.centenary)
            {
                Console.BackgroundColor = SelektedColor;
            }
            Console.Write(dTC[(int) DateTimeEditType.centenary].ToString());
            Console.ResetColor();

            if (editColum == EditColum.decade)
            {
                Console.BackgroundColor = SelektedColor;
            }
            Console.Write(dTC[(int) DateTimeEditType.decade].ToString());
            Console.ResetColor();

            if (editColum == EditColum.year)
            {
                Console.BackgroundColor = SelektedColor;
            }
            Console.Write(dTC[(int) DateTimeEditType.year].ToString());
            Console.ResetColor();

            Console.Write("-");

            if (editColum == EditColum.tenMonths)
            {
                Console.BackgroundColor = SelektedColor;
            }
            Console.Write(dTC[(int) DateTimeEditType.tenMonths].ToString());
            Console.ResetColor();

            if (editColum == EditColum.months)
            {
                Console.BackgroundColor = SelektedColor;
            }
            Console.Write(dTC[(int) DateTimeEditType.months].ToString());
            Console.ResetColor();

            Console.Write("-");

            if (editColum == EditColum.tenDay)
            {
                Console.BackgroundColor = SelektedColor;
            }
            Console.Write(dTC[(int) DateTimeEditType.tenDay].ToString());
            Console.ResetColor();

            if (editColum == EditColum.day)
            {
                Console.BackgroundColor = SelektedColor;
            }
            Console.Write(dTC[(int) DateTimeEditType.day].ToString());
            Console.ResetColor();

            Console.WriteLine();
        }
        private void lefRihgtControl(ConsoleKeyInfo keyInfo, ref int curentIndex, ref int yindex, int maxIndex)
        {
            if (keyInfo.Key == ConsoleKey.LeftArrow)
            {
                if (curentIndex > 0)
                {
                    curentIndex--;
                }
                else
                {
                    curentIndex = maxIndex;
                    yindex--;
                }
            }
            else if (keyInfo.Key == ConsoleKey.RightArrow || keyInfo.Key == ConsoleKey.Tab)
            {
                if (curentIndex < maxIndex)
                {
                    curentIndex++;
                }
                else
                {
                    curentIndex = 0;
                    yindex++;
                }
            }
        }
        private void UpDowneControl(ConsoleKeyInfo keyInfo, ref int curentIndex, bool StopingAtZero)
        {
            if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                curentIndex++;
            }
            else if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                if (curentIndex > 0 || !StopingAtZero)
                {
                    curentIndex--;
                }
            }
        }
        private void ChangeDayTimeOnEdit(ConsoleKeyInfo keyInfo, BookTemple curentEdit, ref int columIndex)
        {
            int addTime = 0;
            UpDowneControl(keyInfo, ref addTime, false);
            addTime *= -1;
            if (addTime != 0)
            {
                switch ((DateTimeEditType) (columIndex - 3))
                {
                    case DateTimeEditType.Millennium:
                        try
                        {
                            curentEdit.Publication = curentEdit.Publication.AddYears(addTime * 1000);
                        }
                        catch (System.Exception)
                        { }
                        break;
                    case DateTimeEditType.centenary:
                        try
                        {
                            curentEdit.Publication = curentEdit.Publication.AddYears(addTime * 100);
                        }
                        catch (System.Exception)
                        { }
                        break;
                    case DateTimeEditType.decade:
                        try
                        {
                            curentEdit.Publication = curentEdit.Publication.AddYears(addTime * 10);
                        }
                        catch (System.Exception)
                        { }
                        break;
                    case DateTimeEditType.year:
                        try
                        {
                            curentEdit.Publication = curentEdit.Publication.AddYears(addTime);
                        }
                        catch (System.Exception)
                        { }
                        break;
                    case DateTimeEditType.tenMonths:
                        try
                        {
                            curentEdit.Publication = curentEdit.Publication.AddMonths(addTime * 10);
                        }
                        catch (System.Exception)
                        { }
                        break;
                    case DateTimeEditType.months:
                        try
                        {
                            curentEdit.Publication = curentEdit.Publication.AddMonths(addTime);
                        }
                        catch (System.Exception)
                        { }
                        break;
                    case DateTimeEditType.tenDay:
                        try
                        {
                            curentEdit.Publication = curentEdit.Publication.AddDays(addTime * 10);
                        }
                        catch (System.Exception)
                        { }
                        break;
                    case DateTimeEditType.day:
                        try
                        {
                            curentEdit.Publication = curentEdit.Publication.AddDays(addTime);
                        }
                        catch (System.Exception)
                        { }
                        break;
                    default:
                        break;
                }
            }
            else if (char.IsNumber(keyInfo.KeyChar))
            {
                try
                {
                    curentEdit.SetASpecialNumberInDateTime((DateTimeEditType) (columIndex - 3), (int) char.GetNumericValue(keyInfo.KeyChar));
                    columIndex++;
                }
                catch (System.Exception)
                { }
            }
        }
        private void ChangeBookType(BookTemple curentEdit, ConsoleKeyInfo keyInfo, int bookTypeMaxIndex)
        {
            int typeIndex = (int) curentEdit.Type;
            GetIndexWithKey(ref typeIndex, keyInfo, bookTypeMaxIndex);
            curentEdit.Type = (BookType) typeIndex;
        }

        private void AddMakeSearh(string searchingOn, string search, ref string curentWriten)
        {
            string searchLower = search.ToLower();
            string searchingOnLower = searchingOn.ToLower();

            if (curentWriten.ToLower() == "" && searchingOnLower.StartsWith(searchLower))
            {
                search = searchingOn.Substring(searchingOnLower.IndexOf(searchLower), searchLower.Length);

                WriteMakedSearh(search, ref curentWriten);
            }

            if (curentWriten != "")
            {
                //While next part is also in search text
                //but not if next part is eder "writer" or "publication"
                while (searchingOnLower.Contains(curentWriten.ToLower() + searchLower))
                {
                    search = searchingOn.Substring(searchingOnLower.IndexOf(searchLower), searchLower.Length);
                    WriteMakedSearh(search, ref curentWriten);
                }
            }
        }
        private void WriteMakedSearh(string search, ref string curentWriten)
        {
            Console.BackgroundColor = SelektedColor;
            Console.Write(search);
            curentWriten += search;
            Console.ResetColor();
        }

        private void UserStringBuilder(ConsoleKeyInfo keyInfo, ref string stringBuilderOn)
        {
            if (keyInfo.Key != ConsoleKey.Enter && keyInfo.Key != ConsoleKey.Escape)
            {
                if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (stringBuilderOn.Length > 0)
                        stringBuilderOn = stringBuilderOn.Remove(stringBuilderOn.Length - 1);
                }
                else
                {
                    if (char.IsLetter(keyInfo.KeyChar) ||
                        char.IsNumber(keyInfo.KeyChar) ||
                        keyInfo.Key == ConsoleKey.Subtract ||
                        keyInfo.Key == ConsoleKey.Spacebar)
                    {
                        stringBuilderOn += keyInfo.KeyChar;
                    }
                }
            }
        }

        private void ListEnumWhidSelect(int OptionIndex, Array enumOptions)
        {
            for (int i = 0; i < enumOptions.Length; i++)
            {
                if (OptionIndex == i)
                {
                    Console.BackgroundColor = SelektedColor;
                    Console.Write("-->");
                }
                Console.WriteLine($"{CodeToolsBox.GetEnumDescription((Enum) enumOptions.GetValue(i))}");

                Console.ResetColor();
            }
        }
        private void GetIndexWithKey(ref int OptionIndex, ConsoleKeyInfo keyInfo, int maxIndex)
        {

            if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                OptionIndex++;
                if (OptionIndex > maxIndex)
                {
                    OptionIndex = 0;
                }
            }
            else if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                OptionIndex--;
                if (OptionIndex < 0)
                {
                    OptionIndex = maxIndex;
                }
            }
        }
    }
}