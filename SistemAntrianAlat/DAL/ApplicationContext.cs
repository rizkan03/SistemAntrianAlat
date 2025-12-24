using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SistemAntrianAlat.Models;

namespace SistemAntrianAlat.DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("name=ApplicationContext")
        {

        }
        public DbSet<Pengajuan> Pengajuan { get; set; }
        //public DbSet<SoilTest> SoilTest { get; set; }
    }
}