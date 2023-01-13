using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BLL.Services.Contracts;
using University.BLL.Services;
using FluentValidation;
using University.BLL.Dtos;
using University.BLL.Validators.StudentValidators;

namespace University.BLL
{
    public static class BllServiceRegistration
    {
        public static IServiceCollection AddBllServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentManager>();
            services.AddScoped<IValidator<StudentCreateDto>, StudentCreateDtoValidation>();

            return services;
        }
    }
}
