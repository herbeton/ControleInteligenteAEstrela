using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleInteligenteAEstrela.View
{
    public partial class FormInicial : Form
    {
        public ControllerLabirinto controllerLabirinto;
        public FormInicial()
        {
            InitializeComponent();
            controllerLabirinto = new ControllerLabirinto();
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
            //this.Visible = false;
        }

        private void btnLabrinto_Click(object sender, EventArgs e)
        {
            controllerLabirinto.SetFormConfig(new FormLabirinto(controllerLabirinto));
            controllerLabirinto.GetFormLabirinto().Show();
            //this.Visible = false;
        }
    }
}
