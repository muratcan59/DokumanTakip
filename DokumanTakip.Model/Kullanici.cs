using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokumanTakip.Model
{
    public class Kullanici : Base
    {
        public Kullanici()
        {
            this.Rolleri = new HashSet<Rol>();
        }
        [Required]
        [StringLength(25, ErrorMessage = "Ad 2-25 karakter uzunluğunda olmalıdır.", MinimumLength = 2)]
        public string Ad { get; set; }
        [Required]
        public string Soyad { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Sifre { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Telefon { get; set; }

        [JsonIgnore]
        public virtual ICollection<Rol> Rolleri { get; set; }
    }
}
