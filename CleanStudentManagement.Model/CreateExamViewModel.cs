using CleanStudentManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.Models
{
    public class CreateExamViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public int Time { get; set; }
        public int GroupId { get; set; }

        public Exam ConvertToModel(CreateExamViewModel viewModel)
        {
            return new Exam
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                StartDate = viewModel.StartDate,
                Time = viewModel.Time,
                GroupId = viewModel.GroupId
            };
        }
    }
}
