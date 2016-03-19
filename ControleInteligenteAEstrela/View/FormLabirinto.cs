using ControleInteligenteAEstrela.Model.Dominio;
using ControleInteligenteAEstrela.Properties;
using ControleInteligenteAEstrela.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleInteligenteAEstrela
{
    public partial class FormLabirinto : Form
    {
        private ControllerLabirinto controllerLabirinto;
        private FormInicial formInicial;
        private int numeroDeLinhas;
        private int numeroDeColunas;
        private bool recebeBoleana;
        private int linhaCelulaSelecionada;
        private int colunaCelulaSelecionada;
        private bool btnMuroAtivo;
        private bool btnInicioAtivo;
        private bool btnLimparUmaCelulaAtivo;
        private int linhaCelulaSelecionadaAnteriorBtnInicio;
        private int colunaCelulaSelecionadaAnteriorBtnInicio;
        private int linhaCelulaSelecionadaAnteriorBtnFim;
        private int colunaCelulaSelecionadaAnteriorBtnFim;
        private bool btnFimAtivo;
        private bool inicioInserido;
        private bool fimInserido;
        private CelulaLabirinto celulaInicialLabirinto;
        private CelulaLabirinto celulaFinalLabirinto;
        int numeroLinha;
        public FormLabirinto()
        {
            InitializeComponent();
            controllerLabirinto = new ControllerLabirinto();
            formInicial = new FormInicial(controllerLabirinto);
            AdicionarColunasLinhas();
            dataGridViewLabirinto.ColumnHeadersVisible = false;
            dataGridViewLabirinto.AutoGenerateColumns = false;
            dataGridViewLabirinto.RowHeadersVisible = false;//desabilita a barra lateral do dataGridView
            dataGridViewLabirinto.ReadOnly = true;
            btnMuroAtivo = false;
            btnInicioAtivo = false;
            btnFimAtivo = false;
            btnLimparUmaCelulaAtivo = false;
            inicioInserido = false;
            fimInserido = false;
            celulaFinalLabirinto = new CelulaLabirinto();
            numeroLinha = 0;
            AdicionaElementosDoArquivoTxt();
        }

        public FormLabirinto(ControllerLabirinto controllerLabirinto)
        {
            InitializeComponent();
            this.controllerLabirinto = controllerLabirinto;
            numeroDeLinhas = 0;
            AdicionarColunasLinhas();
            dataGridViewLabirinto.ColumnHeadersVisible = false;
            dataGridViewLabirinto.AutoGenerateColumns = false;
            dataGridViewLabirinto.RowHeadersVisible = false;//desabilita a barra lateral do dataGridView
            dataGridViewLabirinto.ReadOnly = true;
            btnMuroAtivo = false;
            btnInicioAtivo = false;
            btnFimAtivo = false;
            btnLimparUmaCelulaAtivo = false;
            inicioInserido = false;
            fimInserido = false;
            celulaFinalLabirinto = new CelulaLabirinto();
            numeroLinha = 0;
            AdicionaElementosDoArquivoTxt();
        }

        private void AdicionaElementosDoArquivoTxt()
        {
            //varia o número de linhas
            foreach (string line in controllerLabirinto.GetlinhasDoArquivoTxt())
            {
                if (numeroLinha != 0)
                {
                    //varia o número de colunas
                    for (int i = 0; i < line.Length; i++)
                    {
                        try
                        {
                            //adição de celula admissível no labirinto
                            //if (line[i].ToString() == "0")
                            //{
                            //    dataGridViewLabirinto.Rows[numeroLinha - 1].Cells[i].Style.BackColor = Color.White;
                            //    btnMuroAtivo = false;
                            //    btnInicioAtivo = false;
                            //    btnFimAtivo = false;
                            //    btnLimparUmaCelulaAtivo = false;
                            //}
                            //adição de mura no labirinto
                            if (line[i].ToString() == "1")
                            {
                                dataGridViewLabirinto.Rows[numeroLinha - 1].Cells[i].Style.BackColor = Color.Gray;
                                btnMuroAtivo = true;
                                btnInicioAtivo = false;
                                btnFimAtivo = false;
                                btnLimparUmaCelulaAtivo = false;
                            }
                            //adição da posição inicial no labirinto
                            else if (line[i].ToString() == "2")
                            {
                                dataGridViewLabirinto.Rows[numeroLinha - 1].Cells[i].Style.BackColor = Color.Green;
                                btnMuroAtivo = false;
                                btnInicioAtivo = true;
                                btnFimAtivo = false;
                                btnLimparUmaCelulaAtivo = false;
                            }
                            //adição da posição final no labirinto
                            else if (line[i].ToString() == "3")
                            {
                                dataGridViewLabirinto.Rows[numeroLinha - 1].Cells[i].Style.BackColor = Color.Red;
                                btnMuroAtivo = false;
                                btnInicioAtivo = false;
                                btnFimAtivo = true;
                                btnLimparUmaCelulaAtivo = false;
                            }
                        }
                        catch (ArgumentOutOfRangeException) { }
                    }
                }
                numeroLinha++;
            }
        }

        private void AdicionarColunasLinhas()
        {
            try
            {
                recebeBoleana = Int32.TryParse(Properties.Settings.Default.NLinhas, out numeroDeLinhas);
                recebeBoleana = Int32.TryParse(Properties.Settings.Default.NColunas, out numeroDeColunas);
                for (int i = 0; i < numeroDeColunas; i++)
                {
                    DataGridViewColumn column = new DataGridViewColumn();
                    DataGridViewCell cell = new DataGridViewTextBoxCell();
                    cell.Style.BackColor = Color.White;
                    column.CellTemplate = cell;
                    column.Width = 30;
                    column.Resizable = DataGridViewTriState.False;
                    dataGridViewLabirinto.Columns.Add(column);
                }

                for (int j = 0; j < numeroDeLinhas - 1; j++)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.Height = 30;
                    row.Resizable = DataGridViewTriState.False;
                    dataGridViewLabirinto.Rows.Add(row);
                }
                dataGridViewLabirinto.ClearSelection();

            }
            catch (ArgumentOutOfRangeException) { }
            catch (FormatException) { }

        }

        private void CelulaClicada(object sender, DataGridViewCellEventArgs e)
        {
                //MessageBox.Show("Row selected: " + dataGridViewLabirinto.CurrentCell.RowIndex.ToString());
                //MessageBox.Show("Column selected: " + dataGridViewLabirinto.CurrentCell.ColumnIndex.ToString());
                linhaCelulaSelecionada = dataGridViewLabirinto.CurrentCell.RowIndex;
                colunaCelulaSelecionada = dataGridViewLabirinto.CurrentCell.ColumnIndex;
                
                if (btnInicioAtivo)
                {
                    dataGridViewLabirinto.Rows[linhaCelulaSelecionadaAnteriorBtnInicio].Cells[colunaCelulaSelecionadaAnteriorBtnInicio].Style.BackColor = Color.White;
                    dataGridViewLabirinto.Rows[linhaCelulaSelecionada].Cells[colunaCelulaSelecionada].Style.BackColor = Color.Green;
                    linhaCelulaSelecionadaAnteriorBtnInicio = linhaCelulaSelecionada;
                    colunaCelulaSelecionadaAnteriorBtnInicio = colunaCelulaSelecionada;
                    inicioInserido = true;

                }
                else if (btnFimAtivo)
                {
                    dataGridViewLabirinto.Rows[linhaCelulaSelecionadaAnteriorBtnFim].Cells[colunaCelulaSelecionadaAnteriorBtnFim].Style.BackColor = Color.White;
                    dataGridViewLabirinto.Rows[linhaCelulaSelecionada].Cells[colunaCelulaSelecionada].Style.BackColor = Color.Red;
                    linhaCelulaSelecionadaAnteriorBtnFim = linhaCelulaSelecionada;
                    colunaCelulaSelecionadaAnteriorBtnFim = colunaCelulaSelecionada;
                    fimInserido = true;
                }
                else if (btnMuroAtivo)
                {
                    dataGridViewLabirinto.Rows[linhaCelulaSelecionada].Cells[colunaCelulaSelecionada].Style.BackColor = Color.Gray;
                }
                else if (btnLimparUmaCelulaAtivo)
                {
                    if (dataGridViewLabirinto.Rows[linhaCelulaSelecionada].Cells[colunaCelulaSelecionada].Style.BackColor == Color.Green)
                    {
                        inicioInserido = false;
                    }
                    else if (dataGridViewLabirinto.Rows[linhaCelulaSelecionada].Cells[colunaCelulaSelecionada].Style.BackColor == Color.Red)
                    {
                        fimInserido = false;
                    }
                    dataGridViewLabirinto.Rows[linhaCelulaSelecionada].Cells[colunaCelulaSelecionada].Style.BackColor = Color.White;
                }
        }

        private void btnMuro_Click(object sender, EventArgs e)
        {
            if (btnMuroAtivo)
            {
                btnMuroAtivo = false;
            }
            else
            {
                btnMuroAtivo = true; 
                btnInicioAtivo = false;
                btnFimAtivo = false;
                btnLimparUmaCelulaAtivo = false;
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (btnInicioAtivo)
            {
                btnInicioAtivo = false;
            }
            else
            {
                btnInicioAtivo = true;
                btnMuroAtivo = false;
                btnFimAtivo = false;
                btnLimparUmaCelulaAtivo = false;
                
            }
        }

        private void btnFim_Click(object sender, EventArgs e)
        {
            if (btnFimAtivo)
            {
                btnFimAtivo = false;
            }
            else
            {
                btnFimAtivo = true;
                btnMuroAtivo = false;
                btnInicioAtivo = false;
                btnLimparUmaCelulaAtivo = false;
            }
        }

        private void btnLimparUmaCelula_Click(object sender, EventArgs e)
        {
            if (btnLimparUmaCelulaAtivo)
            {
                btnLimparUmaCelulaAtivo = false;
            }
            else
            {
                btnLimparUmaCelulaAtivo = true;
                btnFimAtivo = false;
                btnMuroAtivo = false;
                btnInicioAtivo = false;
            }
        }

        private void btnLimparodoLabirinto_Click(object sender, EventArgs e)
        {
            dataGridViewLabirinto.Columns.Clear();
            AdicionarColunasLinhas();
            inicioInserido = false;
            fimInserido = false;
        }

        private void MovimentoMouse(object sender, EventArgs e)
        {
            if (btnMuroAtivo)
            {
                Int32 selectedCellCount = dataGridViewLabirinto.GetCellCount(DataGridViewElementStates.Selected);
                for (int i = 0; i < selectedCellCount; i++)
                {
                    dataGridViewLabirinto.SelectedCells[i].Style.BackColor = Color.Gray;
                    //dataGridViewLabirinto.SelectedCells[i].Style.BackColor = Color.Gray;
                }
            }
        }

        private void btnComecaoLabirinto_Click(object sender, EventArgs e)
        {
            if (inicioInserido && fimInserido)
            {
                if(inicioInserido){
                    controllerLabirinto.GetAlgoritmoAEstrela().ListAbertos.Clear();
                    controllerLabirinto.GetAlgoritmoAEstrela().ListFechados.Clear();
                    //celulaInicialLabirinto = new CelulaLabirinto(0, HLinha(linhaCelulaSelecionadaAnteriorBtnInicio, colunaCelulaSelecionadaAnteriorBtnInicio));
                    celulaInicialLabirinto = new CelulaLabirinto();
                    //setando os parametros referentes a celula inicial
                    celulaInicialLabirinto.NomeCelula = "Celula de inicio";
                    celulaInicialLabirinto.PosicaoDaLinha = linhaCelulaSelecionadaAnteriorBtnInicio;
                    celulaInicialLabirinto.PosicaoDaColuna = colunaCelulaSelecionadaAnteriorBtnInicio;
                    //setando os parametros referentes a celula final
                    celulaFinalLabirinto.NomeCelula = "Celula final";
                    celulaFinalLabirinto.PosicaoDaLinha = linhaCelulaSelecionadaAnteriorBtnFim;
                    celulaFinalLabirinto.PosicaoDaColuna = colunaCelulaSelecionadaAnteriorBtnFim;

                    controllerLabirinto.GetAlgoritmoAEstrela().CelulaInicial = celulaInicialLabirinto;
                    controllerLabirinto.GetAlgoritmoAEstrela().CelulaFinal = celulaFinalLabirinto;
                    controllerLabirinto.GetAlgoritmoAEstrela().ListAbertos.Add(celulaInicialLabirinto);
                    controllerLabirinto.GetAlgoritmoAEstrela().TabuleiroDoLabirinto = dataGridViewLabirinto;
                    controllerLabirinto.GetAlgoritmoAEstrela().AplicaAlgoritmoAEstrela();

                    SetandoBoleanasParaFalse();
                }
                else if (fimInserido)
                {

                }
            }
            else
            {
                MessageBox.Show("É necessário inserir o ponto de inicio e de fim para iniciar a varredura!");
            }
        }

        private void SetandoBoleanasParaFalse()
        {
            btnLimparUmaCelulaAtivo = false;
            btnFimAtivo = false;
            btnMuroAtivo = false;
            btnInicioAtivo = false;
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
    }
}
