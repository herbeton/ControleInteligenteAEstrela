namespace ControleInteligenteAEstrela
{
    partial class FormLabirinto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLabirinto));
            this.dataGridViewLabirinto = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lerArquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvarArquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.outrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnInicio = new System.Windows.Forms.Button();
            this.btnFim = new System.Windows.Forms.Button();
            this.btnMuro = new System.Windows.Forms.Button();
            this.btnComecaoLabirinto = new System.Windows.Forms.Button();
            this.btnLimparUmaCelula = new System.Windows.Forms.Button();
            this.btnLimparodoLabirinto = new System.Windows.Forms.Button();
            this.labelConfigLab = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLabirinto)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.flowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewLabirinto
            // 
            this.dataGridViewLabirinto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewLabirinto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLabirinto.Location = new System.Drawing.Point(12, 27);
            this.dataGridViewLabirinto.Name = "dataGridViewLabirinto";
            this.dataGridViewLabirinto.Size = new System.Drawing.Size(553, 364);
            this.dataGridViewLabirinto.TabIndex = 0;
            this.dataGridViewLabirinto.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CelulaClicada);
            this.dataGridViewLabirinto.MouseCaptureChanged += new System.EventHandler(this.MovimentoMouse);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.toolStripMenuItem1,
            this.outrosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(755, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lerArquivoToolStripMenuItem,
            this.salvarArquivoToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // lerArquivoToolStripMenuItem
            // 
            this.lerArquivoToolStripMenuItem.Name = "lerArquivoToolStripMenuItem";
            this.lerArquivoToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.lerArquivoToolStripMenuItem.Text = "Abrir";
            this.lerArquivoToolStripMenuItem.Click += new System.EventHandler(this.lerArquivoToolStripMenuItem_Click);
            // 
            // salvarArquivoToolStripMenuItem
            // 
            this.salvarArquivoToolStripMenuItem.Name = "salvarArquivoToolStripMenuItem";
            this.salvarArquivoToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.salvarArquivoToolStripMenuItem.Text = "Salvar";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(22, 20);
            this.toolStripMenuItem1.Text = "|";
            // 
            // outrosToolStripMenuItem
            // 
            this.outrosToolStripMenuItem.Name = "outrosToolStripMenuItem";
            this.outrosToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.outrosToolStripMenuItem.Text = "Outros";
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel.Controls.Add(this.btnInicio);
            this.flowLayoutPanel.Controls.Add(this.btnFim);
            this.flowLayoutPanel.Controls.Add(this.btnMuro);
            this.flowLayoutPanel.Controls.Add(this.btnComecaoLabirinto);
            this.flowLayoutPanel.Controls.Add(this.btnLimparUmaCelula);
            this.flowLayoutPanel.Controls.Add(this.btnLimparodoLabirinto);
            this.flowLayoutPanel.Location = new System.Drawing.Point(571, 54);
            this.flowLayoutPanel.MaximumSize = new System.Drawing.Size(172, 121);
            this.flowLayoutPanel.MinimumSize = new System.Drawing.Size(172, 121);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(172, 121);
            this.flowLayoutPanel.TabIndex = 2;
            // 
            // btnInicio
            // 
            this.btnInicio.Image = global::ControleInteligenteAEstrela.Properties.Resources.inicioLabirinto1;
            this.btnInicio.Location = new System.Drawing.Point(3, 3);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(49, 53);
            this.btnInicio.TabIndex = 0;
            this.btnInicio.UseVisualStyleBackColor = true;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // btnFim
            // 
            this.btnFim.Image = global::ControleInteligenteAEstrela.Properties.Resources.fimLabirinto1;
            this.btnFim.Location = new System.Drawing.Point(58, 3);
            this.btnFim.Name = "btnFim";
            this.btnFim.Size = new System.Drawing.Size(49, 53);
            this.btnFim.TabIndex = 2;
            this.btnFim.UseVisualStyleBackColor = true;
            this.btnFim.Click += new System.EventHandler(this.btnFim_Click);
            // 
            // btnMuro
            // 
            this.btnMuro.Image = global::ControleInteligenteAEstrela.Properties.Resources.muro20;
            this.btnMuro.Location = new System.Drawing.Point(113, 3);
            this.btnMuro.Name = "btnMuro";
            this.btnMuro.Size = new System.Drawing.Size(49, 53);
            this.btnMuro.TabIndex = 1;
            this.btnMuro.UseVisualStyleBackColor = true;
            this.btnMuro.Click += new System.EventHandler(this.btnMuro_Click);
            // 
            // btnComecaoLabirinto
            // 
            this.btnComecaoLabirinto.Location = new System.Drawing.Point(3, 62);
            this.btnComecaoLabirinto.Name = "btnComecaoLabirinto";
            this.btnComecaoLabirinto.Size = new System.Drawing.Size(78, 23);
            this.btnComecaoLabirinto.TabIndex = 3;
            this.btnComecaoLabirinto.Text = "Iniciar";
            this.btnComecaoLabirinto.UseVisualStyleBackColor = true;
            this.btnComecaoLabirinto.Click += new System.EventHandler(this.btnComecaoLabirinto_Click);
            // 
            // btnLimparUmaCelula
            // 
            this.btnLimparUmaCelula.Location = new System.Drawing.Point(87, 62);
            this.btnLimparUmaCelula.Name = "btnLimparUmaCelula";
            this.btnLimparUmaCelula.Size = new System.Drawing.Size(78, 23);
            this.btnLimparUmaCelula.TabIndex = 4;
            this.btnLimparUmaCelula.Text = "Limpar";
            this.btnLimparUmaCelula.UseVisualStyleBackColor = true;
            this.btnLimparUmaCelula.Click += new System.EventHandler(this.btnLimparUmaCelula_Click);
            // 
            // btnLimparodoLabirinto
            // 
            this.btnLimparodoLabirinto.Location = new System.Drawing.Point(3, 91);
            this.btnLimparodoLabirinto.Name = "btnLimparodoLabirinto";
            this.btnLimparodoLabirinto.Size = new System.Drawing.Size(162, 23);
            this.btnLimparodoLabirinto.TabIndex = 4;
            this.btnLimparodoLabirinto.Text = "Limpar todo labirinto";
            this.btnLimparodoLabirinto.UseVisualStyleBackColor = true;
            this.btnLimparodoLabirinto.Click += new System.EventHandler(this.btnLimparodoLabirinto_Click);
            // 
            // labelConfigLab
            // 
            this.labelConfigLab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelConfigLab.AutoSize = true;
            this.labelConfigLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConfigLab.Location = new System.Drawing.Point(575, 34);
            this.labelConfigLab.Name = "labelConfigLab";
            this.labelConfigLab.Size = new System.Drawing.Size(177, 17);
            this.labelConfigLab.TabIndex = 3;
            this.labelConfigLab.Text = "Configurações do labirinto:";
            // 
            // FormLabirinto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 403);
            this.Controls.Add(this.labelConfigLab);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.dataGridViewLabirinto);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormLabirinto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Labirinto";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLabirinto)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.flowLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewLabirinto;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lerArquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salvarArquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnMuro;
        private System.Windows.Forms.Button btnFim;
        private System.Windows.Forms.Label labelConfigLab;
        private System.Windows.Forms.Button btnComecaoLabirinto;
        private System.Windows.Forms.Button btnLimparUmaCelula;
        private System.Windows.Forms.Button btnLimparodoLabirinto;
    }
}

