using University.DAL.Base;

namespace University.DAL.Entities
{
    public class Student : TimeStample, IEntity
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public byte Age { get; set; }
    }
}
