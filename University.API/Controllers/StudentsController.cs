using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using University.BLL.Dtos;
using University.BLL.Services.Contracts;
using University.DAL.DataContext;
using University.DAL.Entities;
using University.DAL.Repositories.Contracts;

namespace University.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Student> _studentRepository;
        private readonly IStudentService _studentService;

        public StudentsController(IMapper mapper, IRepository<Student> studentRepository, IStudentService studentService)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await _studentRepository.GetAllAsync();
            var studentsDtos = _mapper.Map<List<StudentDto>>(students);
            return Ok(studentsDtos); 
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> Get([FromRoute] int? id)
        {
            if (id == null)
                return NotFound();

            var student = await _studentRepository.GetAsync(id);

            if (student == null)
                return NotFound("Bele telebe movcud deyil");

            var studentDto = _mapper.Map<StudentDto>(student);            

            return Ok(studentDto);
        }

        [HttpPost("createdStudent")]
        public async Task<IActionResult> Post([FromForm] StudentCreateDto studentCreateDto)
        {
            var createdStudent = _mapper.Map<Student>(studentCreateDto);

            await _studentRepository.AddAsync(createdStudent);

            return Created(HttpContext.Request.Path, createdStudent.Id);
        }

        [HttpPost("createdStudents")]
        public async Task<IActionResult> Post(StudentCreateDto[] studentCreateDtos)
        {
            IEnumerable<Student> createdStudents = _mapper.Map<StudentCreateDto[],IEnumerable<Student>>(studentCreateDtos);
           
            await _studentRepository.AddAsync(createdStudents);

            return Created(HttpContext.Request.Path, "ok");
        }

        [HttpPost("createdStudentsWithParams")]
        public async Task<IActionResult> ParamsPost(StudentCreateDto[] studentCreateDtos)
        {
            Student[] createdStudents = _mapper.Map<StudentCreateDto[], Student[]>(studentCreateDtos);

            await _studentRepository.AddAsync(createdStudents);

            return Created(HttpContext.Request.Path, "ok");
        }

        [HttpPut("{id?}")]
        public async Task<IActionResult> Put([FromRoute] int? id, [FromBody] StudentDto studentDto)
        {
            if (id == null) return NotFound();

            var existStudent = await _studentRepository.GetAsync(id);

            if (existStudent == null) return NotFound();

            if (studentDto.Id != id) return BadRequest();

            var student = _mapper.Map<Student>(studentDto);

            await _studentRepository.UpdateAsync(student);

            return Ok();
        }

        [HttpDelete("{id?}")]
        public async Task<IActionResult> Delete([FromRoute] int? id)
        {
            await _studentRepository.DeleteAsync(id);

            return Ok();
        }

        [HttpDelete("deleteStudent")]
        public async Task<IActionResult> DeleteEntity(StudentCreateDto studentCreateDto)
        {
            var deleteStudent = _mapper.Map<Student>(studentCreateDto);

            await _studentService.DeleteAsync(deleteStudent);

            return Ok();
        }

        [HttpGet("test")]
        public async Task<IActionResult> Test()
        {
            return Ok(await _studentService.Test());
        }
    }
}
