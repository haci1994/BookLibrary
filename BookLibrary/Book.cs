namespace BookLibrary
{
    public class Book
    {
        public Book(string title, string author, int id)
        {
            Title = title;
            Author = author;
            IsAvailable = true;
            Id = id;
        }

        public string Title { get; }
        public string Author { get; }
        public bool IsAvailable { get; private set; }
        public int Id { get; }

        public User WhoTook {get;set;}
        

        public void ChangeIsAvailableToFalse()
        {
            IsAvailable = false;
        }

        public string GetWhoTookName()
        {
            if(WhoTook == null || IsAvailable == true)
            {
                return "-";
            } else
            {
                return WhoTook.Name;
            }
                
        }

    }
}
