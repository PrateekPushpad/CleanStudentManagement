using CleanStudentManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.Models
{
    public class QnAsViewModel
    {
        public QnAsViewModel(QnAs qnAs)
        {
            Id = qnAs.Id;
            QuestionTitle = qnAs.QuestionTitle;
            ExamId = qnAs.ExamId;
            Answer = qnAs.Answer;
            Option1 = qnAs.Option1;
            Option2 = qnAs.Option2;
            Option3 = qnAs.Option3;
            Option4 = qnAs.Option4;
        }

        public int Id { get; set; }
        public string QuestionTitle { get; set; }
        public int ExamId { get; set; }
        public int Answer { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
    }
}
