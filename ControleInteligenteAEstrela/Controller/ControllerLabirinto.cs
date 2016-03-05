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
        FormConfig formConfig;
        FormLabirinto formLabirinto;
        FormInicial formInicial;
        public ControllerLabirinto(){
            
        }
        public void SetFormConfig(FormConfig formConfig)
        {
            this.formConfig = formConfig;
        }
        public FormConfig GetFormConfig()
        {
            return formConfig;
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
    }
}
