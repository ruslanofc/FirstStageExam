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
    public class LinkController : Controller
    {
        ApplicationDbContext context;

        public LinkController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: Link
        public ActionResult Index()
        {
            return View(context.Links);
        }
        
        // GET: Link/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Link/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Link link)
        {
            try
            {
                if(link.Name == null)
                    link.Name = Tools.LinkGenerate(context);
                if (!Tools.Unique(context, link.Name))
                    return RedirectToAction(nameof(Create));
                context.Links.Add(link);
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