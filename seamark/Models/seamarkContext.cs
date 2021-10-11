using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace seamark.Models
{
    public class seamarkContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public seamarkContext() : base("name=seamarkContext")
        {
        }

    public System.Data.Entity.DbSet<seamark.Models.Account> accounts { get; set; }

    public System.Data.Entity.DbSet<seamark.Models.article> articles { get; set; }

    public System.Data.Entity.DbSet<seamark.Models.Comment> comments { get; set; }

    public System.Data.Entity.DbSet<seamark.Models.highlights> highlights { get; set; }

    public System.Data.Entity.DbSet<seamark.Models.Vote> Votes { get; set; }
  }
}
