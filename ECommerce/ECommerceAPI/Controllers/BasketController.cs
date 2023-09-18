using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
	public class BasketController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
