﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleInteligenteAEstrela.Model.Dominio
{
    public class AlgoritmoAEstrela
    {
        private List<CelulaLabirinto> listAbertos;
        private List<CelulaLabirinto> listFechados;
        private DataGridView tabuleiroDoLabirinto;
        private CelulaLabirinto noAbertoTemp;
        private CelulaLabirinto celulaFLinhaMin;
        private int indiceCelulaFLinhaMin;

        public AlgoritmoAEstrela()
        {
            celulaFLinhaMin = new CelulaLabirinto();
        }

        public DataGridView TabuleiroDoLabirinto
        {
            get { return tabuleiroDoLabirinto; }
            set { tabuleiroDoLabirinto = value; }
        }

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

        public void AplicaAlgoritmoAEstrela()
        {
            if (listAbertos.Count == 0)
            {
                MessageBox.Show("Erro, pois não existe elementos na lista de abertos!");
            }
            else
            {
                PegarMenorFLinhaListaAberta();

            }
        }

        private void PegarMenorFLinhaListaAberta()
        {
            celulaFLinhaMin.FLinha = 10000000000;
            for (int i = 0; i < listAbertos.Count; i++)
            {
                if (listAbertos[i].FLinha < celulaFLinhaMin.FLinha)
                {
                    celulaFLinhaMin = listAbertos[i];
                    indiceCelulaFLinhaMin = i;
                }
            }
            //remove o elemento com o indice da listaAbertos
            listAbertos.RemoveAt(indiceCelulaFLinhaMin);
            listFechados.Add(celulaFLinhaMin);
        }

    }
}
