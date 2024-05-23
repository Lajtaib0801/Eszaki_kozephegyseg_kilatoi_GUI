using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eszaki_kozephegyseg_kilatoi_GUI.Models
{
    internal class Context : DbContext
    {
        public DbSet<LocationModel> Locations { get; set; }
        public DbSet<ViewpointModel> Viewpoints { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string constr = "Server=localhost;Database=ncmviewpoints;Uid=root;Pwd=;";
            optionsBuilder.UseMySql(constr, ServerVersion.AutoDetect(constr));
        }
    }
}
