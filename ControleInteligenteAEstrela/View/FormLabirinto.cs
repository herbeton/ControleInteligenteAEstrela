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
        public FormLabirinto()
        {
            InitializeComponent();
            controllerLabirinto = new ControllerLabirinto();
            formInicial = new FormInicial(controllerLabirinto);
            AdicionarColunasLinhas();
            dataGridViewLabirinto.ColumnHeadersVisible = false;
            dataGridViewLabirinto.AutoGenerateColumns = false;
            dataGridViewLabirinto.RowHeadersVisible = false;//desabilita a barra lateral do dataGridView
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
                    dataGridViewLabirinto.Columns.Add(column);

                }

                int tamanho = dataGridViewLabirinto.Columns[0].Width;

                for (int j = 0; j < numeroDeLinhas; j++)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.Height = (int)tamanho;
                    dataGridViewLabirinto.Rows.Add(row);
                }
                dataGridViewLabirinto.ClearSelection();

            }
            catch (ArgumentOutOfRangeException) { }
            catch (FormatException) { }

        }

        private void AtivaVisibleFormInicial(object sender, FormClosedEventArgs e)
        {
            //controllerLabirinto.SetFormInicial(formInicial);
            //controllerLabirinto.GetFormInicial().Visible = true;
        }

        public bool pr { get; set; }

        public bool recebeBoleana { get; set; }
    }
}
