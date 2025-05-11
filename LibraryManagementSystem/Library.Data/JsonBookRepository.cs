using Library.Core.Models;
using Library.Core.Interfaces;
using System.Text.Json;

namespace Library.Data;

public class JsonBookRepository : IBookRepository
{
    private readonly string _filePath = "books.json";
    private List<Book> _books;

    public JsonBookRepository()
    {
        _books = LoadBooks();
    }

    private List<Book> LoadBooks()
    {
        if (!File.Exists(_filePath))
            return new List<Book>();

        string json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
    }

    private void SaveBooks()
    {
        string json = JsonSerializer.Serialize(_books, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }

    public List<Book> GetAll() => _books;

    public Book? GetById(int id) => _books.FirstOrDefault(b => b.Id == id);

    public void Add(Book book)
    {
        _books.Add(book);
        SaveBooks();
    }

    public void Update(Book book)
    {
        var index = _books.FindIndex(b => b.Id == book.Id);
        if (index >= 0)
        {
            _books[index] = book;
            SaveBooks();
        }
    }

    public void Delete(int id)
    {
        _books.RemoveAll(b => b.Id == id);
        SaveBooks();
    }

    public List<Book> Search(string title, string author) =>
        _books.Where(b =>
            (string.IsNullOrEmpty(title) || b.Title.Contains(title, StringComparison.OrdinalIgnoreCase)) &&
            (string.IsNullOrEmpty(author) || b.Author.Contains(author, StringComparison.OrdinalIgnoreCase))
        ).ToList();
}
