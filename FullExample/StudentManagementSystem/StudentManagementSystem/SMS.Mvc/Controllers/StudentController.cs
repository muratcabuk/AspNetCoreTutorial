using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SMS.BL.Domain.General;
using SMS.BL.Domain.Student;
using SMS.Core.Web.Extensions;
using SMS.Globalizaiton.Resources;
using SMS.Mvc.Models.Student;

namespace SMS.Mvc.Controllers
{
    public class StudentController: Controller
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentManager _studentManager;
        private readonly IOptionManager _optionManager;
        private readonly IMapper _mapper;

        public StudentController(ILogger<StudentController> logger,
                                 IStudentManager studentManager,
                                 IOptionManager optionManager,
                                 IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _studentManager = studentManager;
            _optionManager = optionManager;
        }

        public  async Task<IActionResult> Index()
        {
            var studentIndexViewModel = new StudentIndexViewModel
            {
                WelcomeMessage = "Welcome to SMS"
            };

            return View(studentIndexViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> List(StudentFilterViewModel studentFilterViewModel)
        {

            var studentListViewModel = new StudentListViewModel();

            var studentListResult = await _studentManager.GetList(_mapper.Map<StudentFilterModel>(studentFilterViewModel));

            if (studentListResult.IsOk)
            {
                var students = _mapper.Map<List<StudentMvcDto>>(studentListResult.Data.Students);
                studentListViewModel.Students = students;
            }
             
            var timeTextResult = await _studentManager.GetCachedData();

            studentListViewModel.TimeText = timeTextResult.Data;
            studentListViewModel.ReturnMessage = Resource.OperationCompletedSuccessfully;


            studentFilterViewModel.Genders = await _optionManager.GetGenders();

            var result = (StudentListViewModel: studentListViewModel,
                          StudentFilterViewModel: studentFilterViewModel);


            return View(result);

        }


        public async Task<IActionResult> List()
        {
            var studentListViewModel = new StudentListViewModel{Students = new List<StudentMvcDto>()};

            var genders = await _optionManager.GetGenders();

            var studentFilterViewModel = new StudentFilterViewModel{Genders = genders };

            var result = (StudentListViewModel: studentListViewModel,
                StudentFilterViewModel: studentFilterViewModel);

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddUpdate(StudentAddUpdateViewModel studentAddUpdateViewModel)
        {
            var genders = await _optionManager.GetGenders();

            var studentBlDto = _mapper.Map<StudentBlDto>(studentAddUpdateViewModel.Student);

            var studentAddUpdateModel = new StudentAddUpdateModel
            {
                Student = studentBlDto
            };

           var result = await _studentManager.Add(studentAddUpdateModel);
           
           ModelState.FromSpec(result.SpecResult.FailedSpecifications);     
            
           studentAddUpdateViewModel.Student.Id = result.Data;
           studentAddUpdateViewModel.Message = result.Message;
           studentAddUpdateViewModel.Genders = genders;

           return View(studentAddUpdateViewModel);

        }

        public async Task<IActionResult> AddUpdate()
        {
            var genders = await _optionManager.GetGenders();

            var studentAddUpdateViewModel = new StudentAddUpdateViewModel {Genders = genders};
          
            return View(studentAddUpdateViewModel);

        }


    }
}
