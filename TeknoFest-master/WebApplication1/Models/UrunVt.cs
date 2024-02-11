using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UrunVt : DbContext
    {
        public DbSet<UrunModel> UrunTable { get; set; }
        public DbSet<IslemModel> IslemTable { get; set; }
        public static int UrunID { get; set; }
        public static int IslemID { get; set; }
    }
}