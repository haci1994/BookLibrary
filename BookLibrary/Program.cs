using System.ComponentModel;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;

namespace BookLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Users users = new Users();

            Library library = new Library();

            bool loggedIn = false;

            do
            {
                Console.WriteLine(new string('*', 20));
                Console.WriteLine("Welcome to book library!!!");
                Console.WriteLine(new string('*', 20));
                Console.WriteLine();
                Console.WriteLine("Log in to take new books or return books");
                Console.WriteLine();
                User loggedInUser;
                do
                {
                    loggedInUser = users.GetUser();
                    if (loggedInUser != null)
                    {
                        loggedIn = true;
                        Console.Clear();
                    }

                } while (!loggedIn);

                do
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter Command from menu:");
                    Console.WriteLine();
                    Console.WriteLine("1 - Add a book to library");
                    Console.WriteLine("2 - View all books in library");
                    Console.WriteLine("3 - Find a book by ID");
                    Console.WriteLine("4 - Borrow a book");
                    Console.WriteLine("5 - Return a book");
                    Console.WriteLine("6 - Remove a book");
                    Console.WriteLine("7 - Log out.");
                    Console.WriteLine("8 - Exit.");
                    Console.WriteLine("9 - Show my stuff (bonus)");

                    int command;

                    if (!int.TryParse(Console.ReadLine(), out command))
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Choose from menu");
                        Console.WriteLine();
                        continue;
                    }

                    switch (command)
                    {
                        case 1:
                            Console.Clear();
                            library.AddBook();
                            library.ShowAll();
                            break;
                        case 2:
                            Console.Clear();
                            library.ShowAll();
                            break;
                        case 3:
                            Console.Clear();
                            library.FindBookById();
                            break;
                        case 4:
                            Console.Clear();
                            library.Take(loggedInUser);
                            break;
                        case 5:
                            Console.Clear();
                            library.Return(loggedInUser);
                            break;
                        case 6:
                            Console.Clear();
                            library.Remove();
                            break;
                        case 7:
                            Console.Clear();
                            loggedIn = false;
                            loggedInUser = null;
                            break;
                        case 8:
                            Console.Clear();
                            Environment.Exit(0);
                            break;
                        case 9:
                            Console.Clear();
                            loggedInUser.ShowUserStaff();
                            break;
                        default:
                            Console.WriteLine("Choose correct command!");
                            break;
                    }
                } while (loggedIn);
            } while (!loggedIn);
        }
    }
}
