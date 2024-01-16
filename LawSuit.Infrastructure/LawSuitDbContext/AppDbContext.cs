using LawSuit.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawSuit.Infrastructure.LawSuitDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        DbSet<Attachment> Attachments { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Administrator> Administrators { get; set; }
        DbSet<Complaint> Complaints { get; set; }
        DbSet<Demand> Demands { get; set; }
    }
}
