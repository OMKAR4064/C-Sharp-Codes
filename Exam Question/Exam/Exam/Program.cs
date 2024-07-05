using System;
using System.Collections.Generic;
using System.Linq;
using static Exam.Program.TestCode;


namespace Exam
{
    internal class Program
    {
        public class TestCode
        {
            public static List<Book> Books = new List<Book>();
            public static List<Author> Authors = new List<Author>();

            public static void InitiateRecords()
            {
                Authors.Add(new Author { AuthorId = 1, AuthorName = "Author1" });
                Authors.Add(new Author { AuthorId = 2, AuthorName = "Author2" });
                Authors.Add(new Author { AuthorId = 3, AuthorName = "Author3" });
                Authors.Add(new Author { AuthorId = 4, AuthorName = "Author4" });
                Authors.Add(new Author { AuthorId = 5, AuthorName = "Author5" });


                Books.Add(new Book { BookId = 1, Title = "Book1", Price = 200, AuthorId = 1 });
                Books.Add(new Book { BookId = 2, Title = "Book1", Price = 200, AuthorId = 2 });
                Books.Add(new Book { BookId = 3, Title = "Book2", Price = 200, AuthorId = 3 });
                Books.Add(new Book { BookId = 4, Title = "Book3", Price = 200, AuthorId = 4 });
                Books.Add(new Book { BookId = 5, Title = "Book4", Price = 200, AuthorId = 5 });
                Books.Add(new Book { BookId = 6, Title = "Book5", Price = 200, AuthorId = 1 });
                Books.Add(new Book { BookId = 7, Title = "Book6", Price = 200, AuthorId = 2 });
                Books.Add(new Book { BookId = 8, Title = "Book7", Price = 200, AuthorId = 3 });
                Books.Add(new Book { BookId = 9, Title = "Book8", Price = 200, AuthorId = 4 });
                Books.Add(new Book { BookId = 10, Title = "Book9", Price = 200, AuthorId = 5 });
                
            }

            static void Main(string[] args)
            {
                InitiateRecords();

                Console.WriteLine();
                Console.WriteLine("All Books");

                var allBooks = from book in Books select book;
                foreach (var book in allBooks)
                {
                    Console.WriteLine(book);
                }
                Console.WriteLine();
                Console.WriteLine("BookId and Title");
               var bookIdTitle = from book in Books select new { book.BookId, book.Title };
                foreach (var item in bookIdTitle)
                {
                    Console.WriteLine($"BookId: {item.BookId}, Title: {item.Title}");
                }
                Console.WriteLine();
                Console.WriteLine("Book price Greater than 500");
                var booksGreaterThan500 = from book in Books where book.Price > 500 select book;
                foreach (var book in booksGreaterThan500)
                {
                    Console.WriteLine(book);
                }
                Console.WriteLine();
                Console.WriteLine("Book price between 300 and 700");
                var booksBetween300And700 = from book in Books where book.Price >= 300 && book.Price <= 700 select book;
                foreach (var book in booksBetween300And700)
                {
                    Console.WriteLine(book);
                }
                Console.WriteLine();
                Console.WriteLine("Book using order by on Title in Decendinng Order");
                var booksOrderedByTitleDesc = from book in Books orderby book.Title descending select book;
                foreach (var book in booksOrderedByTitleDesc)
                {
                    Console.WriteLine(book);
                }
                Console.WriteLine();
                Console.WriteLine("Order by with Ascending and descending");
                var booksOrderedByTitleAscPriceDesc = from book in Books orderby book.Title ascending, book.Price descending select book;
                foreach (var book in booksOrderedByTitleAscPriceDesc)
                {
                    Console.WriteLine(book);
                }
                Console.WriteLine();
                Console.WriteLine("Join on the Author and list Book and AuthorId and select book only");
                var booksWithAuthors = from book in Books
                                       join author in Authors on book.AuthorId equals author.AuthorId
                                       select book;
                foreach (var book in booksWithAuthors)
                {
                    Console.WriteLine(book);
                }
                Console.WriteLine();
                Console.WriteLine("Join on the Author and list Book and AuthorId and select author only");
                var authorsWithBooks = from author in Authors
                                       join book in Books on author.AuthorId equals book.AuthorId
                                       select author;
                foreach (var author in authorsWithBooks)
                {
                    Console.WriteLine(author);
                }
                Console.WriteLine();
                Console.WriteLine("Join on the Author and list Book and AuthorId and select book only");
                var booksWithAuthorsAgain = from book in Books
                                            join author in Authors on book.AuthorId equals author.AuthorId
                                            select book;
                foreach (var book in booksWithAuthorsAgain)
                {
                    Console.WriteLine(book);
                }
                Console.WriteLine();
                Console.WriteLine("Join on the Author and list Book and AuthorId and select few properties Of book and few of Author");
                var booksWithSelectedProperties = from book in Books
                                                  join author in Authors on book.AuthorId equals author.AuthorId
                                                  select new { book.BookId, book.Title, book.Price };
                foreach (var item in booksWithSelectedProperties)
                {
                    Console.WriteLine($"BookId: {item.BookId}, Title: {item.Title}, Price: {item.Price}");
                }

            }

            public class Book
            {
                public int BookId
                {
                    get
                    {
                        return _bookId;
                    }
                    set
                    {
                        if (value <= 0)
                            throw new BookException("BookId must be greater than 0");
                        _bookId = value;
                    }
                }
                private int _bookId;



                public string Title
                {
                    get { return _title; }
                    set
                    {
                        if (String.IsNullOrEmpty(value))
                            throw new BookException("Title cannot be null or empty");
                        _title = value;
                    }
                }
                private string _title;

                public decimal Price
                {
                    get { return _price; }
                    set
                    {
                        if (value <= 0)
                            throw new BookException("Price must be greater than 0");
                        _price = value;
                    }
                }
                private decimal _price;

                public int AuthorId { get; set; }

                public override string ToString()
                {
                    return $"BookId : {BookId},Title: {Title}, Price: {Price},Author Id : {AuthorId}";
                }
            }
            public class BookException : Exception
            {
                public BookException(string message) : base(message)
                {
                }
            }

            public class Author
            {
                public int AuthorId
                {
                    get
                    {
                        return _authorId;
                    }
                    set
                    {
                        if (value <= 0)
                            throw new AuthorException("AuthorId must be greater than 0");
                        _authorId = value;

                    }
                }
                private int _authorId;



                public String AuthorName
                {
                    get { return _authorName; }

                    set
                    {
                        if (string.IsNullOrEmpty(value))
                            throw new AuthorException("AuthorName cannot be null or empty");
                        _authorName = value;
                    }
                }
                private String _authorName;

                public override string ToString()
                {
                    return $"AuthorId: {AuthorId},AuthorName:{AuthorName}";
                }
            }
            public class AuthorException : Exception
            {
                public AuthorException(string message) : base(message) { }
            }
        }
    }
}