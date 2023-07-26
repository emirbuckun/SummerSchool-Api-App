namespace SummerSchool.App.Entity
{
  public class Book : BaseEntity
  {
    public string Title { get; set; }
    public Book()
    {
      Title = "Empty";
    }
    public Book(int id, string title)
    {
      Id = id;
      Title = title;
    }
  }
}