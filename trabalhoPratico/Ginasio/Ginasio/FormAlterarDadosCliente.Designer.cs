namespace Ginasio
{
    partial class FormAlterarDadosCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAlterarDadosCliente));
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rdBtnMasculino = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.rdBtnFemenino = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.datePickerDataNascimento = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMorada = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.txtNif = new System.Windows.Forms.TextBox();
            this.txtUltNome = new System.Windows.Forms.TextBox();
            this.txtPrimNome = new System.Windows.Forms.TextBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(116, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(292, 33);
            this.label2.TabIndex = 31;
            this.label2.Text = "Alterar Dados Cliente";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(487, 32);
            this.panel2.TabIndex = 30;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(450, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Primeiro Nome";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(269, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Ultimo Nome";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Data de Nascimento";
            // 
            // rdBtnMasculino
            // 
            this.rdBtnMasculino.AutoSize = true;
            this.rdBtnMasculino.Checked = true;
            this.rdBtnMasculino.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdBtnMasculino.Location = new System.Drawing.Point(146, 202);
            this.rdBtnMasculino.Name = "rdBtnMasculino";
            this.rdBtnMasculino.Size = new System.Drawing.Size(73, 17);
            this.rdBtnMasculino.TabIndex = 47;
            this.rdBtnMasculino.TabStop = true;
            this.rdBtnMasculino.Text = "Masculino";
            this.rdBtnMasculino.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(119, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "NIF";
            // 
            // rdBtnFemenino
            // 
            this.rdBtnFemenino.AutoSize = true;
            this.rdBtnFemenino.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdBtnFemenino.Location = new System.Drawing.Point(225, 202);
            this.rdBtnFemenino.Name = "rdBtnFemenino";
            this.rdBtnFemenino.Size = new System.Drawing.Size(71, 17);
            this.rdBtnFemenino.TabIndex = 48;
            this.rdBtnFemenino.Text = "Femenino";
            this.rdBtnFemenino.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(101, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Género";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(94, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Telefone";
            // 
            // datePickerDataNascimento
            // 
            this.datePickerDataNascimento.Location = new System.Drawing.Point(148, 143);
            this.datePickerDataNascimento.Name = "datePickerDataNascimento";
            this.datePickerDataNascimento.Size = new System.Drawing.Size(200, 20);
            this.datePickerDataNascimento.TabIndex = 46;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(111, 257);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "Email";
            // 
            // txtMorada
            // 
            this.txtMorada.Location = new System.Drawing.Point(145, 286);
            this.txtMorada.Name = "txtMorada";
            this.txtMorada.Size = new System.Drawing.Size(203, 20);
            this.txtMorada.TabIndex = 45;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(100, 286);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 39;
            this.label9.Text = "Morada";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(145, 257);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(203, 20);
            this.txtEmail.TabIndex = 44;
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(145, 225);
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(203, 20);
            this.txtTelefone.TabIndex = 43;
            // 
            // txtNif
            // 
            this.txtNif.Location = new System.Drawing.Point(148, 173);
            this.txtNif.Name = "txtNif";
            this.txtNif.Size = new System.Drawing.Size(100, 20);
            this.txtNif.TabIndex = 42;
            // 
            // txtUltNome
            // 
            this.txtUltNome.Location = new System.Drawing.Point(342, 111);
            this.txtUltNome.Name = "txtUltNome";
            this.txtUltNome.Size = new System.Drawing.Size(100, 20);
            this.txtUltNome.TabIndex = 41;
            // 
            // txtPrimNome
            // 
            this.txtPrimNome.Location = new System.Drawing.Point(148, 111);
            this.txtPrimNome.Name = "txtPrimNome";
            this.txtPrimNome.Size = new System.Drawing.Size(100, 20);
            this.txtPrimNome.TabIndex = 40;
            // 
            // btnVoltar
            // 
            this.btnVoltar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVoltar.Location = new System.Drawing.Point(12, 356);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(95, 40);
            this.btnVoltar.TabIndex = 49;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlterar.Location = new System.Drawing.Point(380, 356);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(95, 40);
            this.btnAlterar.TabIndex = 50;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // FormAlterarDadosCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(487, 410);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rdBtnMasculino);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rdBtnFemenino);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.datePickerDataNascimento);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtMorada);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.txtNif);
            this.Controls.Add(this.txtUltNome);
            this.Controls.Add(this.txtPrimNome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAlterarDadosCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAlterarDadosCliente";
            this.Load += new System.EventHandler(this.FormAlterarDadosCliente_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdBtnMasculino;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rdBtnFemenino;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker datePickerDataNascimento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMorada;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.TextBox txtNif;
        private System.Windows.Forms.TextBox txtUltNome;
        private System.Windows.Forms.TextBox txtPrimNome;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnAlterar;
    }
}