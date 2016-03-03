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
        public FormLabirinto()
        {
            InitializeComponent();
            controllerLabirinto = new ControllerLabirinto();
            AdicionarColunasLinhas();
        }

        public FormLabirinto(ControllerLabirinto controllerLabirinto)
        {
            // TODO: Complete member initialization
            this.controllerLabirinto = controllerLabirinto;
        }

        private void lerArquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AdicionarColunasLinhas()
        {
            DataTable table = new DataTable();

            table.Columns.Add("");
            table.Columns.Add("");
            table.Rows.Add("Alex", 26);
            table.Rows.Add("Jim", 36);
            table.Rows.Add("Bob", 34);
            table.Rows.Add("Mike", 47);
            table.Rows.Add("", "");
            table.Rows.Add("", "");
            table.Rows.Add("", "");
            table.Rows.Add("", "");
            table.Rows.Add("Joe", 61);

            this.dataGridViewLabirinto.DataSource = table;
            dataGridViewLabirinto.ColumnHeadersVisible = false;
            dataGridViewLabirinto.AutoGenerateColumns = false;

        }

        private void AtivaVisibleFormInicial(object sender, FormClosedEventArgs e)
        {
            controllerLabirinto.GetFormInicial().Visible = true;
        }
    }
}
