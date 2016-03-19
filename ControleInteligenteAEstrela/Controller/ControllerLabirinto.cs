using ControleInteligenteAEstrela.Model.Dominio;
using ControleInteligenteAEstrela.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleInteligenteAEstrela
{
    public class ControllerLabirinto
    {
        private FormConfig formConfig;
        private FormLabirinto formLabirinto;
        private FormInicial formInicial;
        private AlgoritmoAEstrela algoritmoAEstrela;
        private string[] linhasDoArquivoTxt;

        public ControllerLabirinto(){
            algoritmoAEstrela = new AlgoritmoAEstrela(this);
        }
        public void SetFormConfig(FormConfig formConfig)
        {
            this.formConfig = formConfig;
        }
        public FormConfig GetFormConfig()
        {
            return formConfig;
        }

        public void SetlinhasDoArquivoTxt(string[] linhas)
        {
            this.linhasDoArquivoTxt = linhas;
        }

        public string[] GetlinhasDoArquivoTxt()
        {
            return this.linhasDoArquivoTxt;
        }

        public void SetFormConfig(FormLabirinto formLabirinto)
        {
            this.formLabirinto = formLabirinto;
        }
        public FormLabirinto GetFormLabirinto()
        {
            return formLabirinto;
        }
        public void SetFormInicial(FormInicial formInicial)
        {
            this.formInicial = formInicial;
        }
        public FormInicial GetFormInicial()
        {
            return formInicial;
        }

        public AlgoritmoAEstrela GetAlgoritmoAEstrela()
        {
            return algoritmoAEstrela;
        }

        public void SetAlgoritmoAEstrela(AlgoritmoAEstrela algoritmoAEstrela)
        {
            this.algoritmoAEstrela = algoritmoAEstrela;
        }
    }
}
