using Microsoft.AspNetCore.Mvc;
using SummerSchool.Api.Entity;

internal class BookController : ControllerBase
{
  private static readonly List<Book> _bookList = new()
  {
    new Book(1, "Head First Design Patterns"),
    new Book(2, "Clean Architecture")
  };

  public BookController() { }

  [HttpGet]
  [Route("list")]
  public IActionResult Get()
  {
    return Ok(_bookList);
  }

  [HttpGet]
  public IActionResult Get(int id)
  {
    return Ok(_bookList.SingleOrDefault(x => x.Id == id));
  }

  [HttpPost]
  public IActionResult Post([FromBody] Book book)
  {
    if (book.Title is not null)
      _bookList.Add(new Book(_bookList.Count + 1, book.Title));
    return Ok();
  }

  [HttpPut]
  public IActionResult Put([FromBody] Book book)
  {
    Book? updateDepartment = _bookList.SingleOrDefault(x => x.Id == book.Id);
    book.Title = book.Title;
    return Ok();
  }

  [HttpDelete]
  public IActionResult Delete(int id)
  {
    Book? book = _bookList.SingleOrDefault(x => x.Id == id);
    if (book is not null)
    {
      _bookList.Remove(book);
    }
    return Ok();
  }
}