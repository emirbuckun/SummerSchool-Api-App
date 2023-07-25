using Microsoft.AspNetCore.Mvc;
using SummerSchool.Api.Models;

namespace SummerSchool.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class DepartmentController : ControllerBase
  {
    private static readonly List<Department> _departmentList = new() { new Department(1, "Computer Enginering"), new Department(2, "Psychology") };

    public DepartmentController() { }

    [HttpGet]
    [Route("list")]
    public IActionResult Get()
    {
      return Ok(_departmentList);
    }

    [HttpGet]
    public IActionResult Get(int id)
    {
      return Ok(_departmentList.SingleOrDefault(x => x.Id == id));
    }

    [HttpPost]
    public IActionResult Post([FromBody] Department department)
    {
      _departmentList.Add(new Department(_departmentList.Count + 1, department.Name));
      return Ok();
    }

    [HttpPut]
    public IActionResult Put([FromBody] Department department)
    {
      Department? updateDepartment = _departmentList.SingleOrDefault(x => x.Id == department.Id);
      if (updateDepartment is not null)
        department.Name = department.Name;
      return Ok();
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
      Department? department = _departmentList.SingleOrDefault(x => x.Id == id);
      if (department is not null)
        _departmentList.Remove(department);
      return Ok();
    }
  }
}