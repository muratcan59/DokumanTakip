using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokumanTakip.Model
{
    public class Surec : Base
    {
        [Required]
        public string SurecAdi { get; set; }
        [Required]
        public string TakipNo { get; set; }
        [Required]
        public string GenelBilgi { get; set; }
        [Required]
        public int IsId { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime SonTamamlanmaTarih { get; set; }
        public virtual Is IsBilgisi { get; set; }

    }
}
