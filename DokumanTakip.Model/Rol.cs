using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokumanTakip.Model
{
    public class Rol : Base
    {
        public Rol()
        {
            this.Kullanicilari = new HashSet<Kullanici>();
        }
        [Required]
        public string Ad { get; set; }
        //nav prop
        public virtual ICollection<Kullanici> Kullanicilari { get; set; }
    }
}
