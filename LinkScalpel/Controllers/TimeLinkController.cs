using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkScalpel.Data;
using LinkScalpel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinkScalpel.Controllers
{
    public class TimeLinkController : Controller
    {
        ApplicationDbContext context;

        public TimeLinkController(ApplicationDbContext context)
        {
            this.context = context;
        }


        public ActionResult Index()
        {
            Tools.RemoveTimeLinks(context);
            return View(context.TimeLinks);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TimeLink link)
        {
            try
            {
                if (link.Name == null)
                    link.Name = Tools.LinkGenerate(context);
                if (!Tools.Unique(context, link.Name) || link.Time < DateTime.Now)
                    return RedirectToAction(nameof(Create));
                context.TimeLinks.Add(link);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Create));
            }
        }
    }
}