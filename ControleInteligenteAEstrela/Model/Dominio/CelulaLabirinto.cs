using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleInteligenteAEstrela.Model.Dominio
{
    class CelulaLabirinto
    {
        private float hLinha;
        private float fLinha;
        private float funcaoG;
        private int posicaoDaLinha;
        private int posicaoDaColuna;
        private string nomeCelula;

        public CelulaLabirinto() { }

        public CelulaLabirinto(float funcaoG, float hLinha){
            this.funcaoG = funcaoG;
            this.hLinha = hLinha;
            this.fLinha = this.funcaoG + this.hLinha;
        }

        public string NomeCelula
        {
            get { return nomeCelula; }
            set { nomeCelula = value; }
        }

        public float HLinha
        {
            get { return hLinha; }
            set { hLinha = value; }
        }

        public float FLinha
        {
            get { return fLinha; }
            set { fLinha = value; }
        }

        public float FuncaoG
        {
            get { return funcaoG; }
            set { funcaoG = value; }
        }

        public int PosicaoDaLinha
        {
            get { return posicaoDaLinha; }
            set { posicaoDaLinha = value; }
        }

        public int PosicaoDaColuna
        {
            get { return posicaoDaColuna; }
            set { posicaoDaColuna = value; }
        }

    }
}
