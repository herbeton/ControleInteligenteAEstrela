using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleInteligenteAEstrela.Model.Dominio
{
    public class AlgoritmoAEstrela
    {
        private List<CelulaLabirinto> listAbertos;
        private List<CelulaLabirinto> listFechados;

        internal List<CelulaLabirinto> ListAbertos
        {
            get { return listAbertos; }
            set { listAbertos = value; }
        }

        internal List<CelulaLabirinto> ListFechados
        {
            get { return listFechados; }
            set { listFechados = value; }
        }

        public AlgoritmoAEstrela()
        {
            listAbertos = new List<CelulaLabirinto>();
            listFechados = new List<CelulaLabirinto>();
        }

        //public 

    }
}
