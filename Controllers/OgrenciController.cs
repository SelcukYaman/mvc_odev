using Microsoft.AspNetCore.Mvc;
using MvcDenemeHello.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcDenemeHello.Controllers
{
    public class OgrenciController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult OgrenciBilgi(int? id)//nullable
        {
           
            //generic yapılı bir class
            Deneme<Test,int> d = new Deneme<Test,int>();
            

            Ogrenci[] ogrenciler = new Ogrenci[3];
            ogrenciler[0] = new Ogrenci("Selçuk", "Yaman", 20);
            //dizi ile birden çok ogrenci taşıma yolu viewe ogrenciler gönderilir.

            ArrayList al = new ArrayList();
            al.Add(new Ogrenci("Serhat", "Kılıç", 22));
            al.Add(new Ogrenci("Serhat1", "Kılıç", 22));
            al.Add(new Ogrenci("Serhat2", "Kılıç", 22));
            al.Add(new Ogrenci("Serhat3", "Kılıç", 22));// arrayliste atma işlemi
            al.Capacity = al.Count;//yazılmazsa 2x olarak tutabileceği oğe sayısı artar performansı düşürür.
          
            ViewBag.Capacity = al.Capacity;
            ViewBag.Count = al.Count;

            var ogr = new Ogrenci();
            ogr.Ad = "Berk"; ogr.Soyad = "Ozgul"; ogr.Yas = 25;

            var ogr1 = new Ogrenci("Şevval", "Karadeniz", 25);

            ViewData["Ogrenci"] = ogr1;
            ViewBag.ogretmen = ogr1;


            ViewData["test"] = id; //içine ne atarsan at gelir object tipinde bir koleksiyon olduğu için. Koleksiyonlarda key ve value çiftleri oluşur. Keylerin birbirinden farklı olması gerekir.
            
            ViewBag.deneme = 10;

            return View(ogr);

            //return "Ahmet Mehmet " + id;//gönderilen opsiyonel id yi yazdırdık. Ogrenci/OgrenciBilgi/5 gibi
        }

        public ViewResult OgrenciListele()
        {
            var lst = new List<Ogrenci>();
            lst.Add(new Ogrenci("Selam", "List", 0));
            lst.Add(new Ogrenci("bye bye", "List", 1));
            lst.Capacity = lst.Count;
            
            ViewBag.Capacity = lst.Capacity;
            ViewBag.Count = lst.Count;

            
            return View(lst);

            var obj = new Deneme<Test, int>(); //örnek generic yapılı nesne üretme şekli 
        }

        
        //Nesne türetilirken tipin belirlenmesinde kullanılan yapılara generic denir.
        // Class içinde belirlenen propertyler nesne türetilirken tip ne seçilirse ona dönüşür.
        class Deneme<T,U> where T : class //gönderilen parametrenin class olması şartı konuldu. Kısıtlayıcı kullanıldı
                          where U : struct  // Bu where ile yapılan kısıtlamaya Generic Constraints denir.
                       // where Z : new() buraki new() in işlemi sadec nesne üretilebilir classlar gönderilebilir demiş olduk.//Sealed classlardan nesne üretilmez.
        {       
            public T deger;
            public U deger1;
           

            public string Test(T data)
            {
                return data.ToString();
            }
        }

        class Test
        {
            public void Yazdir(string data)
            {
                Console.WriteLine(data);
            }
        }
    }
}
// Entitiy Framework çalışma sırası
//veriler alındıktıktan sonra modellenir dbset e atılır savechanges() methodu ile veritabanına atılır
// Kullanıcı --> Model-->DbSet--> Sacechanges()-->Db