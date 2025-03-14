namespace BookLibrary
{
    public class Library
    {
        private int _size = 3;
        private List<Book> libraryList = new List<Book>(4);
        private int _availableCount = 3;
        private int _borrowedCount = 0;

        public void StatisticsCount()
        {
            Console.WriteLine();
            Console.WriteLine($"Borrowed book count is {_borrowedCount}");
            Console.WriteLine($"Available book count is {_availableCount}");
            Console.WriteLine();
        }
        public Library()
        {
            libraryList.Add(new Book("White Fang", "Jack London", 1001));
            libraryList.Add(new Book("Sonuncu olen umidlerdir", "Varis", 1002));
            libraryList.Add(new Book("Sefiller", "V. Hugo", 1003));
        }
        public void ShowAll()
        {
            Console.WriteLine(new string('*', 70));
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
            Console.WriteLine(new string('*', 70));
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
            _availableCount++;

            Console.WriteLine();
            Console.WriteLine("<ADDING A BOOK>");
            Console.WriteLine();

            #region //ID input 

            Console.WriteLine("Enter an ID for book (enter 0 to get back to menu):");
            do
            {
                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Wrong format for an ID (try an integer)!");
                    isCorrectId = false;
                    continue;
                }

                if (id == 0) return;

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
                        break;
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
            _availableCount--;
            _borrowedCount++;

            ShowAll();

            Console.WriteLine("Enter book Id to take (type 0 to get back to menu):");

            do
            {
                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Wrong format for an ID (try an integer from List)!");
                    isCorrectId = false;
                    continue;
                }

                if (id == 0) return;

                foreach (Book item in libraryList)
                {
                    if (item.Id == id && item.IsAvailable)
                    {
                        user.AddToMyList(item);
                        item.WhoTook = user;
                        Console.WriteLine($"You took {item.Title}.");
                        //user.IncreaseBorrowlistSize();
                        Console.WriteLine();
                        item.ChangeIsAvailableToFalse();
                        isCorrectId = true;
                        continue;
                    }
                }
                if (!isCorrectId) Console.WriteLine("Id not found or chosen Book is not available!");

            } while (!isCorrectId);

        }
        public void Return(User user)
        {
            int id;
            bool isCorrectId = false;
            _availableCount++;
            _borrowedCount--;

            var bookList = user.UserList();
            int sizeOfUserList = user.Size;

            user.ShowUserStaff();

            Console.WriteLine("Enter book Id to return (type 0 to get back to menu):");

            do
            {
                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Wrong format for an ID (try an integer from List)!");
                    isCorrectId = false;
                    continue;
                }

                if (id == 0) return;

                for (int i = 0; i < sizeOfUserList; i++)
                {
                    Book item = bookList[i];
                    if (item.Id == id)
                    {
                        user.RemoveFromUserList(item);
                        item.WhoTook = null;
                        Console.WriteLine($"You returned {item.Title}.");

                        Console.WriteLine();
                        item.ChangeIsAvailableToTrue();
                        isCorrectId = true;
                        break;
                    }
                }
                if (!isCorrectId) Console.WriteLine("Id not found or chosen Book is not available!");



            } while (!isCorrectId);
        }
        public void Remove()
        {
            int id;
            bool isCorrectId = false;
            Book book;
            _availableCount--;

            ShowAll();

            Console.WriteLine("Enter book Id to remove (type 0 to get back to menu):");

            do
            {
                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Wrong format for an ID (try an integer from List)!");
                    isCorrectId = false;
                    continue;
                }

                if (id == 0) return;

                for (int i = 0; i < _size; i++)
                {
                    Book item = libraryList[i];

                    if (item.Id == id && item.IsAvailable)
                    {
                        Console.WriteLine($"{item.Title} removed from list.");
                        libraryList.Remove(item);
                        _size--;
                        isCorrectId = true;
                        break;
                    }

                    if (item.Id == id && !item.IsAvailable)
                    {
                        Console.WriteLine($"{item.Title} borrowed by {item.GetWhoTookName()}, please get back then try to remove the book!!!");
                        isCorrectId = true;
                        break;
                    }
                }

                if (!isCorrectId) Console.WriteLine("Id not found!");

            } while (!isCorrectId);
        }
        public void FindBookById()
        {
            int id;
            bool isCorrectId = false;
            Book book;

            Console.WriteLine("Search book ID (type 0 to get back to menu):");

            do
            {
                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Wrong format for an ID (try an integer from List)!");
                    isCorrectId = false;
                    continue;
                }

                if (id == 0) return;

                for (int i = 0; i < _size; i++)
                {
                    Book item = libraryList[i];
                    string msg = item.IsAvailable ? "Available" : "Taken";

                    if (item.Id == id)
                    {
                        Console.Clear();
                        Console.WriteLine(new string('*', 30));
                        Console.WriteLine($"{id} FOUND:\n{new string('-', 30)}\n{item.Title} - {item.Author} - {msg}");
                        Console.WriteLine(new string('*', 30));
                        isCorrectId = true;
                        break;
                    }
                }

                if (!isCorrectId) Console.WriteLine("Id not found!");

            } while (!isCorrectId);
        }
        public void AllAvailable()
        {
            if (_size == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Library is empty");
                Console.WriteLine();
                return;
            }
            Console.WriteLine(new string('-', 70));
            Console.WriteLine($"{"ID",-5}{"Title",-25}{"Author",-15}{"Availablility",-15}{"WhoTook",-15}");

            for (int i = 0; i < _size; i++)
            {
                Book item = libraryList[i];

                string availabilityMark;

                if (item.IsAvailable)
                {
                    availabilityMark = "Available";
                }
                else { availabilityMark = "Taken"; }

                if (item.IsAvailable)
                {
                    Console.WriteLine(new string('-', 70));
                    Console.WriteLine($"{item.Id,-5}{item.Title,-25}{item.Author,-15}{availabilityMark,-15}{item.GetWhoTookName(),-15}");
                }

            }
            Console.WriteLine(new string('-', 70));

        }
        public void AllBorrowed()
        {
            if (_size == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Library is empty");
                Console.WriteLine();
                return;
            }
            Console.WriteLine(new string('-', 70));
            Console.WriteLine($"{"ID",-5}{"Title",-25}{"Author",-15}{"Availablility",-15}{"WhoTook",-15}");

            for (int i = 0; i < _size; i++)
            {
                Book item = libraryList[i];

                string availabilityMark;

                if (item.IsAvailable)
                {
                    availabilityMark = "Available";
                }
                else { availabilityMark = "Taken"; }

                if (!item.IsAvailable)
                {
                    Console.WriteLine(new string('-', 70));
                    Console.WriteLine($"{item.Id,-5}{item.Title,-25}{item.Author,-15}{availabilityMark,-15}{item.GetWhoTookName(),-15}");
                }

            }
            Console.WriteLine(new string('-', 70));

        }
        public void Search()
        {
            Console.WriteLine();
            Console.Write("Search: ");
            string key = Console.ReadLine();

            int count = 0;

            if (_size == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Library is empty");
                Console.WriteLine();
                return;
            }

            Console.WriteLine(new string('-', 70));
            Console.WriteLine($"{"ID",-5}{"Title",-25}{"Author",-15}{"Availablility",-15}{"WhoTook",-15}");

            for (int i = 0; i < _size; i++)
            {
                Book item = libraryList[i];

                string availabilityMark;

                if (item.IsAvailable)
                {
                    availabilityMark = "Available";
                }
                else { availabilityMark = "Taken"; }

                if (item.Title.Contains(key, StringComparison.InvariantCultureIgnoreCase) || item.Author.Contains(key, StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine(new string('-', 70));
                    Console.WriteLine($"{item.Id,-5}{item.Title,-25}{item.Author,-15}{availabilityMark,-15}{item.GetWhoTookName(),-15}");
                    count++;
                }
                
            }

            if (count == 0)
            {
                Console.Clear();
                Console.WriteLine("No books found!");
            }
            Console.WriteLine(new string('-', 70));
        }
    }
}