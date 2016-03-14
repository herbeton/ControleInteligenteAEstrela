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
        private List<CelulaLabirinto> listaAbertos;
        private List<CelulaLabirinto> listaFechados;
        private DataGridView tabuleiroDoLabirinto;
        private CelulaLabirinto celulaFLinhaMin;
        private int indiceCelulaFLinhaMin;

        public AlgoritmoAEstrela()
        {
            celulaFLinhaMin = new CelulaLabirinto();
            listaAbertos = new List<CelulaLabirinto>();
            listaFechados = new List<CelulaLabirinto>();
        }

        public DataGridView TabuleiroDoLabirinto
        {
            get { return tabuleiroDoLabirinto; }
            set { tabuleiroDoLabirinto = value; }
        }

        internal List<CelulaLabirinto> ListAbertos
        {
            get { return listaAbertos; }
            set { listaAbertos = value; }
        }

        internal List<CelulaLabirinto> ListFechados
        {
            get { return listaFechados; }
            set { listaFechados = value; }
        }


        public void AplicaAlgoritmoAEstrela()
        {
            if (listaAbertos.Count == 0)
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
            for (int i = 0; i < listaAbertos.Count; i++)
            {
                if (listaAbertos[i].FLinha < celulaFLinhaMin.FLinha)
                {
                    celulaFLinhaMin = listaAbertos[i];
                    indiceCelulaFLinhaMin = i;
                }
            }
            //remove o elemento com o indice da listaAbertos
            listaAbertos.RemoveAt(indiceCelulaFLinhaMin);
            listaFechados.Add(celulaFLinhaMin);
            if (VerificaSeEhNoFinal())
            {
                MessageBox.Show("Chegou no ponto final!");
                //fornecer a solução de percorrer ospontos da listFechada
                ImprimirPontosDoInicioAoFimDaListaFechada();
            }
            else
            {
                ExpandirNoAtual();
            }
        }

        private void ExpandirNoAtual()
        {
            MaisUmNaColuna();
            MaisUmNaLinha();
            MaisUmaLinhaEColuna();
            MenosUmaLinhaEColuna();
            MenosUmNaColuna();
            MenosUmNaLinha();
            MenosUmaLinhaEMaisUmaColuna();
            MenosUmaColunaEMaisUmaLinha();
            
        }
        public void MaisUmNaColuna()
        {
            int numeroLinhaModificado = 0, numeroColunaModificado = 0;
            bool temElementoEmUmaLista = false;
            //para + 1 na coluna
            numeroColunaModificado = celulaFLinhaMin.PosicaoDaColuna + 1;
            if (numeroColunaModificado < 0 || numeroColunaModificado >= tabuleiroDoLabirinto.ColumnCount)
            {
                //Não adiciona nas listas
            }
            else
            {
                for (int i = 0; i < listaAbertos.Count; i++)
                {
                    if (listaAbertos[i].PosicaoDaColuna == numeroColunaModificado &&
                        listaAbertos[i].PosicaoDaLinha == celulaFLinhaMin.PosicaoDaLinha)
                    {
                        temElementoEmUmaLista = true;
                        break;
                    }
                }
                for (int i = 0; i < listaFechados.Count; i++)
                {
                    if (listaFechados[i].PosicaoDaColuna == numeroColunaModificado &&
                        listaFechados[i].PosicaoDaLinha == celulaFLinhaMin.PosicaoDaLinha)
                    {
                        temElementoEmUmaLista = true;
                        break;
                    }
                }
                if (!temElementoEmUmaLista)
                {
                    listaAbertos.Add(celulaFLinhaMin);
                }
                else
                {
                    temElementoEmUmaLista = false;
                }
            }
        }

        public void MaisUmNaLinha()
        {
            int numeroLinhaModificado = 0, numeroColunaModificado = 0;
            bool temElementoEmUmaLista = false;
            //para + 1 na linha
            numeroLinhaModificado = celulaFLinhaMin.PosicaoDaLinha + 1;
            if (numeroLinhaModificado < 0 || numeroLinhaModificado >= tabuleiroDoLabirinto.RowCount)
            {
                //Não adiciona nas listas
            }
            else
            {
                for (int i = 0; i < listaAbertos.Count; i++)
                {
                    if (listaAbertos[i].PosicaoDaColuna == celulaFLinhaMin.PosicaoDaColuna &&
                        listaAbertos[i].PosicaoDaLinha == numeroLinhaModificado)
                    {
                        temElementoEmUmaLista = true;
                        break;
                    }
                }
                for (int i = 0; i < listaFechados.Count; i++)
                {
                    if (listaFechados[i].PosicaoDaColuna == celulaFLinhaMin.PosicaoDaColuna &&
                        listaFechados[i].PosicaoDaLinha == numeroLinhaModificado)
                    {
                        temElementoEmUmaLista = true;
                        break;
                    }
                }
                if (!temElementoEmUmaLista)
                {
                    listaAbertos.Add(celulaFLinhaMin);
                }
                else
                {
                    temElementoEmUmaLista = false;
                }
            }
        }

        public void MaisUmaLinhaEColuna()
        {
            int numeroLinhaModificado = 0, numeroColunaModificado = 0;
            bool temElementoEmUmaLista = false;
            //para + 1 na coluna
            numeroLinhaModificado = celulaFLinhaMin.PosicaoDaLinha + 1;
            numeroColunaModificado = celulaFLinhaMin.PosicaoDaColuna + 1;
            if ((numeroLinhaModificado < 0 || numeroLinhaModificado >= tabuleiroDoLabirinto.RowCount) &&
                (numeroColunaModificado < 0 || numeroColunaModificado >= tabuleiroDoLabirinto.ColumnCount))
            {
                //Não adiciona nas listas
            }
            else
            {
                for (int i = 0; i < listaAbertos.Count; i++)
                {
                    if (listaAbertos[i].PosicaoDaColuna == numeroColunaModificado &&
                        listaAbertos[i].PosicaoDaLinha == numeroLinhaModificado)
                    {
                        temElementoEmUmaLista = true;
                        break;
                    }
                }
                for (int i = 0; i < listaFechados.Count; i++)
                {
                    if (listaFechados[i].PosicaoDaColuna == numeroColunaModificado &&
                        listaFechados[i].PosicaoDaLinha == numeroLinhaModificado)
                    {
                        temElementoEmUmaLista = true;
                        break;
                    }
                }
                if (!temElementoEmUmaLista)
                {
                    listaAbertos.Add(celulaFLinhaMin);
                }
                else
                {
                    temElementoEmUmaLista = false;
                }
            }
        }

        public void MenosUmaLinhaEColuna()
        {
            int numeroLinhaModificado = 0, numeroColunaModificado = 0;
            bool temElementoEmUmaLista = false;
            //para + 1 na coluna
            numeroLinhaModificado = celulaFLinhaMin.PosicaoDaLinha - 1;
            numeroColunaModificado = celulaFLinhaMin.PosicaoDaColuna - 1;
            if ((numeroLinhaModificado < 0 || numeroLinhaModificado >= tabuleiroDoLabirinto.RowCount) &&
                (numeroColunaModificado < 0 || numeroColunaModificado >= tabuleiroDoLabirinto.ColumnCount))
            {
                //Não adiciona nas listas
            }
            else
            {
                for (int i = 0; i < listaAbertos.Count; i++)
                {
                    if (listaAbertos[i].PosicaoDaColuna == numeroColunaModificado &&
                        listaAbertos[i].PosicaoDaLinha == numeroLinhaModificado)
                    {
                        temElementoEmUmaLista = true;
                        break;
                    }
                }
                for (int i = 0; i < listaFechados.Count; i++)
                {
                    if (listaFechados[i].PosicaoDaColuna == numeroColunaModificado &&
                        listaFechados[i].PosicaoDaLinha == numeroLinhaModificado)
                    {
                        temElementoEmUmaLista = true;
                        break;
                    }
                }
                if (!temElementoEmUmaLista)
                {
                    listaAbertos.Add(celulaFLinhaMin);
                }
                else
                {
                    temElementoEmUmaLista = false;
                }
            }
        }

        public void MenosUmNaColuna()
        {
            int numeroLinhaModificado = 0, numeroColunaModificado = 0;
            bool temElementoEmUmaLista = false;
            //para + 1 na coluna
            numeroColunaModificado = celulaFLinhaMin.PosicaoDaColuna - 1;
            if (numeroColunaModificado < 0 || numeroColunaModificado >= tabuleiroDoLabirinto.ColumnCount)
            {
                //Não adiciona nas listas
            }
            else
            {
                for (int i = 0; i < listaAbertos.Count; i++)
                {
                    if (listaAbertos[i].PosicaoDaColuna == numeroColunaModificado &&
                        listaAbertos[i].PosicaoDaLinha == celulaFLinhaMin.PosicaoDaLinha)
                    {
                        temElementoEmUmaLista = true;
                        break;
                    }
                }
                for (int i = 0; i < listaFechados.Count; i++)
                {
                    if (listaFechados[i].PosicaoDaColuna == numeroColunaModificado &&
                        listaFechados[i].PosicaoDaLinha == celulaFLinhaMin.PosicaoDaLinha)
                    {
                        temElementoEmUmaLista = true;
                        break;
                    }
                }
                if (!temElementoEmUmaLista)
                {
                    listaAbertos.Add(celulaFLinhaMin);
                }
                else
                {
                    temElementoEmUmaLista = false;
                }
            }
        }

        public void MenosUmNaLinha()
        {
            int numeroLinhaModificado = 0, numeroColunaModificado = 0;
            bool temElementoEmUmaLista = false;
            //para + 1 na linha
            numeroLinhaModificado = celulaFLinhaMin.PosicaoDaLinha - 1;
            if (numeroLinhaModificado < 0 || numeroLinhaModificado >= tabuleiroDoLabirinto.RowCount)
            {
                //Não adiciona nas listas
            }
            else
            {
                for (int i = 0; i < listaAbertos.Count; i++)
                {
                    if (listaAbertos[i].PosicaoDaColuna == celulaFLinhaMin.PosicaoDaColuna &&
                        listaAbertos[i].PosicaoDaLinha == numeroLinhaModificado)
                    {
                        temElementoEmUmaLista = true;
                        break;
                    }
                }
                for (int i = 0; i < listaFechados.Count; i++)
                {
                    if (listaFechados[i].PosicaoDaColuna == celulaFLinhaMin.PosicaoDaColuna &&
                        listaFechados[i].PosicaoDaLinha == numeroLinhaModificado)
                    {
                        temElementoEmUmaLista = true;
                        break;
                    }
                }
                if (!temElementoEmUmaLista)
                {
                    listaAbertos.Add(celulaFLinhaMin);
                }
                else
                {
                    temElementoEmUmaLista = false;
                }
            }
        }
        public void MenosUmaLinhaEMaisUmaColuna()
        {
            int numeroLinhaModificado = 0, numeroColunaModificado = 0;
            bool temElementoEmUmaLista = false;
            //para + 1 na coluna
            numeroLinhaModificado = celulaFLinhaMin.PosicaoDaLinha - 1;
            numeroColunaModificado = celulaFLinhaMin.PosicaoDaColuna + 1;
            if ((numeroLinhaModificado < 0 || numeroLinhaModificado >= tabuleiroDoLabirinto.RowCount) &&
                (numeroColunaModificado < 0 || numeroColunaModificado >= tabuleiroDoLabirinto.ColumnCount))
            {
                //Não adiciona nas listas
            }
            else
            {
                for (int i = 0; i < listaAbertos.Count; i++)
                {
                    if (listaAbertos[i].PosicaoDaColuna == numeroColunaModificado &&
                        listaAbertos[i].PosicaoDaLinha == numeroLinhaModificado)
                    {
                        temElementoEmUmaLista = true;
                        break;
                    }
                }
                for (int i = 0; i < listaFechados.Count; i++)
                {
                    if (listaFechados[i].PosicaoDaColuna == numeroColunaModificado &&
                        listaFechados[i].PosicaoDaLinha == numeroLinhaModificado)
                    {
                        temElementoEmUmaLista = true;
                        break;
                    }
                }
                if (!temElementoEmUmaLista)
                {
                    listaAbertos.Add(celulaFLinhaMin);
                }
                else
                {
                    temElementoEmUmaLista = false;
                }
            }
        }
        public void MenosUmaColunaEMaisUmaLinha()
        {
            int numeroLinhaModificado = 0, numeroColunaModificado = 0;
            bool temElementoEmUmaLista = false;
            //para + 1 na coluna
            numeroLinhaModificado = celulaFLinhaMin.PosicaoDaLinha + 1;
            numeroColunaModificado = celulaFLinhaMin.PosicaoDaColuna - 1;
            if ((numeroLinhaModificado < 0 || numeroLinhaModificado >= tabuleiroDoLabirinto.RowCount) &&
                (numeroColunaModificado < 0 || numeroColunaModificado >= tabuleiroDoLabirinto.ColumnCount))
            {
                //Não adiciona nas listas
            }
            else
            {
                for (int i = 0; i < listaAbertos.Count; i++)
                {
                    if (listaAbertos[i].PosicaoDaColuna == numeroColunaModificado &&
                        listaAbertos[i].PosicaoDaLinha == numeroLinhaModificado)
                    {
                        temElementoEmUmaLista = true;
                        break;
                    }
                }
                for (int i = 0; i < listaFechados.Count; i++)
                {
                    if (listaFechados[i].PosicaoDaColuna == numeroColunaModificado &&
                        listaFechados[i].PosicaoDaLinha == numeroLinhaModificado)
                    {
                        temElementoEmUmaLista = true;
                        break;
                    }
                }
                if (!temElementoEmUmaLista)
                {
                    listaAbertos.Add(celulaFLinhaMin);
                }
                else
                {
                    temElementoEmUmaLista = false;
                }
            }
        }

        private void ImprimirPontosDoInicioAoFimDaListaFechada()
        {
            for (int i = 0; i < listaFechados.Count; i++)
            {
                tabuleiroDoLabirinto.Rows[listaFechados[i].PosicaoDaLinha].Cells[listaFechados[i].PosicaoDaColuna].Style.BackColor = Color.Gray;
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
