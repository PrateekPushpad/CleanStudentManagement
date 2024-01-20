using CleanStudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.BLL.Services
{
    public interface IAccountService
    {
        bool AddTeacher(UserViewModel model);
        LoginViewModel Login(LoginViewModel loginViewModel);
        PagedResult<TeacherViewModel> GetAllTeacher(int PageNumber, int PageSize);
    }
}
