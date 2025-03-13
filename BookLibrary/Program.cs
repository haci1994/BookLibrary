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
                    if (loggedInUser != null) loggedIn = true;

                } while (!loggedIn);

                do
                {
                    Console.WriteLine("Enter Command");
                    Console.WriteLine("1 - Add a book to library");
                    Console.WriteLine("2 - View all books in library");
                    Console.WriteLine("3 - Find a book by ID");
                    Console.WriteLine("4 - Borrow a book");
                    Console.WriteLine("5 - Return a book");
                    Console.WriteLine("6 - Remove a book");
                    Console.WriteLine("7 - Log out.");
                    Console.WriteLine("8 - Exit.");

                    int command = int.Parse(Console.ReadLine());

                    switch (command)
                    {
                        case 1:
                            library.AddBook();
                            break;
                        case 2:
                            library.ShowAll();
                            break;
                        case 4:
                            library.Take(loggedInUser);
                            break;
                        case 7:
                            loggedIn = false;
                            loggedInUser = null;
                            break;
                        case 8:
                            Environment.Exit(0);
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
