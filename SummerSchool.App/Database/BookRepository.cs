using SummerSchool.App.Entity;

namespace SummerSchool.App.Database
{
  public class BookRepository
  {
    public List<Book> BookList { get; set; }

    BookRepository()
    {
      BookList = new List<Book>()
      {
        new Book(1, "Head First Design Patterns"),
        new Book(2, "Clean Architecture")
      };
    }
  }
}