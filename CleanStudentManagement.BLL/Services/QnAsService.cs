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
    public class QnAsService : IQnAsService
    {
        private IUnitOfWork _unitOfWork;

        public QnAsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddQnAs(CreateQnAsViewModel viewModel)
        {
            try
            {
                var model = viewModel.ConvertToModel(viewModel);
                _unitOfWork.GenericRepository<QnAs>().Add(model);
                _unitOfWork.Save();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<QnAsViewModel> GetAllByExamId(int ExamId)
        {
            var QnAs = _unitOfWork.GenericRepository<QnAs>().GetAll()
                .Where(x =>x.ExamId == ExamId).ToList();
            return ListInfo(QnAs);
        }

        public bool IsAttendExam(int ExamId, int StudentId)
        {
            var result = _unitOfWork.GenericRepository<ExamResult>()
                .GetAll().Any(x=>x.ExamId == ExamId && x.StudentId == StudentId);
            return result == false? false: true;
        }

        public bool SetExamResult(AttendExamViewModel viewModel)
        {
            try
            {
                foreach (var item in viewModel.QnAsList)
                {
                    ExamResult result = new ExamResult();
                    result.StudentId = item.Id;
                    result.ExamId = item.ExamId;
                    //result.QnAsId = item.Id;
                    result.Answer = item.Answer;
                    _unitOfWork.GenericRepository<ExamResult>().Add(result);
                    _unitOfWork.Save();
                    return true;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            return false;
        }

        PagedResult<QnAsViewModel> IQnAsService.GetAll(int pageNumber, int pageSize)
        {
            var excludeRecords = (pageNumber * pageSize) - pageSize;
            List<QnAsViewModel> qnAsViewModel = new List<QnAsViewModel>();

            var qnAsList = _unitOfWork.GenericRepository<QnAs>()
                .GetAll().Skip(excludeRecords).Take(pageSize).ToList();

            qnAsViewModel = ListInfo(qnAsList);
            var result = new PagedResult<QnAsViewModel>
            {
                Data = qnAsViewModel,
                TotalItems = _unitOfWork.GenericRepository<QnAs>()
                .GetAll().Count(),
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }

        private List<QnAsViewModel> ListInfo(List<QnAs> qnasList)
        {
            return qnasList.Select(x => new QnAsViewModel(x)).ToList();
        }
    }
}
