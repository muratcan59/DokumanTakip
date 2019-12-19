using DokumanTakip.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokumanTakip.BII
{
    public class SurecRepository : BaseRepository<Surec>
    {
        public bool SoftDelete(int id)
        {
            var veri = context.Surecler.Find(id);
            veri.AktifMi = true;
            return base.Update(veri);
        }
    }
}
