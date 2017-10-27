using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataPersis;
using utilitarios;

namespace Logica
{
    public class Lmedicinas
    {
        public void registromedicina(string medicina) 
        {
            DAOmedicina bases = new DAOmedicina();
            Umedicina datos = new Umedicina();
            datos.Medicina = medicina;
            bases.guardarmedicina(datos);
        }
    }
}
