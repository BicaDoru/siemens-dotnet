using Library.Core.Models;

namespace Library.Core.Interfaces;

public interface IBookRepository
{
    List<Book> GetAll();
    Book? GetById(int id);
    void Add(Book book);
    void Update(Book book);
    void Delete(int id);
    List<Book> Search(string title, string author);
}
