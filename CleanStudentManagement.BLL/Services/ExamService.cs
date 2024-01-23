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
    public class ExamService : IExamService
    {
        private IUnitOfWork _unitOfWork;

        public ExamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddExam(CreateExamViewModel viewModel)
        {
            try
            {
                var model = viewModel.ConvertToModel(viewModel);
                _unitOfWork.GenericRepository<Exam>().Add(model);
                _unitOfWork.Save();
            }

            catch(Exception ex){
                throw;
            }
        }

        public PagedResult<ExamViewModel> GetAll(int PageNumber, int PageSize)
        {
            try
            {
                int excludeRecord = (PageNumber * PageSize) - PageSize;
                List<ExamViewModel> examViewModel = new List<ExamViewModel>();
                var examList = _unitOfWork.GenericRepository<Exam>().GetAll()
                    .Skip(excludeRecord).Take(PageSize).ToList();

                examViewModel = ListInfo(examList);
                var result = new PagedResult<ExamViewModel>
                {
                    Data = examViewModel,
                    TotalItems = _unitOfWork.GenericRepository<Exam>()
                    .GetAll().Count(),
                    PageNumber = PageNumber,
                    PageSize = PageSize
                };
                return result;
            }
            catch (Exception ex) { throw; }
        }

        public IEnumerable<ExamViewModel> GetAllExams()
        {
            List<ExamViewModel> examViewModel = new();
            var exams = _unitOfWork.GenericRepository<Exam>().GetAll().ToList();
            examViewModel = ListInfo(exams);
            return examViewModel;
        }

        private List<ExamViewModel> ListInfo(List<Exam> examList)
        {
            return examList.Select(x => new ExamViewModel(x)).ToList();
        }

    }
}
