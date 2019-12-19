using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DokumanTakip.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(25, ErrorMessage = "Ad 2-25 karakter uzunluğunda olmalıdır.", MinimumLength = 2)]
        public string Ad { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Soyad 2-25 karakter uzunluğunda olmalıdır.", MinimumLength = 2)]
        public string Soyad { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Sifre { get; set; }
        [Compare("Sifre")]
        [DataType(DataType.Password)]
        public string SifreTekrar { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Telefon { get; set; }

    }
}