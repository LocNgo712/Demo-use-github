using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new LuatContext())
            {
                Author author1 = new Author() { Name = "Join", YearofBirth = 1984 };
                Author author2 = new Author() { Name = "David", YearofBirth = 1988 };
                Book book1 = new Book() { Isbn = "123-34567667", Name = "Entity Framework 6.0", Page = 100, Price = 5000 };
                book1.Authors = new HashSet<Author>() { author1, author2 };

                Book book2 = new Book() { Isbn = "343-9877654", Name = "Database systems", Page = 100, Price = 5000 };
                book2.Authors = new HashSet<Author>() { author1 };

                // Added new book into context
                context.Books.Add(book1);
                context.Books.Add(book2);
                // Update change from context to database (DBMS) 
                context.SaveChanges();

                //View data from DBMS

                var list = context.Books.ToList();
                foreach (Book b in list)
                {
                    Console.WriteLine("{0} - {1} - {2}", b.Isbn, b.Name, b.Price);
                }

                // Update data
                var oldData = context.Books.Find(3);
                if (oldData != null)
                    oldData.Name = "Entity Framework 6 - EF6";
                // Save change to database
                context.SaveChanges();

                // Delete data
                var data = context.Books.ToList().Where(x => x.Isbn == "343-9877654").First();
                context.Books.Remove(data);
                // Update change to database
                context.SaveChanges();
            }
        }

    }
}
