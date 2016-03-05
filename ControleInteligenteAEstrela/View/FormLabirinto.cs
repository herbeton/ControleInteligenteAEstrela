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
                    cell.Style.BackColor = Color.LightSteelBlue;
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
    }
}
