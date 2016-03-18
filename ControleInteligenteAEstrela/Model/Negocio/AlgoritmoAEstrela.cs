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
        private CelulaLabirinto celulaAtual;
        private CelulaLabirinto celulaTemp;
        private CelulaLabirinto celulaFinal;
        private int indiceCelulaFLinhaMin;
        private ControllerLabirinto controller;

        public AlgoritmoAEstrela(ControllerLabirinto controller)
        {
            celulaFLinhaMin = new CelulaLabirinto();
            celulaAtual = new CelulaLabirinto();
            celulaFinal = new CelulaLabirinto();
            listaAbertos = new List<CelulaLabirinto>();
            listaFechados = new List<CelulaLabirinto>();
            this.controller = controller;
        }

        internal CelulaLabirinto CelulaFinal
        {
            get { return celulaFinal; }
            set { celulaFinal = value; }
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
            //while (true)
            //{
                celulaAtual = listaAbertos[0];
                if (VerificaSeEhNoFinal())
                {
                    MessageBox.Show("Chegou no ponto final!");
                    //fornecer a solução de percorrer ospontos da listFechada
                    ImprimirPontosDoInicioAoFimDaListaFechada();
                    //break;
                }
                else
                {
                    ExpandirNoAtual();
                }

                //remove o elemento com o indice da listaAbertos
                listaAbertos.RemoveAt(0);
                listaFechados.Add(celulaAtual);

                
                celulaFLinhaMin.FLinha = 100;
                for (int i = 0; i < listaAbertos.Count; i++)
                {
                    if (listaAbertos[i].FLinha < celulaFLinhaMin.FLinha)
                    {
                        celulaFLinhaMin = listaAbertos[i];
                        indiceCelulaFLinhaMin = i;
                    }
                }
                
                
            //}
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
            celulaTemp = new CelulaLabirinto();
            //para + 1 na coluna
            numeroColunaModificado = celulaAtual.PosicaoDaColuna + 1;
            numeroLinhaModificado = celulaAtual.PosicaoDaLinha;
            if (numeroColunaModificado < 0 || numeroColunaModificado >= tabuleiroDoLabirinto.ColumnCount)
            {
                //Não adiciona nas listas
            }
            else
            {
                for (int i = 0; i < listaAbertos.Count; i++)
                {
                    if (listaAbertos[i].PosicaoDaColuna == numeroColunaModificado &&
                        listaAbertos[i].PosicaoDaLinha == celulaAtual.PosicaoDaLinha)
                    {
                        temElementoEmUmaLista = true;
                        break;
                    }
                }
                for (int i = 0; i < listaFechados.Count; i++)
                {
                    if (listaFechados[i].PosicaoDaColuna == numeroColunaModificado &&
                        listaFechados[i].PosicaoDaLinha == celulaAtual.PosicaoDaLinha)
                    {
                        temElementoEmUmaLista = true;
                        break;
                    }
                }
                if (!temElementoEmUmaLista)
                {
                    celulaTemp.PosicaoDoPaiColuna = celulaAtual.PosicaoDaColuna;
                    celulaTemp.PosicaoDoPaiLinha = celulaAtual.PosicaoDaLinha;
                    celulaTemp.PosicaoDaLinha = numeroLinhaModificado;
                    celulaTemp.PosicaoDaColuna = numeroColunaModificado;
                    celulaTemp.HLinha = HLinha(numeroLinhaModificado, numeroColunaModificado);
                    celulaTemp.FuncaoG = funcaoG(numeroLinhaModificado - celulaAtual.PosicaoDaLinha, numeroColunaModificado - celulaAtual.PosicaoDaColuna);
                    celulaTemp.FLinha = celulaTemp.HLinha + celulaTemp.FuncaoG;
                    listaAbertos.Add(celulaTemp);
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
            celulaTemp = new CelulaLabirinto();
            //para + 1 na linha
            numeroLinhaModificado = celulaAtual.PosicaoDaLinha + 1;
            numeroColunaModificado = celulaAtual.PosicaoDaColuna;
            if (numeroLinhaModificado < 0 || numeroLinhaModificado >= tabuleiroDoLabirinto.RowCount)
            {
                //Não adiciona nas listas
            }
            else
            {
                for (int i = 0; i < listaAbertos.Count; i++)
                {
                    if (listaAbertos[i].PosicaoDaColuna == celulaAtual.PosicaoDaColuna &&
                        listaAbertos[i].PosicaoDaLinha == numeroLinhaModificado)
                    {
                        temElementoEmUmaLista = true;
                        break;
                    }
                }
                for (int i = 0; i < listaFechados.Count; i++)
                {
                    if (listaFechados[i].PosicaoDaColuna == celulaAtual.PosicaoDaColuna &&
                        listaFechados[i].PosicaoDaLinha == numeroLinhaModificado)
                    {
                        temElementoEmUmaLista = true;
                        break;
                    }
                }
                if (!temElementoEmUmaLista)
                {
                    celulaTemp.PosicaoDoPaiColuna = celulaAtual.PosicaoDaColuna;
                    celulaTemp.PosicaoDoPaiLinha = celulaAtual.PosicaoDaLinha;
                    celulaTemp.PosicaoDaColuna = numeroColunaModificado;
                    celulaTemp.PosicaoDaLinha = numeroLinhaModificado;
                    celulaTemp.HLinha = HLinha(numeroLinhaModificado, numeroColunaModificado);
                    celulaTemp.FuncaoG = funcaoG(numeroLinhaModificado - celulaAtual.PosicaoDaLinha, numeroColunaModificado - celulaAtual.PosicaoDaColuna);
                    celulaTemp.FLinha = celulaTemp.HLinha + celulaTemp.FuncaoG;
                    listaAbertos.Add(celulaTemp);
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
            celulaTemp = new CelulaLabirinto();
            //para + 1 na coluna
            numeroLinhaModificado = celulaAtual.PosicaoDaLinha + 1;
            numeroColunaModificado = celulaAtual.PosicaoDaColuna + 1;
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
                    celulaTemp.PosicaoDoPaiColuna = celulaAtual.PosicaoDaColuna;
                    celulaTemp.PosicaoDoPaiLinha = celulaAtual.PosicaoDaLinha;
                    celulaTemp.PosicaoDaLinha = numeroLinhaModificado;
                    celulaTemp.PosicaoDaColuna = numeroColunaModificado;
                    celulaTemp.HLinha = HLinha(numeroLinhaModificado, numeroColunaModificado);
                    celulaTemp.FuncaoG = funcaoG(numeroLinhaModificado - celulaAtual.PosicaoDaLinha, numeroColunaModificado - celulaAtual.PosicaoDaColuna);
                    celulaTemp.FLinha = celulaTemp.HLinha + celulaTemp.FuncaoG;
                    listaAbertos.Add(celulaTemp);
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
            celulaTemp = new CelulaLabirinto();
            //para + 1 na coluna
            numeroLinhaModificado = celulaAtual.PosicaoDaLinha - 1;
            numeroColunaModificado = celulaAtual.PosicaoDaColuna - 1;
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
                    celulaTemp.PosicaoDoPaiColuna = celulaAtual.PosicaoDaColuna;
                    celulaTemp.PosicaoDoPaiLinha = celulaAtual.PosicaoDaLinha;
                    celulaTemp.PosicaoDaLinha = numeroLinhaModificado;
                    celulaTemp.PosicaoDaColuna = numeroColunaModificado;
                    celulaTemp.HLinha = HLinha(numeroLinhaModificado, numeroColunaModificado);
                    celulaTemp.FuncaoG = funcaoG(numeroLinhaModificado - celulaAtual.PosicaoDaLinha, numeroColunaModificado - celulaAtual.PosicaoDaColuna);
                    celulaTemp.FLinha = celulaTemp.HLinha + celulaTemp.FuncaoG;
                    listaAbertos.Add(celulaTemp);
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
            celulaTemp = new CelulaLabirinto();
            //para + 1 na coluna
            numeroColunaModificado = celulaAtual.PosicaoDaColuna - 1;
            numeroLinhaModificado = celulaAtual.PosicaoDaLinha;
            if (numeroColunaModificado < 0 || numeroColunaModificado >= tabuleiroDoLabirinto.ColumnCount)
            {
                //Não adiciona nas listas
            }
            else
            {
                for (int i = 0; i < listaAbertos.Count; i++)
                {
                    if (listaAbertos[i].PosicaoDaColuna == numeroColunaModificado &&
                        listaAbertos[i].PosicaoDaLinha == celulaAtual.PosicaoDaLinha)
                    {
                        temElementoEmUmaLista = true;
                        break;
                    }
                }
                for (int i = 0; i < listaFechados.Count; i++)
                {
                    if (listaFechados[i].PosicaoDaColuna == numeroColunaModificado &&
                        listaFechados[i].PosicaoDaLinha == celulaAtual.PosicaoDaLinha)
                    {
                        temElementoEmUmaLista = true;
                        break;
                    }
                }
                if (!temElementoEmUmaLista)
                {
                    celulaTemp.PosicaoDoPaiColuna = celulaAtual.PosicaoDaColuna;
                    celulaTemp.PosicaoDoPaiLinha = celulaAtual.PosicaoDaLinha;
                    celulaTemp.PosicaoDaLinha = numeroLinhaModificado;
                    celulaTemp.PosicaoDaColuna = numeroColunaModificado;
                    celulaTemp.HLinha = HLinha(numeroLinhaModificado, numeroColunaModificado);
                    celulaTemp.FuncaoG = funcaoG(numeroLinhaModificado - celulaAtual.PosicaoDaLinha, numeroColunaModificado - celulaAtual.PosicaoDaColuna);
                    celulaTemp.FLinha = celulaTemp.HLinha + celulaTemp.FuncaoG;
                    listaAbertos.Add(celulaTemp);
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
            celulaTemp = new CelulaLabirinto();
            //para + 1 na linha
            numeroLinhaModificado = celulaAtual.PosicaoDaLinha - 1;
            numeroColunaModificado = celulaAtual.PosicaoDaColuna;
            if (numeroLinhaModificado < 0 || numeroLinhaModificado >= tabuleiroDoLabirinto.RowCount)
            {
                //Não adiciona nas listas
            }
            else
            {
                for (int i = 0; i < listaAbertos.Count; i++)
                {
                    if (listaAbertos[i].PosicaoDaColuna == celulaAtual.PosicaoDaColuna &&
                        listaAbertos[i].PosicaoDaLinha == numeroLinhaModificado)
                    {
                        temElementoEmUmaLista = true;
                        break;
                    }
                }
                for (int i = 0; i < listaFechados.Count; i++)
                {
                    if (listaFechados[i].PosicaoDaColuna == celulaAtual.PosicaoDaColuna &&
                        listaFechados[i].PosicaoDaLinha == numeroLinhaModificado)
                    {
                        temElementoEmUmaLista = true;
                        break;
                    }
                }
                if (!temElementoEmUmaLista)
                {
                    celulaTemp.PosicaoDoPaiColuna = celulaAtual.PosicaoDaColuna;
                    celulaTemp.PosicaoDoPaiLinha = celulaAtual.PosicaoDaLinha;
                    celulaTemp.PosicaoDaColuna = numeroColunaModificado;
                    celulaTemp.PosicaoDaLinha = numeroLinhaModificado;
                    celulaTemp.HLinha = HLinha(numeroLinhaModificado, numeroColunaModificado);
                    celulaTemp.FuncaoG = funcaoG(numeroLinhaModificado - celulaAtual.PosicaoDaLinha, numeroColunaModificado - celulaAtual.PosicaoDaColuna);
                    celulaTemp.FLinha = celulaTemp.HLinha + celulaTemp.FuncaoG;
                    listaAbertos.Add(celulaTemp);
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
            celulaTemp = new CelulaLabirinto();
            //para + 1 na coluna
            numeroLinhaModificado = celulaAtual.PosicaoDaLinha - 1;
            numeroColunaModificado = celulaAtual.PosicaoDaColuna + 1;
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
                    celulaTemp.PosicaoDoPaiColuna = celulaAtual.PosicaoDaColuna;
                    celulaTemp.PosicaoDoPaiLinha = celulaAtual.PosicaoDaLinha;
                    celulaTemp.PosicaoDaLinha = numeroLinhaModificado;
                    celulaTemp.PosicaoDaColuna = numeroColunaModificado;
                    celulaTemp.HLinha = HLinha(numeroLinhaModificado, numeroColunaModificado);
                    celulaTemp.FuncaoG = funcaoG(numeroLinhaModificado - celulaAtual.PosicaoDaLinha, numeroColunaModificado - celulaAtual.PosicaoDaColuna);
                    celulaTemp.FLinha = celulaTemp.HLinha + celulaTemp.FuncaoG;
                    listaAbertos.Add(celulaTemp);
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
            celulaTemp = new CelulaLabirinto();
            //para + 1 na coluna
            numeroLinhaModificado = celulaAtual.PosicaoDaLinha + 1;
            numeroColunaModificado = celulaAtual.PosicaoDaColuna - 1;
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
                    celulaTemp.PosicaoDoPaiColuna = celulaAtual.PosicaoDaColuna;
                    celulaTemp.PosicaoDoPaiLinha = celulaAtual.PosicaoDaLinha;
                    celulaTemp.PosicaoDaLinha = numeroLinhaModificado;
                    celulaTemp.PosicaoDaColuna = numeroColunaModificado;
                    celulaTemp.HLinha = HLinha(numeroLinhaModificado, numeroColunaModificado);
                    celulaTemp.FuncaoG = funcaoG(numeroLinhaModificado - celulaAtual.PosicaoDaLinha, numeroColunaModificado - celulaAtual.PosicaoDaColuna);
                    celulaTemp.FLinha = celulaTemp.HLinha + celulaTemp.FuncaoG;
                    listaAbertos.Add(celulaTemp);
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
            if (celulaAtual.NomeCelula == "Celula final")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private float funcaoG(int diferencaLinha, int diferencaColuna)
        {
            if (diferencaLinha == 0 && diferencaColuna == 1 || diferencaLinha == 0 && diferencaColuna == -1)
            {
                return (float)Convert.ToDouble(Properties.Settings.Default.CustoHorizontal) + celulaAtual.FuncaoG;
            }
            else if (diferencaLinha == 1 && diferencaColuna == 0 || diferencaLinha == -1 && diferencaColuna == 0)
            {
                return (float)Convert.ToDouble(Properties.Settings.Default.CustoVertical) + celulaAtual.FuncaoG;
            }
            else if (diferencaLinha == 1 && diferencaColuna == 1 || diferencaLinha == 1 && diferencaColuna == -1 ||
                diferencaLinha == -1 && diferencaColuna == 1 || diferencaLinha == -1 && diferencaColuna == -1)
            {
                return (float)Convert.ToDouble(Properties.Settings.Default.CustoDiagonal) + celulaAtual.FuncaoG;
            }
            else {
                return 0;
            }
        }

        private float HLinha(int linha, int coluna)
        {
            int distLinha = Math.Abs(linha - celulaFinal.PosicaoDaLinha);
            int distColuna = Math.Abs(coluna - celulaFinal.PosicaoDaColuna);
            return (float)Math.Sqrt(Math.Pow(2, distLinha) + Math.Pow(2, distColuna));
        }

    }
}
