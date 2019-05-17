using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LinkScalpel.Models;

namespace LinkScalpel.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Link> Links { get; set; }
        public DbSet<PassLink> PassLinks { get; set; }
        public DbSet<TimeLink> TimeLinks { get; set; }
        public DbSet<CountLink> CountLinks { get; set; }
    }
}
