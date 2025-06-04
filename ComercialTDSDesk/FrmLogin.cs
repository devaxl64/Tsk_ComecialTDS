using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComercialTDSClass;
using Microsoft.VisualBasic.Devices;

namespace ComercialTDSDesk
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Program.UsuarioLogado = Usuario.EfetuarLogin(txtEmail.Text, txtSenha.Text);
            this.Close();
        }

        public void btnCancelar_Click(object sender, EventArgs e)
        {
            if (btnCancelar.Text == "&Voltar")
                Close();
            else
                Application.Exit();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            var host = Environment.MachineName;
            var user = Environment.UserName;
            MessageBox.Show($"Nome do pc: {host} \nUsuario: {user}");
            // ver o ipv4:
            //var ip = NetworkInterface.GetAllNetworkInterfaces();
            //foreach (var item in ip)
            //{
            //    item.GetIPv4Statistics();
            //}
            foreach (var ip in Dns.GetHostEntry(Dns.GetHostName()).AddressList )
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    MessageBox.Show(ip.ToString());
                    break;
                }
            }
        }
    }
}
