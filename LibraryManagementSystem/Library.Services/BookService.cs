using Library.Core.Models;
using Library.Core.Interfaces;

namespace Library.Services;

public class BookService
{
    private readonly IBookRepository _repo;

    public BookService(IBookRepository repo)
    {
        _repo = repo;
    }

    public List<Book> GetAllBooks() => _repo.GetAll();

    public void AddBook(Book book) => _repo.Add(book);

    public void RemoveBook(int id) => _repo.Delete(id);

    public void UpdateBook(Book book) => _repo.Update(book);

    public List<Book> SearchBooks(string title, string author) => _repo.Search(title, author);

    public bool BorrowBook(int id)
    {
        var book = _repo.GetById(id);
        if (book == null || book.Quantity == 0 || book.BorrowDetails != null) 
            return false;

        book.Quantity--;
        book.BorrowDetails = new BorrowInfo { BorrowDate = DateTime.Now };
        _repo.Update(book);
        return true;
    }
    public bool ReturnBook(int id)
    {
        var book = _repo.GetById(id);
        if (book == null || book.BorrowDetails == null || book.BorrowDetails.IsReturned)
            return false;

        book.Quantity++;
        book.BorrowDetails.IsReturned = true;

        // If there is a late fee, charge it when returned
        if (book.BorrowDetails.LateFee > 0)
        {
            Console.WriteLine($"Book '{book.Title}' returned. Late fee: ${book.BorrowDetails.LateFee}");
            book.BorrowDetails.LateFee = 0; // Reset the fee after charging it
        }
        else Console.WriteLine("No late fee penalty applied.");

            _repo.Update(book);
        return true;
    }

    public void ChargeLateFees()
    {
        const double dailyLateFee = 1.0; // fee per overdue day (ie, $1 per day)

        var books = _repo.GetAll();
        foreach (var book in books)
        {
            if (book.BorrowDetails != null && !book.BorrowDetails.IsReturned)
            {
                var overdueDays = (DateTime.Now - book.BorrowDetails.BorrowDate).Days;
                if (overdueDays > 0)
                {
                    // calculate late fee
                    book.BorrowDetails.LateFee = overdueDays * dailyLateFee;
                    Console.WriteLine($"Book '{book.Title}' is overdue by {overdueDays} days. Late fee: ${book.BorrowDetails.LateFee}");
                }
            }
            else
            {
                Console.WriteLine($"Book '{book.Title} is not overdue.");
            }
        }
    }

}
