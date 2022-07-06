namespace Ginasio
{
    partial class FormAlterarDadosFuncionario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAlterarDadosFuncionario));
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.dateTimePickerDataNascimento = new System.Windows.Forms.DateTimePicker();
            this.rdBtnMasculino = new System.Windows.Forms.RadioButton();
            this.rdBtnFemenino = new System.Windows.Forms.RadioButton();
            this.txtMorada = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.txtNif = new System.Windows.Forms.TextBox();
            this.txtUltNome = new System.Windows.Forms.TextBox();
            this.txtPrimNome = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTelefone = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblGenero = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNif = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDataNascimento = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNomeCliente = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(125, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 33);
            this.label1.TabIndex = 19;
            this.label1.Text = "Alterar dados Funcionario";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(597, 32);
            this.panel2.TabIndex = 18;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(562, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlterar.Location = new System.Drawing.Point(505, 235);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(80, 33);
            this.btnAlterar.TabIndex = 105;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVoltar.Location = new System.Drawing.Point(12, 235);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(80, 34);
            this.btnVoltar.TabIndex = 104;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // dateTimePickerDataNascimento
            // 
            this.dateTimePickerDataNascimento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateTimePickerDataNascimento.Location = new System.Drawing.Point(116, 163);
            this.dateTimePickerDataNascimento.Name = "dateTimePickerDataNascimento";
            this.dateTimePickerDataNascimento.Size = new System.Drawing.Size(160, 20);
            this.dateTimePickerDataNascimento.TabIndex = 148;
            // 
            // rdBtnMasculino
            // 
            this.rdBtnMasculino.AutoSize = true;
            this.rdBtnMasculino.Checked = true;
            this.rdBtnMasculino.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdBtnMasculino.Location = new System.Drawing.Point(397, 160);
            this.rdBtnMasculino.Name = "rdBtnMasculino";
            this.rdBtnMasculino.Size = new System.Drawing.Size(73, 17);
            this.rdBtnMasculino.TabIndex = 139;
            this.rdBtnMasculino.TabStop = true;
            this.rdBtnMasculino.Text = "Masculino";
            this.rdBtnMasculino.UseVisualStyleBackColor = true;
            // 
            // rdBtnFemenino
            // 
            this.rdBtnFemenino.AutoSize = true;
            this.rdBtnFemenino.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdBtnFemenino.Location = new System.Drawing.Point(476, 160);
            this.rdBtnFemenino.Name = "rdBtnFemenino";
            this.rdBtnFemenino.Size = new System.Drawing.Size(71, 17);
            this.rdBtnFemenino.TabIndex = 140;
            this.rdBtnFemenino.Text = "Femenino";
            this.rdBtnFemenino.UseVisualStyleBackColor = true;
            // 
            // txtMorada
            // 
            this.txtMorada.Location = new System.Drawing.Point(398, 94);
            this.txtMorada.Name = "txtMorada";
            this.txtMorada.Size = new System.Drawing.Size(160, 20);
            this.txtMorada.TabIndex = 134;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(396, 128);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(160, 20);
            this.txtEmail.TabIndex = 133;
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(397, 190);
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(160, 20);
            this.txtTelefone.TabIndex = 132;
            // 
            // txtNif
            // 
            this.txtNif.Location = new System.Drawing.Point(117, 194);
            this.txtNif.Name = "txtNif";
            this.txtNif.Size = new System.Drawing.Size(160, 20);
            this.txtNif.TabIndex = 131;
            // 
            // txtUltNome
            // 
            this.txtUltNome.Location = new System.Drawing.Point(117, 128);
            this.txtUltNome.Name = "txtUltNome";
            this.txtUltNome.Size = new System.Drawing.Size(160, 20);
            this.txtUltNome.TabIndex = 130;
            // 
            // txtPrimNome
            // 
            this.txtPrimNome.Location = new System.Drawing.Point(117, 94);
            this.txtPrimNome.Name = "txtPrimNome";
            this.txtPrimNome.Size = new System.Drawing.Size(160, 20);
            this.txtPrimNome.TabIndex = 128;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 126;
            this.label9.Text = "Primeiro Nome";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(114, 101);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(0, 13);
            this.lblID.TabIndex = 124;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(349, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 123;
            this.label8.Text = "Morada";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(393, 208);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(0, 13);
            this.lblEmail.TabIndex = 122;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(360, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 121;
            this.label7.Text = "Email";
            // 
            // lblTelefone
            // 
            this.lblTelefone.AutoSize = true;
            this.lblTelefone.Location = new System.Drawing.Point(393, 185);
            this.lblTelefone.Name = "lblTelefone";
            this.lblTelefone.Size = new System.Drawing.Size(0, 13);
            this.lblTelefone.TabIndex = 120;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(343, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 119;
            this.label6.Text = "Telefone";
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Location = new System.Drawing.Point(393, 163);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(0, 13);
            this.lblGenero.TabIndex = 117;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(350, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 116;
            this.label5.Text = "Género";
            // 
            // lblNif
            // 
            this.lblNif.AutoSize = true;
            this.lblNif.Location = new System.Drawing.Point(113, 210);
            this.lblNif.Name = "lblNif";
            this.lblNif.Size = new System.Drawing.Size(0, 13);
            this.lblNif.TabIndex = 114;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(88, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 111;
            this.label4.Text = "NIF";
            // 
            // lblDataNascimento
            // 
            this.lblDataNascimento.AutoSize = true;
            this.lblDataNascimento.Location = new System.Drawing.Point(114, 137);
            this.lblDataNascimento.Name = "lblDataNascimento";
            this.lblDataNascimento.Size = new System.Drawing.Size(0, 13);
            this.lblDataNascimento.TabIndex = 110;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 108;
            this.label3.Text = "Data Nascimento";
            // 
            // lblNomeCliente
            // 
            this.lblNomeCliente.AutoSize = true;
            this.lblNomeCliente.Location = new System.Drawing.Point(114, 114);
            this.lblNomeCliente.Name = "lblNomeCliente";
            this.lblNomeCliente.Size = new System.Drawing.Size(0, 13);
            this.lblNomeCliente.TabIndex = 107;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(47, 135);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 106;
            this.label10.Text = "Último nome";
            // 
            // FormAlterarDadosFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(597, 285);
            this.Controls.Add(this.dateTimePickerDataNascimento);
            this.Controls.Add(this.rdBtnMasculino);
            this.Controls.Add(this.rdBtnFemenino);
            this.Controls.Add(this.txtMorada);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.txtNif);
            this.Controls.Add(this.txtUltNome);
            this.Controls.Add(this.txtPrimNome);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblTelefone);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblGenero);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblNif);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblDataNascimento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblNomeCliente);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAlterarDadosFuncionario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAlterarDadosFuncionario";
            this.Load += new System.EventHandler(this.FormAlterarDadosFuncionario_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataNascimento;
        private System.Windows.Forms.RadioButton rdBtnMasculino;
        private System.Windows.Forms.RadioButton rdBtnFemenino;
        private System.Windows.Forms.TextBox txtMorada;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.TextBox txtNif;
        private System.Windows.Forms.TextBox txtUltNome;
        private System.Windows.Forms.TextBox txtPrimNome;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTelefone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblNif;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDataNascimento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNomeCliente;
        private System.Windows.Forms.Label label10;
    }
}