namespace Ginasio {
    partial class FormMenuCliente {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenuCliente));
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnReclamacoes = new System.Windows.Forms.Button();
            this.btnAlterarSubscricao = new System.Windows.Forms.Button();
            this.btnTerminarSessao = new System.Windows.Forms.Button();
            this.btnConsultarExtras = new System.Windows.Forms.Button();
            this.btnConsultarAulas = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAlterarDados = new System.Windows.Forms.Button();
            this.btnAlterarPassword = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvExtras = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvAulas = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvPlanoNutricional = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtras)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAulas)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanoNutricional)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(782, 32);
            this.panel2.TabIndex = 18;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(747, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btnReclamacoes
            // 
            this.btnReclamacoes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReclamacoes.Location = new System.Drawing.Point(279, 104);
            this.btnReclamacoes.Name = "btnReclamacoes";
            this.btnReclamacoes.Size = new System.Drawing.Size(95, 40);
            this.btnReclamacoes.TabIndex = 25;
            this.btnReclamacoes.Text = "Reclamações";
            this.btnReclamacoes.UseVisualStyleBackColor = true;
            this.btnReclamacoes.Click += new System.EventHandler(this.btnReclamacoes_Click);
            // 
            // btnAlterarSubscricao
            // 
            this.btnAlterarSubscricao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlterarSubscricao.Location = new System.Drawing.Point(154, 104);
            this.btnAlterarSubscricao.Name = "btnAlterarSubscricao";
            this.btnAlterarSubscricao.Size = new System.Drawing.Size(95, 40);
            this.btnAlterarSubscricao.TabIndex = 24;
            this.btnAlterarSubscricao.Text = "Alterar Subscriçãos";
            this.btnAlterarSubscricao.UseVisualStyleBackColor = true;
            this.btnAlterarSubscricao.Click += new System.EventHandler(this.btnAlterarSubscricao_Click);
            // 
            // btnTerminarSessao
            // 
            this.btnTerminarSessao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTerminarSessao.Location = new System.Drawing.Point(21, 735);
            this.btnTerminarSessao.Name = "btnTerminarSessao";
            this.btnTerminarSessao.Size = new System.Drawing.Size(95, 40);
            this.btnTerminarSessao.TabIndex = 23;
            this.btnTerminarSessao.Text = "Terminar sessão";
            this.btnTerminarSessao.UseVisualStyleBackColor = true;
            this.btnTerminarSessao.Click += new System.EventHandler(this.btnTerminarSessao_Click);
            // 
            // btnConsultarExtras
            // 
            this.btnConsultarExtras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultarExtras.Location = new System.Drawing.Point(30, 104);
            this.btnConsultarExtras.Name = "btnConsultarExtras";
            this.btnConsultarExtras.Size = new System.Drawing.Size(95, 40);
            this.btnConsultarExtras.TabIndex = 22;
            this.btnConsultarExtras.Text = "Consultar Extras";
            this.btnConsultarExtras.UseVisualStyleBackColor = true;
            this.btnConsultarExtras.Click += new System.EventHandler(this.btnConsultarExtras_Click);
            // 
            // btnConsultarAulas
            // 
            this.btnConsultarAulas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultarAulas.Location = new System.Drawing.Point(405, 104);
            this.btnConsultarAulas.Name = "btnConsultarAulas";
            this.btnConsultarAulas.Size = new System.Drawing.Size(93, 40);
            this.btnConsultarAulas.TabIndex = 21;
            this.btnConsultarAulas.Text = "Consultar Aulas";
            this.btnConsultarAulas.UseVisualStyleBackColor = true;
            this.btnConsultarAulas.Click += new System.EventHandler(this.btnConsultarAulas_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(281, -40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 33);
            this.label1.TabIndex = 19;
            this.label1.Text = "Consultar Clientes";
            // 
            // btnAlterarDados
            // 
            this.btnAlterarDados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlterarDados.Location = new System.Drawing.Point(532, 104);
            this.btnAlterarDados.Name = "btnAlterarDados";
            this.btnAlterarDados.Size = new System.Drawing.Size(93, 40);
            this.btnAlterarDados.TabIndex = 27;
            this.btnAlterarDados.Text = "Alterar dados";
            this.btnAlterarDados.UseVisualStyleBackColor = true;
            this.btnAlterarDados.Click += new System.EventHandler(this.btnAlterarDados_Click);
            // 
            // btnAlterarPassword
            // 
            this.btnAlterarPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlterarPassword.Location = new System.Drawing.Point(660, 104);
            this.btnAlterarPassword.Name = "btnAlterarPassword";
            this.btnAlterarPassword.Size = new System.Drawing.Size(93, 40);
            this.btnAlterarPassword.TabIndex = 28;
            this.btnAlterarPassword.Text = "Alterar Password";
            this.btnAlterarPassword.UseVisualStyleBackColor = true;
            this.btnAlterarPassword.Click += new System.EventHandler(this.btnAlterarPassword_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(288, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 33);
            this.label2.TabIndex = 29;
            this.label2.Text = "Menu Cliente";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvExtras);
            this.groupBox1.Location = new System.Drawing.Point(11, 156);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(755, 187);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Extras";
            // 
            // dgvExtras
            // 
            this.dgvExtras.AllowUserToAddRows = false;
            this.dgvExtras.AllowUserToDeleteRows = false;
            this.dgvExtras.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvExtras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExtras.Location = new System.Drawing.Point(10, 13);
            this.dgvExtras.Name = "dgvExtras";
            this.dgvExtras.ReadOnly = true;
            this.dgvExtras.Size = new System.Drawing.Size(732, 168);
            this.dgvExtras.TabIndex = 33;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvAulas);
            this.groupBox2.Location = new System.Drawing.Point(11, 349);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(755, 187);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Aulas";
            // 
            // dgvAulas
            // 
            this.dgvAulas.AllowUserToAddRows = false;
            this.dgvAulas.AllowUserToDeleteRows = false;
            this.dgvAulas.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvAulas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAulas.Location = new System.Drawing.Point(10, 13);
            this.dgvAulas.Name = "dgvAulas";
            this.dgvAulas.ReadOnly = true;
            this.dgvAulas.Size = new System.Drawing.Size(732, 168);
            this.dgvAulas.TabIndex = 33;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvPlanoNutricional);
            this.groupBox3.Location = new System.Drawing.Point(11, 542);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(755, 187);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Plano Nutricional";
            // 
            // dgvPlanoNutricional
            // 
            this.dgvPlanoNutricional.AllowUserToAddRows = false;
            this.dgvPlanoNutricional.AllowUserToDeleteRows = false;
            this.dgvPlanoNutricional.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvPlanoNutricional.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanoNutricional.Location = new System.Drawing.Point(10, 13);
            this.dgvPlanoNutricional.Name = "dgvPlanoNutricional";
            this.dgvPlanoNutricional.ReadOnly = true;
            this.dgvPlanoNutricional.Size = new System.Drawing.Size(732, 168);
            this.dgvPlanoNutricional.TabIndex = 33;
            // 
            // FormMenuCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(782, 784);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAlterarPassword);
            this.Controls.Add(this.btnAlterarDados);
            this.Controls.Add(this.btnReclamacoes);
            this.Controls.Add(this.btnAlterarSubscricao);
            this.Controls.Add(this.btnTerminarSessao);
            this.Controls.Add(this.btnConsultarExtras);
            this.Controls.Add(this.btnConsultarAulas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMenuCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMenuCliente";
            this.Load += new System.EventHandler(this.FormMenuCliente_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtras)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAulas)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanoNutricional)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnReclamacoes;
        private System.Windows.Forms.Button btnAlterarSubscricao;
        private System.Windows.Forms.Button btnTerminarSessao;
        private System.Windows.Forms.Button btnConsultarExtras;
        private System.Windows.Forms.Button btnConsultarAulas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAlterarDados;
        private System.Windows.Forms.Button btnAlterarPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvExtras;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvAulas;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvPlanoNutricional;
    }
}