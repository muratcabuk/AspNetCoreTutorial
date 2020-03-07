using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SMS.BL.Domain.General;
using SMS.BL.Domain.Teacher;
using SMS.Core.Web.Extensions;
using SMS.Globalizaiton.Resources;
using SMS.Mvc.Models.Teacher;

namespace SMS.Mvc.Controllers
{
    public class TeacherController: Controller
    {
        private readonly ILogger<TeacherController> _logger;
        private readonly ITeacherManager _teacherManager;
        private readonly IOptionManager _optionManager;
        private readonly IMapper _mapper;

        public TeacherController(ILogger<TeacherController> logger,
                                 ITeacherManager teacherManager,
                                 IOptionManager optionManager,
                                 IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _teacherManager = teacherManager;
            _optionManager = optionManager;
        }

        public  async Task<IActionResult> Index()
        {
            var teacherIndexViewModel = new TeacherIndexViewModel
            {
                WelcomeMessage = "Welcome to SMS"
            };

            return View(teacherIndexViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> List([FromForm]TeacherFilterViewModel teacherFilterViewModel)
        {

            var teacherListViewModel = new TeacherListViewModel();

            var teacherListResult = await _teacherManager.GetList(_mapper.Map<TeacherFilterModel>(teacherFilterViewModel));

            if (teacherListResult.IsOk)
            {
                var teachers = _mapper.Map(teacherListResult.Data.Teachers, new List<TeacherMvcDto>());
                teacherListViewModel.Teachers = teachers;
            }
             
            var timeTextResult = await _teacherManager.GetCachedData();
            
            teacherFilterViewModel.Genders= await _optionManager.GetGenders();
            teacherListViewModel.TimeText = timeTextResult.Data;
            teacherListViewModel.ReturnMessage = Resource.OperationCompletedSuccessfully;

            ViewBag.TeacherFilterViewModel = teacherFilterViewModel;

            return View(teacherListViewModel);

        }

        public async Task<IActionResult> List()
        {
            var studentListViewModel = new TeacherListViewModel { Teachers = new List<TeacherMvcDto>() };


            var teacherFilterViewModel = new TeacherFilterViewModel
            {
                Genders = await _optionManager.GetGenders()
            };


            ViewBag.TeacherFilterViewModel = teacherFilterViewModel;

            return View(studentListViewModel);
        }






        [HttpPost]
        public async Task<IActionResult> AddUpdate(TeacherAddUpdateViewModel teacherAddUpdateViewModel)
        {
            var genders = await _optionManager.GetGenders();

            var teacherBlDto = _mapper.Map<TeacherBlDto>(teacherAddUpdateViewModel.Teacher);

            var teacherAddUpdateModel = new TeacherAddUpdateModel
            {
                Teacher = teacherBlDto
            };

           var result = await _teacherManager.Add(teacherAddUpdateModel);
           
           ModelState.FromSpec(result.SpecResult.FailedSpecifications);     
            
           teacherAddUpdateViewModel.Teacher.Id = result.Data;
           teacherAddUpdateViewModel.Message = result.Message;
           teacherAddUpdateViewModel.Genders = genders;

           return View(teacherAddUpdateViewModel);

        }

        public async Task<IActionResult> AddUpdate()
        {
            var genders = await _optionManager.GetGenders();

            var teacherAddUpdateViewModel = new TeacherAddUpdateViewModel {Genders = genders};
          
            return View(teacherAddUpdateViewModel);

        }


    }
}
