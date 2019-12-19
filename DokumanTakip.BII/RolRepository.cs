using DokumanTakip.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokumanTakip.BII
{
    public class RolRepository : BaseRepository<Rol>
    {
        public List<Rol> GetRolesByUserId(int id)
        {
            return context.Set<Rol>().Where(x => x.Kullanicilari.Contains(new Kullanici { Id = id })).ToList();
        }
    }
}
