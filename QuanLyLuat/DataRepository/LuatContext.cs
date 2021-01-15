using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository
{
    public class LuatContext:DbContext 
    {
        public LuatContext() : base("LuatConnection")
        {
           
        }

        public DbSet<Luat> Luats { get; set; }

    }
}
