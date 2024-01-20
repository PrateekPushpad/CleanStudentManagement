using CleanStudentManagement.Data.Entities;
using CleanStudentManagement.Data.UnitOfWork;
using CleanStudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.BLL.Services
{
    public class AccountService : IAccountService
    {
        private IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddTeacher(UserViewModel vm)
        {
            try
            {
                User model = new User
                {
                    Name = vm.Name,
                    UserName = vm.UserName,
                    Password = vm.Password,
                    Role = (int)EnumRoles.Teacher
                };
                _unitOfWork.GenericRepository<User>().Add(model);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {

            }
            return true;
        }

        public PagedResult<TeacherViewModel> GetAllTeacher(int PageNumber, int PageSize)
        {
            int excludeRecord = (PageNumber * PageSize) - PageSize;
            List<TeacherViewModel> teacherViewModel = new List<TeacherViewModel>();
            var userList = _unitOfWork.GenericRepository<User>().GetAll()
                .Where(x => x.Role == (int)EnumRoles.Teacher)
                .Skip(excludeRecord).Take(PageSize).ToList();

            teacherViewModel = ListInfo(userList);
            var result = new PagedResult<TeacherViewModel>
            {
                Data = teacherViewModel,
                TotalItems = _unitOfWork.GenericRepository<User>()
                .GetAll().Where(x =>x.Role ==  (int)EnumRoles.Teacher).Count(),
                PageNumber = PageNumber,
                PageSize = PageSize
            };
            return result;
        }

        private List<TeacherViewModel> ListInfo(List<User> userList)
        {
            return userList.Select(x => new TeacherViewModel(x)).ToList();
        }

        public LoginViewModel Login(LoginViewModel loginViewModel)
        {
                var user = _unitOfWork.GenericRepository<User>().GetAll().
                    FirstOrDefault(a =>a.UserName == loginViewModel.UserName.Trim()
                    && a.Password == loginViewModel.Password && a.Role == loginViewModel.Role);

                if(user != null)
                {
                    loginViewModel.Id = user.Id;
                    return loginViewModel;
                }
            return null;
        }
    }
}
