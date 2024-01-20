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
    public class GroupService : IGroupService
    {
        private IUnitOfWork _unitOfWork;

        public GroupService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public GroupViewModel AddGroup(GroupViewModel groupVM)
        {
            try
            {
                var model = groupVM.ConverttoGroup(groupVM);
                _unitOfWork.GenericRepository<Group>().Add(model);
                _unitOfWork.Save();
            }
            catch(Exception ex)
            {

            }
            return groupVM;
        }

        public PagedResult<GroupViewModel> GetAll(int pageNumber, int pageSize)
        {
            var excludeRecords = (pageNumber * pageSize) - pageSize;
            List<GroupViewModel> groupViewModel = new List<GroupViewModel>();

            var groupList = _unitOfWork.GenericRepository<Group>()
                .GetAll().Skip(excludeRecords).Take(pageSize).ToList();

            groupViewModel = ListInfo(groupList);
            var result = new PagedResult<GroupViewModel>
            {
                Data = groupViewModel,
                TotalItems = _unitOfWork.GenericRepository<Group>()
                .GetAll().Count(),
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }

        private List<GroupViewModel> ListInfo(List<Group> groupList)
        {
            return groupList.Select(x => new GroupViewModel(x)).ToList(); 
        }

        public IEnumerable<GroupViewModel> GetAllGroup()
        {
            try
            {
                List<GroupViewModel> groupViewModel = new List<GroupViewModel>();

                var groupList = _unitOfWork.GenericRepository<Group>()
                    .GetAll().ToList();

                groupViewModel = ListInfo(groupList);
                return groupViewModel;
            }
            catch (Exception ex) 
            {
                throw;
            }
        }

        public GroupViewModel GetGroup(int id)
        {
            var group = _unitOfWork.GenericRepository<Group>().GetById(id);
            var vm = new GroupViewModel(group);
            return vm;
        }
    }
}
