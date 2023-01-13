using FluentValidation;
using University.BLL.Dtos;
using University.DAL.Entities;

namespace University.BLL.Validators.StudentValidators
{
    public class StudentCreateDtoValidation : AbstractValidator<StudentCreateDto>
    {
        public StudentCreateDtoValidation()
        {
            RuleFor(x => x.Firstname).NotNull().NotEmpty().MinimumLength(3).MaximumLength(20);

            //RuleFor(x=>x.Age).ExclusiveBetween((byte)17, (byte)60);
            RuleFor(x => x.Age).GreaterThan((byte)17).WithMessage("yash 17-den boyuk olmalidir").LessThan((byte)60).WithMessage("yash 60-dan kichik olmalidir");
        }
    }
}
