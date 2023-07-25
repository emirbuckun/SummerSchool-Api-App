using Microsoft.AspNetCore.Mvc;
using SummerSchool.App.Entity;

namespace SummerSchool.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class BookController : ControllerBase
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
    public IActionResult Post([FromBody] Book request)
    {
      if (IsValid(request))
      {
        if (request is not null && request.Title is not null)
        {
          var isExist = _bookList.SingleOrDefault(x => x.Title == request.Title);
          if (isExist is not null)
          {
            _bookList.Add(new Book(_bookList.Count + 1, request.Title));
            return Ok();
          }
          else
          {
            return Conflict();
          }
        }
        else
        {
          return Conflict();
        }
      }
      else
      {
        return BadRequest();
      }
    }

    [HttpPut]
    public IActionResult Put([FromBody] Book request)
    {
      var existingBook = _bookList.SingleOrDefault(x => x.Id == request.Id);
      if (existingBook is not null)
      {
        existingBook = request;
        return Ok();
      }
      else
      {
        return NotFound();
      }
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
      Book? book = _bookList.SingleOrDefault(x => x.Id == id);

      if (book is not null)
      {
        _bookList.Remove(book);
        return Ok();
      }
      return NotFound();
    }

    private static bool IsValid(Book book)
    {
      if (string.IsNullOrEmpty(book.Title))
      {
        return false;
      }
      else
      {
        return true;
      }
    }
  }
}