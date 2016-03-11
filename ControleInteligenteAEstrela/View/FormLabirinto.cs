﻿using ControleInteligenteAEstrela.Properties;
using ControleInteligenteAEstrela.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        private void lerArquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

                }
                else if (btnFimAtivo)
                {
                    dataGridViewLabirinto.Rows[linhaCelulaSelecionadaAnteriorBtnFim].Cells[colunaCelulaSelecionadaAnteriorBtnFim].Style.BackColor = Color.White;
                    dataGridViewLabirinto.Rows[linhaCelulaSelecionada].Cells[colunaCelulaSelecionada].Style.BackColor = Color.Red;
                    linhaCelulaSelecionadaAnteriorBtnFim = linhaCelulaSelecionada;
                    colunaCelulaSelecionadaAnteriorBtnFim = colunaCelulaSelecionada;
                }
                else if (btnMuroAtivo)
                {
                    dataGridViewLabirinto.Rows[linhaCelulaSelecionada].Cells[colunaCelulaSelecionada].Style.BackColor = Color.Gray;
                }
                else if (btnLimparUmaCelulaAtivo)
                {
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
            if (btnFimAtivo)
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
        }

        private void MovimentoMouse(object sender, EventArgs e)
        {
            if (btnMuroAtivo)
            {
                Int32 selectedCellCount = dataGridViewLabirinto.GetCellCount(DataGridViewElementStates.Selected);
                for (int i = 0; i < selectedCellCount; i++)
                {
                    dataGridViewLabirinto.SelectedCells[i].Style.BackColor = Color.Gray;
                    dataGridViewLabirinto.SelectedCells[i].Style.BackColor = Color.Gray;
                }
            }
        }
        
    }
}
