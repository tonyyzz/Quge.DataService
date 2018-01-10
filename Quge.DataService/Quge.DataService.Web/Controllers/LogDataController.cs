using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quge.DataService.Web.Controllers
{
	public class LogDataController : Controller
	{
		// GET: LogData
		public ActionResult Index()
		{
			return Json(new { }, JsonRequestBehavior.AllowGet);
		}
	}
}