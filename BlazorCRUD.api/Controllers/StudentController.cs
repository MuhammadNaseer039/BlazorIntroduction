using BlazorCRUD.api.Data;
using BlazorCRUD.lib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUD.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly Datadbcontext db;
        public StudentController(Datadbcontext _db)
        {
            db = _db;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await db.tbl_students.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Getstudent(int id)
        {
            var student = await db.tbl_students.FindAsync(id);
            if(student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id,Student student)
        {
            if(id != student.Id)
            {
                return BadRequest();
            }
            db.Entry(student).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!StudentExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> PostStudent(Student student)
        {
            db.tbl_students.Add(student);
            await db.SaveChangesAsync();

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await db.tbl_students.FindAsync(id);
            if(student == null)
            {
                return NotFound();
            }

            db.tbl_students.Remove(student);
            await db.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExist(int id)
        {
            return db.tbl_students.Any(x=>x.Id == id);
        }

    }

}
