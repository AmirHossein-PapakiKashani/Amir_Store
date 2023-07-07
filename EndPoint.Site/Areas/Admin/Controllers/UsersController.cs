using Amir_Store.Application.Services.Command.EditUser;
using Amir_Store.Application.Services.Command.RegisterUser;
using Amir_Store.Application.Services.Command.RemoveUser;
using Amir_Store.Application.Services.Command.UserStatusChange;
using Amir_Store.Application.Services.Queries.GetRoles;
using Amir_Store.Application.Services.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IGetUsersService _getUsersService;
        private readonly IGetRolesService _getRolesService;
        private readonly IRegisterUserService _registerUserService;
        private readonly IEditUserService _editUserService;
        private readonly IRemoveUserService _removeUserService;
       
        private readonly IUserStatusChangeService _userStatusChangeService;
        public UsersController(IGetUsersService getUsersService, 
                                IRegisterUserService registerUserService, 
                                IGetRolesService getRolesService, 
                                IEditUserService editUserService,
                                IRemoveUserService removeUserService,
                                IUserStatusChangeService userStatusChangeService)
        {
            _getUsersService = getUsersService;
            _registerUserService = registerUserService;
            _getRolesService = getRolesService;
            _editUserService = editUserService;
            _removeUserService = removeUserService;
            _userStatusChangeService = userStatusChangeService;
        }
        
        public IActionResult Index(string searchkey ,int page =1)
        {
            return View(_getUsersService.Execute(new RequestGetUserDto { Page = page , Searchkey = searchkey}));
        }



        [HttpGet]
        public IActionResult Create()
        {
            
            ViewBag.Roles = new SelectList(_getRolesService.Execute().Data, "Id", "Name");
            return View();
        }


        [HttpPost]
        public IActionResult Create(string Email, string FullName, long RoleId, string Password, string RePassword)
        {
            var result = _registerUserService.Execute(new RequestRegisterUserDto
            {
                Email = Email,
                FullName = FullName,
                roles = new List<RolesInRegisterUserDto>()
                   {
                        new RolesInRegisterUserDto
                        {
                             Id= RoleId
                        }
                   },
                Password = Password,
                RePasword = RePassword,
            });
            return Json(result);
        }


        [HttpPost]
        public IActionResult Delete(long UserId)
        {
            return Json(_removeUserService.Execute(UserId));
        }

        [HttpPost]
        public IActionResult UserSatusChange(long UserId)
        {
            return Json(_userStatusChangeService.Execute(UserId));
        }

        [HttpPost]
        public IActionResult Edit(long UserId, string Fullname)
        {
            return Json(_editUserService.Execute(new RequestEdituserDto
            {
                Fullname = Fullname,
                UserId = UserId,
            }));
        }



    }
}
