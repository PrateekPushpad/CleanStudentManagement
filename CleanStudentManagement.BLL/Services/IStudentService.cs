using CleanStudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.BLL.Services
{
    public interface IStudentService
    {
        Task<int> CreateStudent(CreateStudentViewModel vm);
        IEnumerable<StudentViewModel> GetAll();
        IEnumerable<ExamViewModel> GetExamResult(int studentId);
        bool SetGroupIdToStudent(GroupStudentViewModel viewModel);
    }
}
