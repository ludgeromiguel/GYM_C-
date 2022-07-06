namespace Ginasio
{
    partial class FormConsultarAulasCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConsultarAulasCliente));
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.dgvAulas = new System.Windows.Forms.DataGridView();
            this.btnInscreverAula = new System.Windows.Forms.Button();
            this.btnDesinscreverAula = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAulas)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(288, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 33);
            this.label2.TabIndex = 31;
            this.label2.Text = "Consultar aulas";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 32);
            this.panel2.TabIndex = 30;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(765, -1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVoltar.Location = new System.Drawing.Point(16, 344);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(95, 40);
            this.btnVoltar.TabIndex = 37;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // dgvAulas
            // 
            this.dgvAulas.AllowUserToAddRows = false;
            this.dgvAulas.AllowUserToDeleteRows = false;
            this.dgvAulas.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvAulas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAulas.Location = new System.Drawing.Point(16, 93);
            this.dgvAulas.Name = "dgvAulas";
            this.dgvAulas.ReadOnly = true;
            this.dgvAulas.Size = new System.Drawing.Size(770, 150);
            this.dgvAulas.TabIndex = 35;
            // 
            // btnInscreverAula
            // 
            this.btnInscreverAula.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInscreverAula.Location = new System.Drawing.Point(16, 249);
            this.btnInscreverAula.Name = "btnInscreverAula";
            this.btnInscreverAula.Size = new System.Drawing.Size(95, 40);
            this.btnInscreverAula.TabIndex = 38;
            this.btnInscreverAula.Text = "Inscrever Aula";
            this.btnInscreverAula.UseVisualStyleBackColor = true;
            this.btnInscreverAula.Click += new System.EventHandler(this.btnInscreverAula_Click);
            // 
            // btnDesinscreverAula
            // 
            this.btnDesinscreverAula.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesinscreverAula.Location = new System.Drawing.Point(117, 249);
            this.btnDesinscreverAula.Name = "btnDesinscreverAula";
            this.btnDesinscreverAula.Size = new System.Drawing.Size(95, 40);
            this.btnDesinscreverAula.TabIndex = 39;
            this.btnDesinscreverAula.Text = "Desinscrever  Aula";
            this.btnDesinscreverAula.UseVisualStyleBackColor = true;
            this.btnDesinscreverAula.Click += new System.EventHandler(this.btnDesinscreverAula_Click);
            // 
            // FormConsultarAulasCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 396);
            this.Controls.Add(this.btnDesinscreverAula);
            this.Controls.Add(this.btnInscreverAula);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.dgvAulas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormConsultarAulasCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormConsultarAulas";
            this.Load += new System.EventHandler(this.FormConsultarAulasCkiente_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAulas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.DataGridView dgvAulas;
        private System.Windows.Forms.Button btnInscreverAula;
        private System.Windows.Forms.Button btnDesinscreverAula;
    }
}