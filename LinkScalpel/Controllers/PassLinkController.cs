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
    public class PassLinkController : Controller
    {
        ApplicationDbContext context;

        public PassLinkController(ApplicationDbContext context)
        {
            this.context = context;
        }


        public ActionResult Index()
        {
            return View(context.PassLinks);
        }

        [HttpPost]
        public ActionResult Index(string id, string password)
        {
            var link = context.PassLinks.First(x => x.Id == id);
            if (link.Password == password)
                return Redirect(link.Path);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PassLink link)
        {
            try
            {
                if (link.Name == null)
                    link.Name = Tools.LinkGenerate(context);
                if (!Tools.Unique(context, link.Name))
                    return RedirectToAction(nameof(Create));
                context.PassLinks.Add(link);
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