using System;
using System.Collections.Generic;
using System.Drawing;
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
            listAbertos = new List<CelulaLabirinto>();
            listFechados = new List<CelulaLabirinto>();
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
            if (VerificaSeEhNoFinal())
            {
                MessageBox.Show("Chegou no ponto final!");
                //fornecer a solução de percorrer ospontos da listFechada
                ImprimirPontosDoInicioAoFim();
            }
            else
            {
                ExpandirNoAtual();
            }
        }

        private void ExpandirNoAtual()
        {
            int numeroLinhaModificado = 0, numeroColunaModificado = 0;
            bool temElementoEmUmaLista = false;
            //if (celulaFLinhaMin.PosicaoDaLinha == 0 || celulaFLinhaMin.PosicaoDaColuna == 0)
            //{
            //    if (celulaFLinhaMin.PosicaoDaColuna == 0)
            //    {

            //    }
            //    if (celulaFLinhaMin.PosicaoDaLinha == 0)
            //    {

            //    }
            //}
            //else
            //{

            //}

            //para + 1 na coluna
            numeroColunaModificado = celulaFLinhaMin.PosicaoDaColuna + 1;
            if (numeroColunaModificado < 0 || numeroColunaModificado >= tabuleiroDoLabirinto.ColumnCount)
            {
                //Não adiciona nas listas
            }
            else
            {
                for (int i = 0; i < listAbertos.Count; i++)
                {
                    if (listAbertos[i].PosicaoDaColuna == numeroColunaModificado &&
                        listAbertos[i].PosicaoDaLinha == celulaFLinhaMin.PosicaoDaLinha)
                    {
                        temElementoEmUmaLista = true;
                        break;
                    }
                }
                for (int i = 0; i < listFechados.Count; i++)
                {
                    if (listFechados[i].PosicaoDaColuna == numeroColunaModificado &&
                        listFechados[i].PosicaoDaLinha == celulaFLinhaMin.PosicaoDaLinha)
                    {
                        temElementoEmUmaLista = true;
                        break;
                    }
                }
                if (!temElementoEmUmaLista)
                {
                    listAbertos.Add(celulaFLinhaMin);
                }
                else
                {
                    temElementoEmUmaLista = false;
                }
            }
        }

        private void ImprimirPontosDoInicioAoFim()
        {
            //concertar
            for (int i = 0; i < listFechados.Count; i++)
            {
                tabuleiroDoLabirinto.SelectedCells[i].Style.BackColor = Color.Gray;
            }
        }

        private bool VerificaSeEhNoFinal()
        {
            if (celulaFLinhaMin.NomeCelula == "No final")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
