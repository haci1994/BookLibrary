namespace BookLibrary
{
    public class Library
    {
        private int _size = 2;
        private List<Book> libraryList = new List<Book>(4);

        public Library()
        {
            libraryList.Add(new Book("White Fang", "V.Hugo", 1001));
            libraryList.Add(new Book("Sonuncu olen umidlerdir", "Varis", 1002));
        }

        public void ShowAll()
        {
            Console.WriteLine(new string('-', 70));
            Console.WriteLine($"{"ID",-5}{"Title",-25}{"Author",-15}{"Availablility",-15}{"WhoTook",-15}");

            for (int i = 0; i < _size; i++)
            {
                Book item = libraryList[i];
                string TookerName = item.GetWhoTookName();
                string availabilityMark;

                if (item.IsAvailable)
                {
                    availabilityMark = "Available";
                }
                else { availabilityMark = "Taken"; }

                Console.WriteLine(new string('-', 70));
                Console.WriteLine($"{item.Id,-5}{item.Title,-25}{item.Author,-15}{availabilityMark,-15}{TookerName,-15}");
            }
            Console.WriteLine(new string('-', 70));
        }

        public void AddBook()
        {
            bool isCorrectId = false;
            bool isCorrectTitle = false;
            bool isCorrrectAuthor = false;
            int newId;
            string title;
            string author;
            int id;

            Console.WriteLine();
            Console.WriteLine("<ADDING A BOOK>");
            Console.WriteLine();

            #region //ID input 

            Console.WriteLine("Enter an ID for book:");
            do
            {
                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Wrong format for an ID (try an integer)!");
                    isCorrectId = false;
                    continue;
                }

                if (id < 1000 || id > 9999)
                {
                    Console.WriteLine("Enter 4 digit ID!");
                    isCorrectId = false;
                    continue;
                }

                foreach (Book book in libraryList)
                {
                    if (book.Id == id)
                    {
                        Console.WriteLine("Duplicate value for ID, try different number!");
                        isCorrectId = false;
                        continue;
                    }
                    else
                    {
                        isCorrectId = true;
                        continue;
                    }
                }

            } while (!isCorrectId);

            newId = id;

            #endregion

            #region //Title input

            Console.WriteLine("Enter a Title for book:");
            do
            {
                title = Console.ReadLine();
                if (title == null || title == "")
                {
                    Console.WriteLine("Title cannot be empty!");
                    isCorrectTitle = false;
                }
                else
                {
                    isCorrectTitle = true;
                }


            } while (!isCorrectTitle);


            #endregion

            #region //Author input

            Console.WriteLine($"Enter author of - {title}!");
            do
            {
                author = Console.ReadLine();
                if (author == null || author == "")
                {
                    Console.WriteLine("Author cannot be empty!");
                    isCorrrectAuthor = false;
                }
                else
                {
                    isCorrrectAuthor = true;
                }


            } while (!isCorrrectAuthor);

            #endregion

            Book newBook = new Book(title, author, newId);

            libraryList.Add(newBook);
            _size++;
        }

        public void Take(User user)
        {
            int id;
            bool isCorrectId = false;
            Book book;

            Console.WriteLine("Enter book Id to take:");

            do
            {
                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Wrong format for an ID (try an integer from List)!");
                    isCorrectId = false;
                    continue;
                }

                foreach (Book item in libraryList)
                {
                    if (item.Id == id && item.IsAvailable)
                    {
                        user.AddToMyList(item);
                        item.WhoTook = user;
                        item.ChangeIsAvailableToFalse();
                        isCorrectId = true;
                        continue;
                    }
                }
                Console.WriteLine("Id not found or chosen Book is not available!");

            } while (!isCorrectId);

        }
    }
}
