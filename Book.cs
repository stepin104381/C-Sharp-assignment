using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{

    interface IBookManager
    {
        bool AddNewBook(Book bk);
        bool DeleteBook(int id);
        bool UpdateBook(Book bk);
        Book[] GetAllBooks(string title);
    }
    class CollectionBookManager : IBookManager
    {
        HashSet<Book> books = new HashSet<Book>();
        public bool AddNewBook(Book bk)
        {
            return books.Add(bk);
        }

        public bool DeleteBook(int id)
        {
            foreach (Book bk in books)
            {
                if (bk.BookID == id)
                {
                    books.Remove(bk);
                    return true;
                }
            }
            return false;
        }

        public Book[] GetAllBooks(string title)
        {
            //return books.ToList().FindAll((bk) => bk.Title.Contains(title)).ToArray();
            //Create a Temp List<Book> size is 0...
            List<Book> temp = new List<Book>();
            //run thro the Hashset, find the matching condition and add to the TempList...
            foreach (var bk in books)
            {
                if (bk.Title.Contains(title))
                    temp.Add(bk);
            }
            //return the List converted to array of Books.
            return temp.ToArray();
        }

        public bool UpdateBook(Book bk)
        {
            foreach(Book i in books)
            {
                if(bk.BookID==i.BookID)
                {
                    i.Author = bk.Author;
                    i.Title = bk.Title;
                    i.Price = bk.Price;
                    return true;
                }
            }
            return false;
        }
    }
    class UIClient
    {
        static string menu = string.Empty;
        static IBookManager mgr = new CollectionBookManager();
        static void InitializeComponent()
        {
            menu = string.Format($"~~BOOK STORE MANAGEMENT SOFTWARE~~~~~~\nTO ADD A NEW BOOK------------->PRESS 1\nTO UPDATE A BOOK------------>PRESS 2\nTO DELETE A BOOK------------PRESS 3\nTO FIND A BOOK------------->PRESS 4\nPS:ANY OTHER KEY IS CONSIDERED AS EXIT THE APP\n");
            //int size = MyConsole.getNumber("Enter the no of Books U wish to store in the BookStore");

            //mgr.AddNewBook(new Book { BookID = 123, Title = "A Suitable Boy", Author = "Vikram Seth", Price = 1200 });
            //mgr.AddNewBook(new Book { BookID = 124, Title = "Disclosure", Author = "Micheal Crichton", Price = 500 });
            //mgr.AddNewBook(new Book { BookID = 125, Title = "The Mahabharatha", Author = "C Rajagoalachari", Price = 350 });
            //mgr.AddNewBook(new Book { BookID = 126, Title = "The Discovery of India", Author = "J . Nehru", Price = 800 });

        }

        static void Main(string[] args)
        {
            InitializeComponent();
            bool @continue = true;
            do
            {
                string choice = MyConsole.getString(menu);
                @continue = processing(choice);
            } while (@continue);
        }

        private static bool processing(string choice)
        {
            switch (choice)
            {
                case "1":
                    addingBookFeature();
                    break;
                case "2":
                    updatingBookFeature();
                    break;
                case "3":
                    deletingFeature();
                    break;
                case "4":
                    readingFeature();
                    break;
                default:
                    return false;
            }
            return true;
        }

        private static void readingFeature()
        {
            string title = MyConsole.getString("Enter the title or part of the title to search");
            Book[] books = mgr.GetAllBooks(title);
            foreach (var bk in books)
            {
                if (bk != null)
                    Console.WriteLine(bk.Title);
                    Console.WriteLine(bk.BookID);
                    Console.WriteLine(bk.Author);
                    Console.WriteLine(bk.Price);
                 


            }
        }

        private static void deletingFeature()
        {
            int id = MyConsole.getNumber("Enter the ID of the book to remove");
            if (mgr.DeleteBook(id))
                Console.WriteLine("Book Deleted successfully");
            else
                Console.WriteLine("Could not find the book to delete");
        }

        private static void updatingBookFeature()
        {
            Book bk = new Book();
            bk.BookID = MyConsole.getNumber("Enter the ISBN no of the book U wish to update");
            bk.Title = MyConsole.getString("Enter the new title of this book");
            bk.Author = MyConsole.getString("Enter the new Author of this book");
            bk.Price = MyConsole.getDouble("Enter the new Price of this book");
            bool result = mgr.UpdateBook(bk);
            if (!result)
                Console.WriteLine($"No book by this id {bk.BookID} found to update");
            else
                Console.WriteLine($"Book by ID {bk.BookID} is updated successfully to the database");
        }

        private static void addingBookFeature()
        {
            Book bk = new Book();
            bk.BookID = MyConsole.getNumber("Enter the ISBN no of this book");
            bk.Title = MyConsole.getString("Enter the title of this book");
            bk.Author = MyConsole.getString("Enter the Author of this book");
            bk.Price = MyConsole.getDouble("Enter the Price of this book");
            try
            {
                bool result = mgr.AddNewBook(bk);
                if (!result)
                    Console.WriteLine("No more books could be added");
                else
                    Console.WriteLine($"Book by title {bk.Title} is added successfully to the database");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    class Book
    {
        public int BookID
        {
            get; set;
        }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Author { get; set; }

        

       
    }

}
