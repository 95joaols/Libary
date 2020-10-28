using System;
using System.Threading;
using LibraryCore;

namespace LibraryConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.BufferHeight = Console.WindowHeight;
            Library library = new Library();
            Menu menu = new Menu();
            Console.Title = "Library";

            while (true)
            {
                Console.Clear();

                Menu.MainMenu mainMenuEnum = (Menu.MainMenu) menu.ScrollableAndSelectableMenu<Menu.MainMenu>();

                switch (mainMenuEnum)
                {
                    case Menu.MainMenu.ListSearhBooks:
                        menu.SearchableMenu(library);
                        break;
                    case Menu.MainMenu.NewBooks:
                        menu.AddBooksMenu(library);
                        break;
                    case Menu.MainMenu.Exit:
                        Console.Clear();
                        Console.WriteLine("Goodbye");
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}