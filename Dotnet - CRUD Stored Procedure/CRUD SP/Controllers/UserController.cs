using CRUD_SP.Models;
using CRUD_SP.Service;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_SP.Controllers
{
    public class UserController : Controller
    {
        UserDAL userDal = new UserDAL();
        public IActionResult List()
        {
            var data = userDal.GetUsers();
            return View(data);
        }

        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public IActionResult Create(UserModel user)
        {
            if(userDal.InsertUser(user))
            {
                TempData["InsertMessage"] = "User saved successfully";
                return RedirectToAction("List");
            }
            else
            {
                TempData["InsertErrorMessage"] = "User not saved";

            }
            return View();
        }

    }
}
