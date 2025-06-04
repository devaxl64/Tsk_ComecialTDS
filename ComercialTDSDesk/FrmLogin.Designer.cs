namespace ComercialTDSDesk
{
    partial class FrmLogin
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
            txtEmail = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtSenha = new TextBox();
            btnEntrar = new Button();
            chkExibeSenha = new CheckBox();
            llExit = new LinkLabel();
            btnCancelar = new Button();
            btnInfo = new Button();
            SuspendLayout();
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(90, 125);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "E-mail";
            txtEmail.Size = new Size(245, 23);
            txtEmail.TabIndex = 0;
            txtEmail.Text = "marcell@tdsq.com";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(149, 32);
            label1.Name = "label1";
            label1.Size = new Size(143, 15);
            label1.TabIndex = 1;
            label1.Text = "COMERCIAL TDS SYSTEM";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(168, 95);
            label2.Name = "label2";
            label2.Size = new Size(104, 15);
            label2.TabIndex = 1;
            label2.Text = "Acesso ao Sistema";
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(90, 189);
            txtSenha.Name = "txtSenha";
            txtSenha.PlaceholderText = "Senha";
            txtSenha.Size = new Size(245, 23);
            txtSenha.TabIndex = 1;
            txtSenha.Text = "1234";
            txtSenha.UseSystemPasswordChar = true;
            // 
            // btnEntrar
            // 
            btnEntrar.Location = new Point(108, 242);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(75, 23);
            btnEntrar.TabIndex = 2;
            btnEntrar.Text = "&Entrar";
            btnEntrar.UseVisualStyleBackColor = true;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // chkExibeSenha
            // 
            chkExibeSenha.AutoSize = true;
            chkExibeSenha.Location = new Point(341, 191);
            chkExibeSenha.Name = "chkExibeSenha";
            chkExibeSenha.Size = new Size(89, 19);
            chkExibeSenha.TabIndex = 4;
            chkExibeSenha.Text = "Exibir Senha";
            chkExibeSenha.UseVisualStyleBackColor = true;
            // 
            // llExit
            // 
            llExit.AutoSize = true;
            llExit.LinkArea = new LinkArea(2, 2);
            llExit.LinkBehavior = LinkBehavior.HoverUnderline;
            llExit.LinkColor = Color.Black;
            llExit.LinkVisited = true;
            llExit.Location = new Point(412, 9);
            llExit.Name = "llExit";
            llExit.Size = new Size(12, 21);
            llExit.TabIndex = 5;
            llExit.Text = "X";
            llExit.TextAlign = ContentAlignment.TopRight;
            llExit.UseCompatibleTextRendering = true;
            llExit.LinkClicked += linkLabel1_LinkClicked;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(229, 242);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnInfo
            // 
            btnInfo.Location = new Point(319, 246);
            btnInfo.Name = "btnInfo";
            btnInfo.Size = new Size(75, 23);
            btnInfo.TabIndex = 0;
            btnInfo.Text = "Info";
            btnInfo.UseVisualStyleBackColor = true;
            btnInfo.Click += btnInfo_Click;
            // 
            // FrmLogin
            // 
            AcceptButton = btnEntrar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = llExit;
            ClientSize = new Size(436, 358);
            ControlBox = false;
            Controls.Add(btnInfo);
            Controls.Add(btnCancelar);
            Controls.Add(llExit);
            Controls.Add(chkExibeSenha);
            Controls.Add(btnEntrar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtSenha);
            Controls.Add(txtEmail);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Load += FrmLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEmail;
        private Label label1;
        private Label label2;
        private TextBox txtSenha;
        private Button btnEntrar;
        private CheckBox chkExibeSenha;
        public LinkLabel llExit;
        public Button btnCancelar;
        private Button btnInfo;
    }
}