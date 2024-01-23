using CleanStudentManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.Models
{
    public class CreateQnAsViewModel
    {
        public string QuestionTitle { get; set; }
        public int ExamId { get; set; }
        public int Answer { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }

        public QnAs ConvertToModel(CreateQnAsViewModel viewModel)
        {
            return new QnAs
            {
                QuestionTitle = viewModel.QuestionTitle,
                ExamId = viewModel.ExamId,
                Answer = viewModel.Answer,
                Option1 = viewModel.Option1,
                Option2 = viewModel.Option2,
                Option3 = viewModel.Option3,
                Option4 = viewModel.Option4,
            };
        }
    }
}
