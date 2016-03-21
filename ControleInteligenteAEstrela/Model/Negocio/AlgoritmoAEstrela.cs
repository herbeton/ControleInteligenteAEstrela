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
        private List<CelulaLabirinto> listaDoCaminhoPercorrido;
        private List<CelulaLabirinto> listaTemp;
        private DataGridView tabuleiroDoLabirinto;
        private CelulaLabirinto celulaFLinhaMin;
        private CelulaLabirinto celulaAtual;
        private CelulaLabirinto celulaTemp;
        private CelulaLabirinto celulaFinal;
        private CelulaLabirinto celulaInicial;
        private ControllerLabirinto controller;

        public AlgoritmoAEstrela(ControllerLabirinto controller)
        {
            celulaFLinhaMin = new CelulaLabirinto();
            celulaAtual = new CelulaLabirinto();
            celulaFinal = new CelulaLabirinto();
            celulaInicial = new CelulaLabirinto();
            listaAbertos = new List<CelulaLabirinto>();
            listaFechados = new List<CelulaLabirinto>();
            listaDoCaminhoPercorrido = new List<CelulaLabirinto>();
            listaTemp = new List<CelulaLabirinto>();
            this.controller = controller;
        }

        internal CelulaLabirinto CelulaInicial
        {
            get { return celulaInicial; }
            set { celulaInicial = value; }
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
            while (true)
            {
                celulaAtual = listaAbertos[0];
                if (VerificaSeEhNoFinal())
                {
                    listaFechados.Add(celulaAtual);
                    MessageBox.Show("Chegou no ponto final!");
                    //fornecer a solução de percorrer ospontos da listFechada
                    listaFechados.Sort((x, y) => x.FLinha.CompareTo(y.FLinha));
                    Task task = new Task(() => 
                    ImprimirPontosDoInicioAoFimDaListaFechada());
                    task.Start();
                    break;
                }
                else
                {
                    ExpandirNoAtual();
                }

                //remove o elemento com o indice da listaAbertos
                if (listaAbertos.Count != 0)
                {
                    listaAbertos.RemoveAt(0);
                }
                //adicionando na lista de fechados ou não
                if (listaFechados.Count == 0)
                {
                    if (celulaAtual.NomeCelula != "Celula de inicio")
                    {
                        listaFechados.Add(celulaAtual);
                    }
                }
                else
                {
                    AdicionarNaListaFechadaEVerificar();
                }

                //ordenação da lista do menor para o maior Flinha
                listaAbertos.Sort((x, y) => x.FLinha.CompareTo(y.FLinha));
            }
            MessageBox.Show("Acabouu!");
        }

        private void AdicionarNaListaFechadaEVerificar()
        {
            try
            {
                for (int i = 0; i < listaFechados.Count; i++)
                {
                    bool adicionouNaListaFechada = false;
                    if (listaFechados[i].PosicaoDoPaiColuna == celulaAtual.PosicaoDoPaiColuna && listaFechados[i].PosicaoDoPaiLinha == celulaAtual.PosicaoDoPaiLinha)
                    {
                        if (listaFechados[i].FLinha > celulaAtual.FLinha)
                        {
                            listaFechados[i] = celulaAtual;
                            adicionouNaListaFechada = true;
                        }
                    }
                    else if (!adicionouNaListaFechada)
                    {
                        listaFechados.Add(celulaAtual);
                    }
                }
            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show("Não encontrei o caminho!");
            }
        }

        private bool VericaCelulaVizinhaNaListaFechada(CelulaLabirinto celulaVizinhaAVerificar)
        {
            for (int i = 0; i < listaFechados.Count; i++)
            {
                if (listaFechados[i] == celulaVizinhaAVerificar)
                {
                    return true;
                }
            }
            return false;
        }

        private bool VericaCelulaVizinhaNaListaAberta(CelulaLabirinto celulaVizinhaAVerificar)
        {
            for (int i = 0; i < listaAbertos.Count; i++)
            {
                if (listaAbertos[i] == celulaVizinhaAVerificar)
                {
                    if (listaAbertos[i].FuncaoG > celulaVizinhaAVerificar.FuncaoG)
                    {
                        listaAbertos.RemoveAt(i);
                        return true;
                    }
                }
            }
            return false;
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
                if (!temElementoEmUmaLista && tabuleiroDoLabirinto.Rows[numeroLinhaModificado].Cells[numeroColunaModificado].Style.BackColor != Color.Gray)
                {
                    celulaTemp.PosicaoDoPaiColuna = celulaAtual.PosicaoDaColuna;
                    celulaTemp.PosicaoDoPaiLinha = celulaAtual.PosicaoDaLinha;
                    celulaTemp.PosicaoDaLinha = numeroLinhaModificado;
                    celulaTemp.PosicaoDaColuna = numeroColunaModificado;
                    celulaTemp.HLinha = HLinha(numeroLinhaModificado, numeroColunaModificado);
                    celulaTemp.FuncaoG = funcaoG(numeroLinhaModificado - celulaAtual.PosicaoDaLinha, numeroColunaModificado - celulaAtual.PosicaoDaColuna);
                    celulaTemp.FLinha = celulaTemp.HLinha + celulaTemp.FuncaoG;
                    if (!VericaCelulaVizinhaNaListaFechada(celulaTemp) && !VericaCelulaVizinhaNaListaAberta(celulaTemp))
                    {
                        listaAbertos.Add(celulaTemp);
                    }
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
                if (!temElementoEmUmaLista && tabuleiroDoLabirinto.Rows[numeroLinhaModificado].Cells[numeroColunaModificado].Style.BackColor != Color.Gray)
                {
                    celulaTemp.PosicaoDoPaiColuna = celulaAtual.PosicaoDaColuna;
                    celulaTemp.PosicaoDoPaiLinha = celulaAtual.PosicaoDaLinha;
                    celulaTemp.PosicaoDaColuna = numeroColunaModificado;
                    celulaTemp.PosicaoDaLinha = numeroLinhaModificado;
                    celulaTemp.HLinha = HLinha(numeroLinhaModificado, numeroColunaModificado);
                    celulaTemp.FuncaoG = funcaoG(numeroLinhaModificado - celulaAtual.PosicaoDaLinha, numeroColunaModificado - celulaAtual.PosicaoDaColuna);
                    celulaTemp.FLinha = celulaTemp.HLinha + celulaTemp.FuncaoG;
                    if (!VericaCelulaVizinhaNaListaFechada(celulaTemp) && !VericaCelulaVizinhaNaListaAberta(celulaTemp))
                    {
                        listaAbertos.Add(celulaTemp);
                    }
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
            if ((numeroLinhaModificado < 0 || numeroLinhaModificado >= tabuleiroDoLabirinto.RowCount) ||
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
                if (!temElementoEmUmaLista && tabuleiroDoLabirinto.Rows[numeroLinhaModificado].Cells[numeroColunaModificado].Style.BackColor != Color.Gray)
                {
                    celulaTemp.PosicaoDoPaiColuna = celulaAtual.PosicaoDaColuna;
                    celulaTemp.PosicaoDoPaiLinha = celulaAtual.PosicaoDaLinha;
                    celulaTemp.PosicaoDaLinha = numeroLinhaModificado;
                    celulaTemp.PosicaoDaColuna = numeroColunaModificado;
                    celulaTemp.HLinha = HLinha(numeroLinhaModificado, numeroColunaModificado);
                    celulaTemp.FuncaoG = funcaoG(numeroLinhaModificado - celulaAtual.PosicaoDaLinha, numeroColunaModificado - celulaAtual.PosicaoDaColuna);
                    celulaTemp.FLinha = celulaTemp.HLinha + celulaTemp.FuncaoG;
                    if (!VericaCelulaVizinhaNaListaFechada(celulaTemp) && !VericaCelulaVizinhaNaListaAberta(celulaTemp))
                    {
                        listaAbertos.Add(celulaTemp);
                    }
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
            if ((numeroLinhaModificado < 0 || numeroLinhaModificado >= tabuleiroDoLabirinto.RowCount) ||
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
                if (!temElementoEmUmaLista && tabuleiroDoLabirinto.Rows[numeroLinhaModificado].Cells[numeroColunaModificado].Style.BackColor != Color.Gray)
                {
                    celulaTemp.PosicaoDoPaiColuna = celulaAtual.PosicaoDaColuna;
                    celulaTemp.PosicaoDoPaiLinha = celulaAtual.PosicaoDaLinha;
                    celulaTemp.PosicaoDaLinha = numeroLinhaModificado;
                    celulaTemp.PosicaoDaColuna = numeroColunaModificado;
                    celulaTemp.HLinha = HLinha(numeroLinhaModificado, numeroColunaModificado);
                    celulaTemp.FuncaoG = funcaoG(numeroLinhaModificado - celulaAtual.PosicaoDaLinha, numeroColunaModificado - celulaAtual.PosicaoDaColuna);
                    celulaTemp.FLinha = celulaTemp.HLinha + celulaTemp.FuncaoG;
                    if (!VericaCelulaVizinhaNaListaFechada(celulaTemp) && !VericaCelulaVizinhaNaListaAberta(celulaTemp))
                    {
                        listaAbertos.Add(celulaTemp);
                    }
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
                if (!temElementoEmUmaLista && tabuleiroDoLabirinto.Rows[numeroLinhaModificado].Cells[numeroColunaModificado].Style.BackColor != Color.Gray)
                {
                    celulaTemp.PosicaoDoPaiColuna = celulaAtual.PosicaoDaColuna;
                    celulaTemp.PosicaoDoPaiLinha = celulaAtual.PosicaoDaLinha;
                    celulaTemp.PosicaoDaLinha = numeroLinhaModificado;
                    celulaTemp.PosicaoDaColuna = numeroColunaModificado;
                    celulaTemp.HLinha = HLinha(numeroLinhaModificado, numeroColunaModificado);
                    celulaTemp.FuncaoG = funcaoG(numeroLinhaModificado - celulaAtual.PosicaoDaLinha, numeroColunaModificado - celulaAtual.PosicaoDaColuna);
                    celulaTemp.FLinha = celulaTemp.HLinha + celulaTemp.FuncaoG;
                    if (!VericaCelulaVizinhaNaListaFechada(celulaTemp) && !VericaCelulaVizinhaNaListaAberta(celulaTemp))
                    {
                        listaAbertos.Add(celulaTemp);
                    }
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
                if (!temElementoEmUmaLista && tabuleiroDoLabirinto.Rows[numeroLinhaModificado].Cells[numeroColunaModificado].Style.BackColor != Color.Gray)
                {
                    celulaTemp.PosicaoDoPaiColuna = celulaAtual.PosicaoDaColuna;
                    celulaTemp.PosicaoDoPaiLinha = celulaAtual.PosicaoDaLinha;
                    celulaTemp.PosicaoDaColuna = numeroColunaModificado;
                    celulaTemp.PosicaoDaLinha = numeroLinhaModificado;
                    celulaTemp.HLinha = HLinha(numeroLinhaModificado, numeroColunaModificado);
                    celulaTemp.FuncaoG = funcaoG(numeroLinhaModificado - celulaAtual.PosicaoDaLinha, numeroColunaModificado - celulaAtual.PosicaoDaColuna);
                    celulaTemp.FLinha = celulaTemp.HLinha + celulaTemp.FuncaoG;
                    if (!VericaCelulaVizinhaNaListaFechada(celulaTemp) && !VericaCelulaVizinhaNaListaAberta(celulaTemp))
                    {
                        listaAbertos.Add(celulaTemp);
                    }
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
            if ((numeroLinhaModificado < 0 || numeroLinhaModificado >= tabuleiroDoLabirinto.RowCount) ||
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
                if (!temElementoEmUmaLista && tabuleiroDoLabirinto.Rows[numeroLinhaModificado].Cells[numeroColunaModificado].Style.BackColor != Color.Gray)
                {
                    celulaTemp.PosicaoDoPaiColuna = celulaAtual.PosicaoDaColuna;
                    celulaTemp.PosicaoDoPaiLinha = celulaAtual.PosicaoDaLinha;
                    celulaTemp.PosicaoDaLinha = numeroLinhaModificado;
                    celulaTemp.PosicaoDaColuna = numeroColunaModificado;
                    celulaTemp.HLinha = HLinha(numeroLinhaModificado, numeroColunaModificado);
                    celulaTemp.FuncaoG = funcaoG(numeroLinhaModificado - celulaAtual.PosicaoDaLinha, numeroColunaModificado - celulaAtual.PosicaoDaColuna);
                    celulaTemp.FLinha = celulaTemp.HLinha + celulaTemp.FuncaoG;
                    if (!VericaCelulaVizinhaNaListaFechada(celulaTemp) && !VericaCelulaVizinhaNaListaAberta(celulaTemp))
                    {
                        listaAbertos.Add(celulaTemp);
                    }
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
            if ((numeroLinhaModificado < 0 || numeroLinhaModificado >= tabuleiroDoLabirinto.RowCount) ||
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
                if (!temElementoEmUmaLista && tabuleiroDoLabirinto.Rows[numeroLinhaModificado].Cells[numeroColunaModificado].Style.BackColor != Color.Gray)
                {
                    celulaTemp.PosicaoDoPaiColuna = celulaAtual.PosicaoDaColuna;
                    celulaTemp.PosicaoDoPaiLinha = celulaAtual.PosicaoDaLinha;
                    celulaTemp.PosicaoDaLinha = numeroLinhaModificado;
                    celulaTemp.PosicaoDaColuna = numeroColunaModificado;
                    celulaTemp.HLinha = HLinha(numeroLinhaModificado, numeroColunaModificado);
                    celulaTemp.FuncaoG = funcaoG(numeroLinhaModificado - celulaAtual.PosicaoDaLinha, numeroColunaModificado - celulaAtual.PosicaoDaColuna);
                    celulaTemp.FLinha = celulaTemp.HLinha + celulaTemp.FuncaoG;
                    if (!VericaCelulaVizinhaNaListaFechada(celulaTemp) && !VericaCelulaVizinhaNaListaAberta(celulaTemp))
                    {
                        listaAbertos.Add(celulaTemp);
                    }
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
                tabuleiroDoLabirinto.Rows[listaFechados[i].PosicaoDoPaiLinha].Cells[listaFechados[i].PosicaoDoPaiColuna].Style.BackColor = Color.Gold;
            }
            tabuleiroDoLabirinto.Rows[celulaInicial.PosicaoDaLinha].Cells[celulaInicial.PosicaoDaColuna].Style.BackColor = Color.Green;
            tabuleiroDoLabirinto.Rows[celulaFinal.PosicaoDaLinha].Cells[celulaFinal.PosicaoDaColuna].Style.BackColor = Color.Red;
        }

        private bool VerificaSeEhNoFinal()
        {
            if (celulaAtual.PosicaoDaColuna == celulaFinal.PosicaoDaColuna && celulaAtual.PosicaoDaLinha == celulaFinal.PosicaoDaLinha)
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
