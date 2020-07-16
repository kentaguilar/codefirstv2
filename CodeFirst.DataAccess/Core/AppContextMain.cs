using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CodeFirst.DataAccess.Models;

namespace CodeFirst.DataAccess.Core
{
    public class AppContextMain : DbContext
    {
        public virtual DbSet<Student> Students { get; set; }

        public AppContextMain()
            : base("name=MainConnectionString")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
    }
}
