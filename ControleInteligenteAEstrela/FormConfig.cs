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
    public partial class FormConfig : Form
    {
        string diretorioArquivoTxt = "";
        public FormConfig()
        {
            InitializeComponent();
        }

        private void adicionarArquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "txt files (*.txt)|*.txt";
            openFile.ShowDialog();
            diretorioArquivoTxt = openFile.FileName;
            LerArquivoTxt(diretorioArquivoTxt);
            //MessageBox.Show(diretorioArquivoTxt);
        }

        private void LerArquivoTxt(String diretorio)
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
                while(tamanhoLinhaInicial > i){
                    if (primeiraLinhaArquivo[i].ToString() != " " && tamanhoLinhaInicial != i + 1)
                    {
                        buffer = buffer + primeiraLinhaArquivo[i];
                    }
                    else{
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

        private void SetTextBoxs(List<string> bufferTexto)
        {
            textBoxNLinhas.Text = bufferTexto[0];
            textBoxNColunas.Text = bufferTexto[1];
            textBoxCustoHorizontal.Text = bufferTexto[2];
            textBoxCustoVertical.Text = bufferTexto[3];
            bufferTexto.Clear();
            textBoxCustoDiagonal.Text = CalculaCustoDiagonalAutomatico(Convert.ToInt32(textBoxCustoHorizontal.Text), 
                Convert.ToInt32(textBoxCustoVertical.Text));
        }

        private string CalculaCustoDiagonalAutomatico(int CH, int CV)
        {
            return Math.Sqrt(Math.Pow(CH, 2) + Math.Pow(CV, 2)).ToString();
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
