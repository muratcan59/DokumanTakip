using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokumanTakip.Model
{
    public class Is : Base
    {
        [Required]
        [StringLength(40, ErrorMessage = "Ad 2-40 karakter uzunluğunda olmalıdır.", MinimumLength = 2)]
        public string IsAdi { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BildirimTarih { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CozumTarihi { get; set; }
        [Required]
        public string IsSahibi { get; set; }

    }
}
