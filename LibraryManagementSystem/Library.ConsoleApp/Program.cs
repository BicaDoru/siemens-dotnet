using Library.Core.Models;
using Library.Data;
using Library.Services;

var repo = new JsonBookRepository();
var service = new BookService(repo);

while (true)
{
    Console.WriteLine("\n1. List Books" +
        "\n2. Add Book" +
        "\n3. Borrow Book" +
        "\n4. Return Book" +
        "\n5. Search" +
        "\n6. Charge late fees for overdue books" +
        "\n7. Update Book" +
        "\n8. Delete Book" +
        "\n9. Exit");

    Console.Write("Choice: ");
    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            foreach (var b in service.GetAllBooks())
                Console.WriteLine($"{b.Id}: {b.Title} by {b.Author} ({b.Quantity} available)");
            break;

        case "2":
            Console.Write("Title: ");
            string title = Console.ReadLine()!;
            Console.Write("Author: ");
            string author = Console.ReadLine()!;
            Console.Write("Quantity: ");
            int quantity = int.Parse(Console.ReadLine()!);
            service.AddBook(new Book { Id = new Random().Next(1, 10000), Title = title, Author = author, Quantity = quantity });
            break;

        case "3":
            Console.Write("Book ID to borrow: ");
            int borrowId = int.Parse(Console.ReadLine()!);
            if (service.BorrowBook(borrowId)) Console.WriteLine("Borrowed.");
            else Console.WriteLine("Not available.");
            break;

        case "4":
            Console.Write("Book ID to return: ");
            int returnId = int.Parse(Console.ReadLine()!);
            if (service.ReturnBook(returnId)) Console.WriteLine("Returned.");
            else Console.WriteLine("Error.");
            break;

        case "5":
            Console.Write("Search Title: ");
            string searchTitle = Console.ReadLine()!;
            Console.Write("Search Author: ");
            string searchAuthor = Console.ReadLine()!;
            var found = service.SearchBooks(searchTitle, searchAuthor);
            foreach (var b in found)
                Console.WriteLine($"{b.Id}: {b.Title} by {b.Author} ({b.Quantity})");
            break;

        case "6":
            service.ChargeLateFees();
            break;

        case "7":
            Console.Write("Book ID to update: ");
            int updateId = int.Parse(Console.ReadLine()!);

            Console.Write("New Title: ");
            string newTitle = Console.ReadLine()!;
            Console.Write("New Author: ");
            string newAuthor = Console.ReadLine()!;
            Console.Write("New Quantity: ");
            int newQuantity = int.Parse(Console.ReadLine()!);

            service.UpdateBook(new Book { Id = updateId, Title = newTitle, Author = newAuthor, Quantity = newQuantity });
            Console.WriteLine("Book updated.");
            break;

        case "8":
            Console.Write("Book ID to delete: ");
            int deleteId = int.Parse(Console.ReadLine()!);
            service.RemoveBook(deleteId);
            Console.WriteLine("Book deleted.");
            break;

        case "9":
            return;

    }
}
