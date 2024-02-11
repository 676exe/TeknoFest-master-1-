using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UrunModel
    {
        [Key]
        public int Id { get; set; }


        [DisplayName("Ürün Adı")]
        public string Adi { get; set; }


        [DisplayName("Birim Gram")]
        public float BirimGram { get; set; }


        [DisplayName("Birim Fiyat")]
        public float BirimFiyat { get; set; }


        [DisplayName("Birim Koli")]
        public float BirimKoli { get; set; }


        [DisplayName("Fire")]
        public float Fire { get; set; }
    }
}