using SummerSchool.App.Database;
using SummerSchool.App.Entity;

namespace SummerSchool.App.Handler
{
  public class BookHandler
  {
    private readonly BookRepository _bookRepository;
    public BookHandler(BookRepository bookRepository)
    {
      _bookRepository = bookRepository;
    }

    public List<Book> GetBooks()
    {
      return _bookRepository.BookList;
    }

    public Book? GetBook(int id)
    {
      return _bookRepository.BookList.SingleOrDefault(x => x.Id == id);
    }

    public bool AddBook(Book book)
    {
      if (IsValid(book))
      {
        var existingBook = _bookRepository.BookList.SingleOrDefault(x => x.Title == book.Title);

        if (existingBook == null)
        {
          _bookRepository.BookList.Add(new Book(_bookRepository.BookList.Count + 1, book.Title));
          return true;
        }
        return false;
      }
      return false;
    }

    public bool UpdateBook(Book book)
    {
      if (IsValid(book))
      {
        var existingBook = _bookRepository.BookList.SingleOrDefault(x => x.Id == book.Id);

        if (existingBook != null)
        {
          existingBook = book;
          return true;
        }
        return false;
      }
      return false;
    }

    public bool DeleteBook(int id)
    {
      var existingBook = _bookRepository.BookList.SingleOrDefault(x => x.Id == id);

      if (existingBook != null)
      {
        _bookRepository.BookList.Remove(existingBook);
        return true;
      }
      return false;
    }

    private static bool IsValid(Book book)
    {
      if (string.IsNullOrEmpty(book.Title))
        return false;
      else
        return true;
    }
  }
}