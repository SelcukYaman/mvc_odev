using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;

namespace MvcDenemeHello.Models
{
    public class okul
    {
        [Required(ErrorMessage = "ogrenci ad gerekli")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "ogrenci soyad gerekli")]
        public string Soyad { get; set; }
        [Required(ErrorMessage = "ogrenci yas gerekli")]
        public byte Yas { get; set; }
        public okul() { }
        public okul(string ad, string soyad, byte yas)
        {
            this.Ad = ad;
            this.Soyad = soyad;
            this.Yas = yas;
        }
       /* public okul(FormCollection f)
        {
            this.Ad = f["OgrenciAd"].ToString();
            this.Soyad = f["OgrenciSoyad"].ToString();
            this.Yas = byte.Parse(f["OgrenciYas"].ToString());
        }*/
    }
}
