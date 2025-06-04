namespace ComercialTDSDesk
{
    partial class FrmNivel
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
            txtId = new TextBox();
            txtNome = new TextBox();
            txtSigla = new TextBox();
            btnGravar = new Button();
            btnEditar = new Button();
            btnCancelar = new Button();
            dgvNiveis = new DataGridView();
            clnId = new DataGridViewTextBoxColumn();
            clnNome = new DataGridViewTextBoxColumn();
            clnSigla = new DataGridViewTextBoxColumn();
            lbNome = new Label();
            lbSigla = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvNiveis).BeginInit();
            SuspendLayout();
            // 
            // txtId
            // 
            txtId.Location = new Point(59, 37);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 0;
            txtId.TabStop = false;
            txtId.TextChanged += LimparTexto;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(59, 88);
            txtNome.Name = "txtNome";
            txtNome.ReadOnly = true;
            txtNome.Size = new Size(237, 23);
            txtNome.TabIndex = 1;
            txtNome.TextChanged += LimparTexto;
            // 
            // txtSigla
            // 
            txtSigla.Location = new Point(59, 139);
            txtSigla.Name = "txtSigla";
            txtSigla.ReadOnly = true;
            txtSigla.Size = new Size(100, 23);
            txtSigla.TabIndex = 2;
            txtSigla.TextChanged += LimparTexto;
            // 
            // btnGravar
            // 
            btnGravar.Location = new Point(59, 194);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 23);
            btnGravar.TabIndex = 3;
            btnGravar.Text = "&Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Enabled = false;
            btnEditar.Location = new Point(140, 194);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 4;
            btnEditar.Text = "&Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(221, 194);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "&Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // dgvNiveis
            // 
            dgvNiveis.AllowUserToAddRows = false;
            dgvNiveis.AllowUserToDeleteRows = false;
            dgvNiveis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNiveis.Columns.AddRange(new DataGridViewColumn[] { clnId, clnNome, clnSigla });
            dgvNiveis.Location = new Point(315, 37);
            dgvNiveis.Name = "dgvNiveis";
            dgvNiveis.ReadOnly = true;
            dgvNiveis.RowHeadersVisible = false;
            dgvNiveis.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNiveis.Size = new Size(280, 180);
            dgvNiveis.TabIndex = 6;
            dgvNiveis.CellDoubleClick += dgvNiveis_CellDoubleClick;
            // 
            // clnId
            // 
            clnId.Frozen = true;
            clnId.HeaderText = "ID";
            clnId.Name = "clnId";
            clnId.ReadOnly = true;
            clnId.Visible = false;
            // 
            // clnNome
            // 
            clnNome.Frozen = true;
            clnNome.HeaderText = "Nome";
            clnNome.Name = "clnNome";
            clnNome.ReadOnly = true;
            clnNome.Resizable = DataGridViewTriState.False;
            clnNome.Width = 177;
            // 
            // clnSigla
            // 
            clnSigla.Frozen = true;
            clnSigla.HeaderText = "Sigla";
            clnSigla.Name = "clnSigla";
            clnSigla.ReadOnly = true;
            clnSigla.Resizable = DataGridViewTriState.False;
            // 
            // lbNome
            // 
            lbNome.AutoSize = true;
            lbNome.Location = new Point(13, 91);
            lbNome.Name = "lbNome";
            lbNome.Size = new Size(40, 15);
            lbNome.TabIndex = 7;
            lbNome.Text = "Nome";
            // 
            // lbSigla
            // 
            lbSigla.AutoSize = true;
            lbSigla.Location = new Point(21, 142);
            lbSigla.Name = "lbSigla";
            lbSigla.Size = new Size(32, 15);
            lbSigla.TabIndex = 7;
            lbSigla.Text = "Sigla";
            // 
            // FrmNivel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(607, 244);
            Controls.Add(lbSigla);
            Controls.Add(lbNome);
            Controls.Add(dgvNiveis);
            Controls.Add(btnCancelar);
            Controls.Add(btnEditar);
            Controls.Add(btnGravar);
            Controls.Add(txtSigla);
            Controls.Add(txtNome);
            Controls.Add(txtId);
            Name = "FrmNivel";
            Text = "Cadastro de Nível";
            Load += FrmNivel_Load;
            ((System.ComponentModel.ISupportInitialize)dgvNiveis).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtId;
        private TextBox txtNome;
        private TextBox txtSigla;
        private Button btnGravar;
        private Button btnEditar;
        private Button btnCancelar;
        private DataGridView dgvNiveis;
        private Label lbNome;
        private Label lbSigla;
        private DataGridViewTextBoxColumn clnId;
        private DataGridViewTextBoxColumn clnNome;
        private DataGridViewTextBoxColumn clnSigla;
    }
}