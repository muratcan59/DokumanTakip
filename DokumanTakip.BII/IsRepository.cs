using DokumanTakip.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DokumanTakip.BII
{
    public class IsRepository : BaseRepository<Is>
    {
        public bool SoftDelete(int id)
        {
            var veri = context.Isler.Find(id);
            veri.AktifMi = true;
            return base.Update(veri);
        }       
    }
}
