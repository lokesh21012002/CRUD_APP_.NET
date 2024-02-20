using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NET.Models;

namespace NET.Db
{
    public class DbConn : DbContext
    {
        public DbConn(DbContextOptions<DbConn> options) : base(options)
        {


        }

        public DbSet<StuentModel> CSharpCornerArticles { get; set; }


    }
}