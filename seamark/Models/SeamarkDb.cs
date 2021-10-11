using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace seamark.Models
{
  public class SeamarkDb : DbContext
  {
    public SeamarkDb()
       : base("name=SeamarkDb")
    {
    }
    public virtual DbSet<Account> Accounts { get; set; }
    public virtual DbSet<article> Articles { get; set; }
    public virtual DbSet<Comment> Comments { get; set; }
    //public virtual DbSet<highlights> Highlights { get; set; }
    public virtual DbSet<Vote> Votes { get; set; }
  }
}