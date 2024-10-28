using giuakiDotNet.Models;
using giuakiDotNet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace giuakiDotNet.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        QlnhaHangContext db = new QlnhaHangContext();
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            var users = db.Users.ToList();
            return View(users);
            
        }
        [Route("danhmucsanpham")]
        public IActionResult DanhMucSanPham()
        {
            var data = db.MenuItems.AsQueryable().Select(p => new MenuItemVM
            {
                MenuItemId = p.MenuItemId,
                Name = p.Name,
                Image = p.Image,
                Description = p.Description,
                Price = p.Price,
                SubCategoryId = p.SubCategoryId
            });
            return View(data.ToList());
        }

        //them moi user
        [Route("ThemUserMoi")]
        [HttpGet]
        public IActionResult ThemUserMoi()
        {
            return View();
        }
        [Route("ThemUserMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemUserMoi(User sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(sanPham);
                db.SaveChanges();
                TempData["Message"] = "Người dùng đã được thêm";

                return RedirectToAction("Index");
            }
            TempData["Message"] = "Không thêm được";

            return View();
        }
        //them moi
        [Route("ThemSanPhamMoi")]
        [HttpGet]
        public IActionResult ThemSanPhamMoi()
        {
            ViewBag.Category = new SelectList(db.SubCategories.ToList(), "SubCategoryId", "SubCategoryName");
           
            return View();
        }
        [Route("ThemSanPhamMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPhamMoi(MenuItem sanPham)
        {
            if (ModelState.IsValid)
            {
                db.MenuItems.Add(sanPham);
                db.SaveChanges();
                TempData["Message"] = "Sản phẩm đã được thêm";

                return RedirectToAction("DanhMucSanPham");
            }
            return View();
        }

        // sua
        [Route("SuaSanPham")]
        [HttpGet]
        public IActionResult SuaSanPham(int maSanPham)
        {
            ViewBag.Category = new SelectList(db.SubCategories.ToList(), "SubCategoryId", "SubCategoryName");


            var sanPham = db.MenuItems.Find(maSanPham);
            return View(sanPham);
        }
        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(MenuItem sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Update(sanPham);
                db.SaveChanges();
                TempData["Message"] = "Sản phẩm đã được sửa";

                return RedirectToAction("DanhMucSanPham", "HomeAdmin");
            }
            return View(sanPham);
        }
        [Route("XoaSanPham")]
        [HttpGet]
        public IActionResult XoaSanPham(int maSanPham)
        {
            try
            {
                db.Remove(db.MenuItems.Find(maSanPham));
                db.SaveChanges();
                TempData["Message"] = "Sản phẩm đã được xóa";
            }
            catch (Exception ex) {
                TempData["Message"] = "Sản phẩm khong xóa được";
            }


            return RedirectToAction("DanhMucSanPham", "HomeAdmin");
        }
    }
}
