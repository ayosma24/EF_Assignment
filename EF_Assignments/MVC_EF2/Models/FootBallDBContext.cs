using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_Assignment1_Program2.Models
{
    public class FootBallDBContext : DbContext
    {
         public System.Data.Entity.DbSet<MVC_Assignment1_Program2.Models.FootBallLeague> FootBallLeagues { get; set; }
    }
}