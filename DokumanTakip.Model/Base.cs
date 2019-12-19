using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokumanTakip.Model
{
    public class Base
    {
        [Key]
        public int Id { get; set; }

        [DefaultValue("12-12-2012")]
        [DataType(DataType.DateTime)]
        public DateTime KayitTarihi { get; set; }

        [DefaultValue(false)]
        public bool AktifMi { get; set; }

    }
}
