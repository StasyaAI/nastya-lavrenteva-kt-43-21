using System.Text.Json.Serialization;

namespace _1_лабораторная.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public int? TeacherHeaderId {get; set;}
        [JsonIgnore]
        public Teacher? Teacher { get; set; }
    }
}
