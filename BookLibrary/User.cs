using System.Reflection.Metadata.Ecma335;

namespace BookLibrary
{
    public class User
    {
        public User(string name, string pass)
        {
            Name = name;
            Pass = pass;
        }

        public string Name { get; }
        public string Pass { get; }

        private List<Book> _rentedList = new List<Book>(4);

        private int _size = 0;

        public void IncreaseBorrowlistSize()
        {
            _size++;
        }

        public int Size { get { return _size; } }

        public List<Book> UserList () {  return _rentedList; }

        public void AddToMyList(Book book)
        {
            _rentedList.Add(book);
            _size++;    
        }

        public void ShowUserStaff()
        {
            if (_size == 0)
            {
                Console.WriteLine();
                Console.WriteLine("No book borrowed");
                Console.WriteLine();
                return;
            }
            Console.WriteLine(new string('-', 70));
            Console.WriteLine($"{"ID",-5}{"Title",-25}{"Author",-15}{"Availablility",-15}{"WhoTook",-15}");

            for (int i = 0; i < _size; i++)
            {
                Book item = _rentedList[i];
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

        public void RemoveFromUserList (Book book)
        {
            _rentedList.Remove(book);
            _size--;
        }
    }

    public class Users
    {
        private List<User> _userList = new List<User>(4);

        public Users()
        {
            _userList.Add(new User("Haji", "123"));
            _userList.Add(new User("Elmin", "321"));
        }

        public User GetUser()
        {
            Console.WriteLine();
            Console.Write("Enter login: ");
            string n = Console.ReadLine();
            Console.Write("Enter pass: ");
            string p = Console.ReadLine();
            Console.WriteLine();

            foreach (User item in _userList)
            {

                if (item.Name == n && item.Pass == p)
                {
                    return item;
                }
            }

            Console.WriteLine("User Not Found!");
           
            return null;
        }
    }
}
