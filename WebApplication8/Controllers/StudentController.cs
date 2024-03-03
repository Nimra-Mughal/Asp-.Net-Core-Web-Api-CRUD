using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly WebapidbContext context;

        public StudentController(WebapidbContext context)
        {
            this.context = context;
        }

        //get all record
        [HttpGet]
        public async Task<ActionResult<List<string>>> getstudent()
        {
            var data = await context.Students.ToListAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> getstudentbyID(int id)
        {
            var student = await context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return student;
        }

        [HttpPost]
        public async Task<ActionResult<List<string>>> createstudent(Student std)
        {
            await context.Students.AddAsync(std);
            await context.SaveChangesAsync();
            return Ok(std);
        }
     
        [HttpPut("{id}")]
        public async Task UpdateEmployee(int id, Student model)
        {
            var student = await context.Students.FindAsync(id);
            if (student == null)
            {
                throw new Exception("employee Not Found");
            }
            student.Name = model.Name;
            student.Gender = model.Gender;
            student.Age = model.Age;
            student.Standard = model.Standard;
            student.Fathername = model.Fathername;
            await context.SaveChangesAsync();

        }
        //public async Task<ActionResult<Student>> updateStudent(int id, Student std)
        //{
        //    if (id != std.Id)
        //    {
        //        return BadRequest();
        //    }
        //    context.Entry(std).State = EntityState.Modified;
        //    await context.SaveChangesAsync();
        //    return Ok(std);
        //}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var data = await context.Students.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            context.Students.Remove(data);
            await context.SaveChangesAsync();
            return Ok();
        }











































        //    [HttpGet("{id}")]
        //    public async Task<ActionResult<List<string>>> getstudentByid(int id)
        //    {
        //        var data = await context.Students.FindAsync(id);
        //        if(data == null){
        //            return NotFound();
        //        }
        //        return Ok(data);
        //    }
        //    [HttpPost]
        //    public async Task<ActionResult<Student>> CreateStudent(Student std)
        //    {
        //        await context.Students.AddAsync(std);
        //        await context.SaveChangesAsync();
        //        return Ok(std);
        //    }
        //    [HttpPut("{id}")]
        //    public async Task<ActionResult<Student>> UpdateStudent(int id, Student std)
        //    {
        //        if (id != std.Id)
        //        {
        //            return BadRequest();
        //        }
        //        context.Entry(std).State = EntityState.Modified;
        //        await context.SaveChangesAsync();
        //        return Ok(std);
        //    }
        //    [HttpDelete("{id}")]
        //    public async Task<ActionResult<Student>> DeleteStudent(int id)
        //    {
        //        var std = await context.Students.FindAsync(id);
        //        if (std==null)
        //        {
        //            return NotFound();
        //        }
        //        context.Students.Remove(std);
        //        await context.SaveChangesAsync();
        //        return Ok();
        //    }

    }
}   
    