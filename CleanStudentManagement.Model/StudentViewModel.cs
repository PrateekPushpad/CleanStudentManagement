using CleanStudentManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.Models
{
    public class StudentViewModel
    {
        public StudentViewModel(Student student)
        {
            Name = student.Name;
            Id = student.Id;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class CheckBoxTable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }
}
