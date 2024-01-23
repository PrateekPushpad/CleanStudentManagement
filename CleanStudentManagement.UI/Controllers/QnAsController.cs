using CleanStudentManagement.BLL.Services;
using CleanStudentManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanStudentManagement.UI.Controllers
{
    public class QnAsController : Controller
    {
        private IExamService _examService;
        private IQnAsService _qnAsService;

        public QnAsController(IExamService examService, IQnAsService qnAsService)
        {
            _examService = examService;
            _qnAsService = qnAsService;
        }

        public IActionResult Index(int pageNumber=1, int pageSize=10)
        {
            var qnAs = _qnAsService.GetAll(pageNumber, pageSize);
            return View(qnAs);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var exams = _examService.GetAllExams();
            ViewBag.Exams = new SelectList(exams, "Id", "Title");
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateQnAsViewModel viewModel)
        {
            _qnAsService.AddQnAs(viewModel);
            return RedirectToAction("Index");
        }
    }
}
