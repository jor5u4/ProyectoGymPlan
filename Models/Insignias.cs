using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGymPlan.Models
{

    public enum TipoInsignia {Logro,Verguenza }
    public class Insignias
    {
        public string Nombre { get; set; }
        public TipoInsignia TipoInsignia { get; set;}


    }
}
