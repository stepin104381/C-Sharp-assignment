using System;


namespace SampleConApp
{
   

    class Book
    {
        int id, price;
        string author, title;


        public int BookID
        {
            get { return id; }
            set { id = value; }
        }

        public string BookAuthor
        {
            get { return author; }
            set { author = value; }
        }

        public string BookTitle
        {
            get { return title; }
            set { title = value; }
        }

        public int BookPrice
        {
            get { return price; }
            set { price = value; }
        }



        static void Main(string[] args)
        {
            Book book = new Book();
            book.BookID = 12;
            book.BookTitle = "C#";
            book.BookAuthor = "Nisarga";
            book.BookPrice = 1000;
            Console.WriteLine($"The name of the Book is {book.BookTitle} id is {book.BookID} written by {book.BookAuthor} costing {book.BookPrice}");

        }
    }
}
