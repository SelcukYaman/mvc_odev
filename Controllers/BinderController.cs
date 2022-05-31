using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcDenemeHello.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcDenemeHello.Controllers
{
    public class BinderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        /* [HttpPost]
         public IActionResult Index(FormCollection form)
         {
             var ograd = form["OgrenciAd"].ToString();
             var ogrsoyad = form["OgrenciSoyad"].ToString(); 
             var ogryas = form["OgrenciYas"].ToString();

             return View();
         } */
        [HttpPost]
        public IActionResult Index(IFormCollection kayit)
        {

            //var ad = form.Ad.ToString();
            //var soyad = form.Soyad.ToString();
            Ogrenci ogr1 = new Ogrenci();
            ogr1.Ad = kayit["ograd"].ToString();
            ogr1.Soyad = kayit["ogrsoyad"].ToString();
            ogr1.Yas = int.Parse(kayit["ogryas"]);
            using (var ctx = new OkulContext())
            {
                ctx.Ogrenciler.Add(ogr1);
                ctx.SaveChanges();
            }
         

            return View();
        }
        public ViewResult ogrencilistele()
        {
            List<Ogrenci> ogr = new List<Ogrenci>();
            using (var ctx = new OkulContext())
            {
                var lst = ctx.Ogrenciler.ToList();
                foreach (var item in lst)
                {
                    ogr.Add(item);
                }
            }
            return View(ogr);
        }
    }

    class OkulContext : DbContext
    {



        public DbSet<Ogrenci> Ogrenciler { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source =.; Integrated Security = true; Initial Catalog = Ogr4db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ogrenci>().ToTable("tblOgr");

            //modelBuilder.Entity<Ogrenci>().Property(p => p.Ad).HasColumnType("varchar(30)").HasMaxLength(30).IsRequired();
            //bu tekniğe fluent Api denir kolonları özelleştirmede akıcı hızlı yazım işine denir.
        }

    }
}
