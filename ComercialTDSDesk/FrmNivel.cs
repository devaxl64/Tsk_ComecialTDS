using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComercialTDSClass;
using static System.Windows.Forms.LinkLabel;
using static Mysqlx.Notice.Warning.Types;

namespace ComercialTDSDesk
{
    public partial class FrmNivel : Form
    {
        public FrmNivel()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (btnGravar.Text == "&Inserir")
            {
                Editar();
                btnGravar.Text = "&Gravar";
            }
            else
            {
                if (txtId.Text == string.Empty)
                {
                    if (txtNome.Text != string.Empty && txtSigla.Text != string.Empty)
                    {
                        Nivel nivel = new Nivel(txtNome.Text, txtSigla.Text);
                        nivel.Inserir();
                        if (nivel.Id > 0)
                        {
                            MessageBox.Show($"Nível cadastrado com sucesso!");
                            btnGravar.Enabled = false;
                            txtNome.ReadOnly = true;
                            txtSigla.ReadOnly = true;
                        }
                    }
                }
                else
                {
                    Nivel nivel = new Nivel(int.Parse(txtId.Text), txtNome.Text, txtSigla.Text);
                    if (nivel.Atualizar())
                    {
                        MessageBox.Show("Nível atualizado com sucesso!");
                        btnGravar.Enabled = false;
                        txtNome.ReadOnly = true;
                        txtSigla.ReadOnly = true;
                    }
                }
                CarregarGrid();
                LimpaControles();
            }
        }

        private void LimpaControles()
        {
            txtId.Clear();
            txtNome.Clear();
            txtSigla.Clear();
        }

        private void CarregarGrid()
        {
            var niveis = Nivel.ObterLista();
            int linha = 0;
            dgvNiveis.Rows.Clear();
            foreach (var nivel in niveis)
            {
                dgvNiveis.Rows.Add();
                dgvNiveis.Rows[linha].Cells[0].Value = nivel.Id;
                dgvNiveis.Rows[linha].Cells[1].Value = nivel.Nome;
                dgvNiveis.Rows[linha].Cells[2].Value = nivel.Sigla;
                linha++;
            }
            InserirNivel();
        }
        private void Editar()
        {
            txtNome.ReadOnly = false;
            txtSigla.ReadOnly = false;
            btnEditar.Enabled = false;
            btnGravar.Enabled = true;
        }
        

        private void LimparTexto(object sender, EventArgs e)
        {
            if (txtNome.ReadOnly == true || txtSigla.ReadOnly == true)
            {
                btnCancelar.Text = "&Cancelar";
            }
            else
            {
                if (txtNome.Text != string.Empty || txtSigla.Text != string.Empty)
                {
                    btnCancelar.Text = "&Limpar";
                }
                else
                {
                    btnCancelar.Text = "&Cancelar";
                }
            }
        }
        private void InserirNivel()
        {
            if (txtNome.ReadOnly == true || txtSigla.ReadOnly == true)
            {
                btnGravar.Text = "&Inserir";
            }
            else
            {
                btnGravar.Text = "&Gravar";
            }
        }
        private void FrmNivel_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }
        private void dgvNiveis_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // recuperando o índice da linha do grid
            int linha = dgvNiveis.CurrentRow.Index;
            // recuperando o id do nivel na coluna oculta, ID (0)
            int id = Convert.ToInt32(dgvNiveis.Rows[linha].Cells[0].Value);
            // obter o objeto nivel
            var nivel = Nivel.ObterPorId(id);

            txtId.Text = nivel.Id.ToString(); //txtId.Text = Convert.ToString(nivel.Id); // (a mesma coisa)
            txtNome.Text = nivel.Nome;
            txtSigla.Text = nivel.Sigla;
            txtNome.ReadOnly = true;
            txtSigla.ReadOnly = true;

            btnEditar.Enabled = true;


            //MessageBox.Show($"{nivel.Id}, {nivel.Nome}, {nivel.Sigla}");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (btnCancelar.Text == $"&Limpar")
            {
                LimpaControles();
                Editar();
                btnCancelar.Text = "&Cancelar";
            }
            else
            {
                this.Close();
            }
        }
    }
}
