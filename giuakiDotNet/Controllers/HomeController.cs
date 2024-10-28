using giuakiDotNet.Models;
using giuakiDotNet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace giuakiDotNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        QlnhaHangContext db= new QlnhaHangContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? loai)
        {
            

            if (loai != null)
            {
                  var data = db.MenuItems.AsQueryable().Where(p => p.SubCategoryId == loai).Select(p => new MenuItemVM
                {
                    MenuItemId = p.MenuItemId,
                    Name = p.Name,
                    Image = p.Image,
                    Description = p.Description,
                     Price = p.Price,
                    SubCategoryId = loai
            });
                       return View(data.ToList());
            }
            else
            {
              var  data = db.MenuItems.AsQueryable().Select(p => new MenuItemVM
                {
                    MenuItemId = p.MenuItemId,
                    Name = p.Name,
                    Image = p.Image,
                    Description = p.Description,
                    Price = p.Price,
                    SubCategoryId = loai
                });
                return View(data.ToList());

            }


        }
        public IActionResult Detail(int maSp)
        {
            var p = db.MenuItems.AsQueryable().SingleOrDefault(x => x.MenuItemId == maSp);
            var res = new MenuItemVM
            {

                MenuItemId = p.MenuItemId,
                Name = p.Name,
                Image = p.Image,
                Description = p.Description,
                Price = p.Price,
                SubCategoryId = p.SubCategoryId
            };


            return View(res);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
