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
    public class CountLinkController : Controller
    {
        ApplicationDbContext context;

        public CountLinkController(ApplicationDbContext context)
        {
            this.context = context;
        }

        
        public ActionResult Index()
        {
            Tools.RemoveCountLinks(context);
            return View(context.CountLinks);
        }

        [HttpPost]
        public IActionResult Index(string path, string id, int count)
        {
            if (count < 1)
            {
                context.CountLinks.Remove(context.CountLinks.First(x => x.Id == id));
                return RedirectToAction(nameof(Index));
            }
            context.CountLinks.First(x => x.Id == id).Count--;
            context.SaveChanges();
            return Redirect(path);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CountLink link)
        {
            try
            {
                if (link.Name == null || link.Count < 1)
                    link.Name = Tools.LinkGenerate(context);
                if (!Tools.Unique(context, link.Name))
                    return RedirectToAction(nameof(Create));
                context.CountLinks.Add(link);
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