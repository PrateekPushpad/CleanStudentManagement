using CleanStudentManagement.BLL.Services;
using CleanStudentManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace CleanStudentManagement.UI.Controllers
{
    public class GroupController : Controller
    {
        private IGroupService _groupService;
        private IStudentService _studentService;

        public GroupController(IGroupService groupService, IStudentService studentService)
        {
            _groupService = groupService;
            _studentService = studentService;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_groupService.GetAll(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(GroupViewModel vm)
        {
            var _vm = _groupService.AddGroup(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            GroupStudentViewModel vm = new GroupStudentViewModel();
            var group = _groupService.GetGroup(id);
            var students = _studentService.GetAll();
            vm.GroupId = group.Id;
            foreach(var student in students)
            {
                vm.studentList.Add(new CheckBoxTable { Id = student.Id, Name = student.Name, IsChecked =false });
            }
            return View(vm);
        }
        [HttpPost]
        public IActionResult Details(GroupStudentViewModel viewModel)
        {
            bool result = _studentService.SetGroupIdToStudent(viewModel);
            if(result)
            {
                return RedirectToAction("Index");
            }
            else { return View(viewModel); }
        }
    }
}
