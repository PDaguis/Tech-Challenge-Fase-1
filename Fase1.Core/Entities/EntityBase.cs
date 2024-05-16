using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase1.Core.Entities
{
    public abstract class EntityBase
    {
        public static DateTime CurrentBrazilianDateTime => TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
        public EntityBase()
        {
            CadastradoEm = CurrentBrazilianDateTime;
        }

        public int Id { get; set; }
        public DateTime CadastradoEm { get; }
    }
}
