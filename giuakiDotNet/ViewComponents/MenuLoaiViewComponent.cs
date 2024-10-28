using Microsoft.AspNetCore.Mvc;
using giuakiDotNet.Models;
using giuakiDotNet.ViewModels;
namespace giuakiDotNet.ViewComponents
{
    public class MenuLoaiViewComponent: ViewComponent
    {
        private readonly QlnhaHangContext db;
        public MenuLoaiViewComponent(QlnhaHangContext context) => db = context;
        public IViewComponentResult Invoke()
        {
            var data = db.SubCategories.Select(loai => new SubCategoryVM
            {
                SubCategoryId = loai.SubCategoryId,
                SubCategoryName = loai.SubCategoryName,
                

            });
            return View(data);
        }

    }
}
