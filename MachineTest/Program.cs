/*Create an application to manage a library.The application will have  
An interface Ibooks that has the methods AddBooks and GetDetails
A class Books that has the methods AddBooks()to add the details
of the book like id, name and category  and GetBookDetails() to
retrieve the details of the books. This class should implement
from IBooks .
The AddBooks and GetBookDetails should be a choice get from the user.
Retrieve the details of the books into a suitable collection
Handle all exceptions at runtime*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineTest
{
    interface IBooks
    {
        void AddBook();
        void GetDetails();
    }

    class Books : IBooks
    {
        private List<Book> library = new List<Book>();

        public void AddBook()
        {
            Console.WriteLine("Enter book details:");
            Console.Write("Book ID: ");
            int id;

            try
            {
                id = int.Parse(Console.ReadLine());

                // Check if a book with the same ID already exists in the library
                if (library.Any(book => book.Id == id))
                {
                    Console.WriteLine("Book with the same ID already exists.");
                }
                else
                {
                    Console.Write("Book Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Category: ");
                    string category = Console.ReadLine();
                    Book book = new Book(id, name, category);
                    library.Add(book);
                    Console.WriteLine("Book added successfully!");
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid ID. Book not added.");
            }
        }



        public void GetDetails()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Display all books");
            Console.WriteLine("2. Search by ID");

            try
            {
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("All Books:");
                        foreach (var book in library)
                        {
                            Console.WriteLine(book);
                        }
                        break;
                    case 2:
                        Console.Write("Enter Book ID to search: ");
                        try
                        {
                            int searchId = int.Parse(Console.ReadLine());
                            Book result = library.Find(book => book.Id == searchId);
                            if (result != null)
                            {
                                Console.WriteLine("Book found: " + result);
                            }
                            else
                            {
                                Console.WriteLine("Book not found.");
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid choice.");
            }
        }


        class Book
        {
            public int Id { get; }
            public string Name { get; }
            public string Category { get; }

            public Book(int id, string name, string category)
            {
                Id = id;
                Name = name;
                Category = category;
            }

            public override string ToString()
            {
                return ("ID: " + Id + ", Name: " + Name + ", Category: " + Category);
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Books library = new Books();

                while (true)
                {
                    Console.WriteLine("\nLibrary Management System");
                    Console.WriteLine("1. Add a book");
                    Console.WriteLine("2. Get book details");
                    Console.WriteLine("3. Exit");
                    Console.Write("Enter your choice: ");

                    try
                    {
                        int choice = int.Parse(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                library.AddBook();
                                break;
                            case 2:
                                library.GetDetails();
                                break;
                            case 3:
                                Console.WriteLine("Goodbye!");
                                return;
                            default:
                                Console.WriteLine("Invalid choice.");
                                break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer for your choice.");
                    }
                }
            }

        }
    }
}
        








