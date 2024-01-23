using CleanStudentManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.Models
{
    public class ExamViewModel
    {
        public ExamViewModel(Exam exam)
        {
            Id = exam.Id;
            Title = exam.Title;
            Description = exam.Description;
            StartDate   = exam.StartDate;
            Time = exam.Time;
            GroupId = exam.GroupId;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public int Time { get; set; }
        public int GroupId { get; set; }
    }
}
