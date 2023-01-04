using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.BLL.Dtos
{
    public class StudentCreateDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public byte Age { get; set; }
    }
}
