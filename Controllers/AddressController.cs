using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddressController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _unitOfWork.Students.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _unitOfWork.Students.GetByIdAsync(id);
            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Student student)
        {
            if (student == null)
                return BadRequest();

            _unitOfWork.Students.InsertAsync(student);
            _unitOfWork.Complete();

            return CreatedAtAction(nameof(GetById), new { id = student.StudentId }, student);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Student student)
        {
            if (student == null || student.StudentId != id)
                return BadRequest();

            _unitOfWork.Students.UpdateAsync(student);
            _unitOfWork.Complete();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _unitOfWork.Students.GetByIdAsync(id);
            if (student == null)
                return NotFound();

            _unitOfWork.Students.DeleteAsync(id);
            _unitOfWork.Complete();

            return NoContent();
        }
    }
}

