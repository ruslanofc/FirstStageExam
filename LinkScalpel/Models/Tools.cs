using LinkScalpel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkScalpel.Models
{
    public static class Tools
    {
        public static string LinkGenerate(ApplicationDbContext context)
        {
            string link = "ScLnk//";
            Guid g = Guid.NewGuid();
            link += g.ToString().Substring(0, 13);
            while(!Unique(context, link))
            {
                link = "ScLnk//";
                g = Guid.NewGuid();
                link += g.ToString().Substring(0, 13);
            }
            return link;
        }

        public static bool Unique(ApplicationDbContext context, string link)
        {
            if (!context.Links.Any(x => x.Name == link) && !context.PassLinks.Any(x => x.Name == link) && !context.CountLinks.Any(x => x.Name == link) && !context.TimeLinks.Any(x => x.Name == link))
                return true;
            return false;
        }

        public static void RemoveCountLinks(ApplicationDbContext context)
        {
            foreach(var link in context.CountLinks)
                if(link.Count < 1)
                    context.CountLinks.Remove(link);
            context.SaveChanges();
        }

        public static void RemoveTimeLinks(ApplicationDbContext context)
        {
            foreach (var link in context.TimeLinks)
                if (link.Time < DateTime.Now)
                    context.TimeLinks.Remove(link);
            context.SaveChanges();
        }
    }
}
