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
    public class StudentService : IStudentService
    {
        private IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateStudent(CreateStudentViewModel vm)
        {
            try
            {
                Student obj = vm.ConvertToModel(vm);
                await _unitOfWork.GenericRepository<Student>().AddAsync(obj);
                _unitOfWork.Save();
                return 1;
            }
            catch (Exception ex) { throw; }
           
        }

        public IEnumerable<StudentViewModel> GetAll()
        {
            try
            {
                var students = _unitOfWork.GenericRepository<Student>().GetAll().ToList();
                List<StudentViewModel> studentViewModelList = new();
                studentViewModelList = ListInfo(students);
                return studentViewModelList;
            }
            catch (Exception ex) { throw; }
            
        }

        public IEnumerable<ExamViewModel> GetExamResult(int studentId)
        {
            throw new NotImplementedException();
        }

        public List<StudentViewModel> ListInfo(List<Student> students)
        {
            return students.Select(x => new StudentViewModel(x)).ToList();
        }

        public bool SetGroupIdToStudent(GroupStudentViewModel viewModel)
        {
            try
            {
                foreach(var item in viewModel.studentList)
                {
                    var student = _unitOfWork.GenericRepository<Student>().GetById(item.Id);
                    if(item.IsChecked)
                    {
                        student.GroupId = viewModel.GroupId;
                        _unitOfWork.GenericRepository<Student>().Update(student);
                    }
                    else
                    {
                        student.GroupId = null;
                    }
                    _unitOfWork.Save();
                    return true;
                }
            }
            catch(Exception ex) { throw; }
            return false;
        }
    }
}
