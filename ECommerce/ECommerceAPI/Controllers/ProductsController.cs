using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
	public class ProductsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
