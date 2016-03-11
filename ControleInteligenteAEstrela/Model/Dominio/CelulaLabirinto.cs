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
        private float gLinha;
        private int posicaoX;
        private int posicaoY;

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

        public float GLinha
        {
            get { return gLinha; }
            set { gLinha = value; }
        }

        public int PosicaoX
        {
            get { return posicaoX; }
            set { posicaoX = value; }
        }

        public int PosicaoY
        {
            get { return posicaoY; }
            set { posicaoY = value; }
        }

    }
}
