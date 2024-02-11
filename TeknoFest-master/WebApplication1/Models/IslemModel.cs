using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class IslemModel
    {
        public int Id { get; set; }

        public int UrunId { get; set; }

        [DisplayName("Toplam Gram")]
        public float ToplamGram { get; set; }


        [DisplayName("Toplam Fiyat")]
        public float ToplamFiyat { get; set; }


        [DisplayName("Toplam Koli")]
        public float ToplamKoli { get; set; }


        [DisplayName("Adet")]
        public float Adet { get; set; }
    }
}