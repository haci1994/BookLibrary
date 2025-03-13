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

        public void AddToMyList(Book book)
        {
            _rentedList.Add(book);
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
