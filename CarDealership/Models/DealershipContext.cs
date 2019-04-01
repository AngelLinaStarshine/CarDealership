using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CarDealership.Models
{
    public class DealershipContext : DbContext
    {
        public DealershipContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Owner> Owners { get; set; }

        public static DealershipContext Create()
        {
            return new DealershipContext();
        }
    }
}