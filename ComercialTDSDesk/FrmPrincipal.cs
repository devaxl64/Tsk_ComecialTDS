using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComercialTDSDesk
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            this.Hide();
            frmLogin.ShowDialog();
            if (Program.UsuarioLogado.Id > 0)
            {
                tsslUsuarioLogado.Text = $"{Program.UsuarioLogado.Nome} - {Program.UsuarioLogado.Nivel.Nome}";
            }
            this.Show();
        }

        private void ddbTrocarUsuario_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.btnCancelar.Text = "&Voltar";
            frmLogin.ShowDialog();
            tsslUsuarioLogado.Text = $"{Program.UsuarioLogado.Nome} - {Program.UsuarioLogado.Nivel.Nome}";
        }

        private void níveisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNivel frmNivel = new FrmNivel();
            frmNivel.MdiParent = this;
            frmNivel.Show();
        }
    }
}
