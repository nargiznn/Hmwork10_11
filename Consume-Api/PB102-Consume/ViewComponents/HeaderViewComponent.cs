using Microsoft.AspNetCore.Mvc;

namespace PB102_Consume.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }

    }
}
