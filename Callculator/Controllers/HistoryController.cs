using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace Callculator.Controllers
{
    public class HistoryController : Controller
    {
		private readonly string history = $"{Path.GetTempPath()}/history.data";

		public ActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public ActionResult Get()
		{
			var result = System.IO.File.Exists(history)
				? System.IO.File.ReadAllLines(history).Reverse().Take(9).Select(x => x.Split(';').ToList()).ToList()
				: new List<List<string>>();

			return Json(result, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public ActionResult Clear()
		{
			System.IO.File.Delete(history);
			
			return Json("OK");
		}

		[HttpPost]
		public ActionResult Save(string amount, string percent, string interest, int days, string endDate, int year, string income)
		{
			var startDate = DateTime.Parse(endDate).AddDays(-days).ToString("dd/MM/yyyy");
			System.IO.File.AppendAllText(history, $"{amount}; {percent}%; {interest}; {days}; {year}; {startDate}; {endDate}; {income}{Environment.NewLine}");
			return Json("OK");
		}
	}
}