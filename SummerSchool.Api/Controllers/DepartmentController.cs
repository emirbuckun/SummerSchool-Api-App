using Microsoft.AspNetCore.Mvc;
using SummerSchool.Api.Models;

namespace SummerSchool.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class DepartmentController : ControllerBase
  {
    private static readonly List<Department> _departmentList = new() { new Department(1, "Computer Engineering"), new Department(2, "Math") };

    public DepartmentController() { }

    [HttpGet]
    [Route("list")]
    public IActionResult Get() { return Ok(_departmentList); }

    [HttpGet]
    public IActionResult Get(int id)
    {
      var department = _departmentList.SingleOrDefault(x => x.Id == id);
      return Ok(department);
    }

    [HttpPost]
    public IActionResult Post(string departmentName)
    {
      _departmentList.Add(new Department(_departmentList.Count + 1, departmentName));
      return Ok();
    }

    [HttpPut]
    public IActionResult Put(string departmentName)
    {
      var department = _departmentList.SingleOrDefault(new Department(_departmentList.Count, departmentName));
      _departmentList[department.Id] = new Department(department.Id, departmentName);
      return Ok(_departmentList[department.Id]);
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
      Department? department = _departmentList.SingleOrDefault(x => x.Id == id);
      if (department != null && department.Id > 0)
      {
        _departmentList.Remove(department);
        return Ok();
      }
      else return NotFound();
    }
  }
}