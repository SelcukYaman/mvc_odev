using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcDenemeHello.Models
{
    public class Ogrenci
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "ogrenci ad gerekli")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "ogrenci soyad gerekli")]
        public string Soyad { get; set; }
        [Required(ErrorMessage = "ogrenci yas gerekli")]
        public int Yas { get; set; }

        public Ogrenci() { }

        public Ogrenci(string ad, string soyad, byte yas)
        {
            this.Ad = ad;
            this.Soyad = soyad;
            this.Yas = yas;
        }

    }
}
