using CleanStudentManagement.BLL.Services;
using CleanStudentManagement.Models;
using CleanStudentManagement.UI.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanStudentManagement.UI.Controllers
{
    [RoleAuthorize(2)]
    public class ExamController : Controller
    {
        private readonly IGroupService _groupService;
        private readonly IExamService _examService;

        public ExamController(IGroupService groupService, IExamService examService)
        {
            _groupService = groupService;
            _examService = examService;
        }

        public IActionResult Index(int pageNumber=1, int pageSize=10)
        {
            return View(_examService.GetAll(pageNumber, pageSize));
        }
        [HttpGet]
        public IActionResult Create()
        {
            var group = _groupService.GetAllGroup();
            ViewBag.AllGroup = new SelectList(group, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateExamViewModel vm)
        {
            _examService.AddExam(vm);
            return RedirectToAction("Index");
        }
    }
}
