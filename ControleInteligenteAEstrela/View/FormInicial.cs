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

namespace ControleInteligenteAEstrela.View
{
    public partial class FormInicial : Form
    {
        public ControllerLabirinto controllerLabirinto;
        private string diretorioArquivoTxt;
        public FormInicial()
        {
            InitializeComponent();
            controllerLabirinto = new ControllerLabirinto();
            diretorioArquivoTxt = "";
        }
        public FormInicial(ControllerLabirinto controllerLabirinto)
        {
            InitializeComponent();
            this.controllerLabirinto = controllerLabirinto;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controllerLabirinto.SetFormConfig(new FormConfig(controllerLabirinto));
            controllerLabirinto.GetFormConfig().Show();
        }

        private void btnLabrinto_Click(object sender, EventArgs e)
        {
            controllerLabirinto.SetFormConfig(new FormLabirinto(controllerLabirinto));
            controllerLabirinto.GetFormLabirinto().Show();
        }

        private void carregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "txt files (*.txt)|*.txt";
            openFile.ShowDialog();
            diretorioArquivoTxt = openFile.FileName;
            LerArquivoTxtPrimeiraLinha(diretorioArquivoTxt);
            LerMatrizDoTxt(diretorioArquivoTxt);
        }

        private void LerArquivoTxtPrimeiraLinha(String diretorio)
        {
            try
            {
                StreamReader texto = new StreamReader(diretorio);
                string primeiraLinhaArquivo;
                List<string> bufferTexto = new List<string>();
                string buffer = "";
                int tamanhoLinhaInicial = 0;
                int i = 0;
                
                
                if ((primeiraLinhaArquivo = texto.ReadLine()) != null)
                {
                    tamanhoLinhaInicial = primeiraLinhaArquivo.Length;
                    while (tamanhoLinhaInicial > i)
                    {
                        if (primeiraLinhaArquivo[i].ToString() != " " && tamanhoLinhaInicial != i + 1)
                        {
                            buffer = buffer + primeiraLinhaArquivo[i];
                        }
                        else
                        {
                            if (tamanhoLinhaInicial == i + 1)
                            {
                                buffer = buffer + primeiraLinhaArquivo[i];
                                bufferTexto.Add(buffer);
                                buffer = "";
                            }
                            else
                            {
                                bufferTexto.Add(buffer);
                                buffer = "";
                            }
                        }
                        i++;
                    }
                } 
                SetTextBoxs(bufferTexto);
            }
            catch (ArgumentException) { }
        }

        private void LerMatrizDoTxt(string diretorio)
        {
            try
            {
                controllerLabirinto.SetlinhasDoArquivoTxt(System.IO.File.ReadAllLines(diretorio));
            }
            catch (ArgumentException) { }
        }

        private void SetTextBoxs(List<string> bufferTexto)
        {
            Properties.Settings.Default.NLinhas = bufferTexto[0];
            Properties.Settings.Default.NColunas = bufferTexto[1];
            Properties.Settings.Default.CustoHorizontal = bufferTexto[2];
            Properties.Settings.Default.CustoVertical = bufferTexto[3];
            bufferTexto.Clear();
            Properties.Settings.Default.CustoDiagonal = CalculaCustoDiagonalAutomatico(Convert.ToInt32(Properties.Settings.Default.CustoHorizontal),
                Convert.ToInt32(Properties.Settings.Default.CustoVertical));
        }
        private string CalculaCustoDiagonalAutomatico(int CH, int CV)
        {
            return Math.Sqrt(Math.Pow(CH, 2) + Math.Pow(CV, 2)).ToString();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
