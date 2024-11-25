﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MosaicoSolutions.ViaCep;
using MySql.Data.MySqlClient;

namespace Cantina
{
    public partial class frmAlunos : Form
    {
        //Criando variáveis para controle do menu
        const int MF_BYCOMMAND = 0X400;
        [DllImport("user32")]
        static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32")]
        static extern int GetMenuItemCount(IntPtr hWnd);


        public frmAlunos()
        {
            InitializeComponent();
            //executando o método desabilitar campos
            desabilitarCampos();
        }
        public frmAlunos(string nome)
        {
            InitializeComponent();
            //executando o método desabilitar campos
            desabilitarCampos();
            txtNome.Text = nome;
            carregaAlunosNome(txtNome.Text);
        }

        private void frmAlunos_Load(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int MenuCount = GetMenuItemCount(hMenu) - 1;
            RemoveMenu(hMenu, MenuCount, MF_BYCOMMAND);
        }


        //criando método desabilitar campos
        public void desabilitarCampos()
        {
            txtCodigo1.Enabled = false;
            txtNome.Enabled = false;
            txtEndereco.Enabled = false;
            txtNumero.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtEmail.Enabled = false;
            mskCEP.Enabled = false;
            mskCPF.Enabled = false;
            mskTelefone1.Enabled = false;
            cbbEstado.Enabled = false;
            btnCadastrar.Enabled = false;
            btnExcluir.Enabled = false;
            btnAlterar.Enabled = false;
            btnLimpar.Enabled = false;
        }
        //criando método habilitar campos
        public void habilitarCampos()
        {
            txtNome.Enabled = true;
            txtEndereco.Enabled = true;
            txtNumero.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            txtEmail.Enabled = true;
            mskCEP.Enabled = true;
            mskCPF.Enabled = true;
            mskTelefone1.Enabled = true;
            cbbEstado.Enabled = true;
            btnCadastrar.Enabled = true;
            btnLimpar.Enabled = true;
        }

        //Método para limpar campos
        public void limparCampos()
        {
            txtCodigo1.Clear();
            txtEndereco.Clear();
            txtNome.Clear();
            txtEmail.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtNumero.Clear();
            mskCEP.Clear();
            mskCPF.Clear();
            mskTelefone1.Clear();
            cbbEstado.Text = "";
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnLimpar.Enabled = false;
            btnCadastrar.Enabled = false;
            btnNovo.Enabled = true;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal abrir = new frmMenuPrincipal();
            abrir.Show();
            this.Hide();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitarCampos();
            btnNovo.Enabled = false;
            txtNome.Focus();
        }

        //carregar funcionarios pelo nome
        public void carregaAlunosNome(string nome)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbAlunos where nome = @nome;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = nome;

            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;

            DR = comm.ExecuteReader();

            DR.Read();

            txtCodigo1.Text = DR.GetInt32(0).ToString();
            txtNome.Text = DR.GetString(1);
            txtEmail.Text = DR.GetString(2);
            mskCPF.Text = DR.GetString(3);
            mskTelefone1.Text = DR.GetString(4);
            mskCEP.Text = DR.GetString(5);
            txtEndereco.Text = DR.GetString(6);
            txtNumero.Text = DR.GetString(7);
            txtBairro.Text = DR.GetString(8);
            txtCidade.Text = DR.GetString(9);
            cbbEstado.Text = DR.GetString(10);

            Conexao.fecharConexao();
            habilitarCampos();
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
            btnLimpar.Enabled = true;
            btnNovo.Enabled = false;
            btnCadastrar.Enabled = false;
        }

        //cadastrar alunos
        public int cadastrarAlunos()
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "insert into tbAlunos(nome,email,cpf,telCelular,cep,endereco,numero,bairro,cidade,estado)values(@nome,@email,@cpf,@telCelular,@cep,@endereco,@numero,@bairro,@cidade,@estado);";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = txtNome.Text;
            comm.Parameters.Add("@email", MySqlDbType.VarChar, 100).Value = txtEmail.Text;
            comm.Parameters.Add("@cpf", MySqlDbType.VarChar, 14).Value = mskCPF.Text;
            comm.Parameters.Add("@telCelular", MySqlDbType.VarChar, 10).Value = mskTelefone1.Text;
            comm.Parameters.Add("@cep", MySqlDbType.VarChar, 9).Value = mskCEP.Text;
            comm.Parameters.Add("@endereco", MySqlDbType.VarChar, 100).Value = txtEndereco.Text;
            comm.Parameters.Add("@numero", MySqlDbType.VarChar, 10).Value = txtNumero.Text;
            comm.Parameters.Add("@bairro", MySqlDbType.VarChar, 100).Value = txtBairro.Text;
            comm.Parameters.Add("@cidade", MySqlDbType.VarChar, 100).Value = txtCidade.Text;
            comm.Parameters.Add("@estado", MySqlDbType.VarChar, 2).Value = cbbEstado.Text;

            comm.Connection = Conexao.obterConexao();

            int res = comm.ExecuteNonQuery();

            return res;

            Conexao.fecharConexao();
        }


        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Equals("") || txtEmail.Text.Equals("")
                || txtEndereco.Text.Equals("") || txtBairro.Text.Equals("")
                || txtCidade.Text.Equals("") || cbbEstado.Text.Equals("")
                || mskCPF.Text.Equals("   .   .   -")
                || mskTelefone1.Text.Equals("     -") || mskCEP.Text.Equals("     -") || txtNumero.Text.Equals(""))
            {
                MessageBox.Show("Não deixar campos vazios.");

            }
            else
            {
                if (cadastrarAlunos() == 1)
                {
                    MessageBox.Show("Cadastrado com sucesso!!!");
                    desabilitarCampos();
                    limparCampos();
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar!!!");
                }


            }
        }

        //criando o método busca cep
        public void buscaCEP(string cep)
        {
            var viaCEPService = ViaCepService.Default();

            var endereco = viaCEPService.ObterEndereco(cep);

            txtEndereco.Text = endereco.Logradouro;
            txtBairro.Text = endereco.Bairro;
            txtCidade.Text = endereco.Localidade;
            cbbEstado.Text = endereco.UF;

        }
        private void mskCEP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //busca o cep
                buscaCEP(mskCEP.Text);
                txtNumero.Focus();

            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            frmPesquisar abrir = new frmPesquisar();
            abrir.Show();
        }

        //alterando funcionarios
        public int alterarAlunos(int codAlu)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "update tbAlunos set nome = @nome,email = @email,cpf = @cpf, telCelular = @telCelular,cep = @cep, endereco = @endereco, numero = @numero,bairro = @bairro, cidade = @cidade, estado = @estado where codFunc = @codFunc;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();

            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = txtNome.Text;
            comm.Parameters.Add("@email", MySqlDbType.VarChar, 100).Value = txtEmail.Text;
            comm.Parameters.Add("@cpf", MySqlDbType.VarChar, 14).Value = mskCPF.Text;
            comm.Parameters.Add("@telCelular", MySqlDbType.VarChar, 10).Value = mskTelefone1.Text;
            comm.Parameters.Add("@cep", MySqlDbType.VarChar, 9).Value = mskCEP.Text;
            comm.Parameters.Add("@endereco", MySqlDbType.VarChar, 100).Value = txtEndereco.Text;
            comm.Parameters.Add("@numero", MySqlDbType.VarChar, 10).Value = txtNumero.Text;
            comm.Parameters.Add("@bairro", MySqlDbType.VarChar, 100).Value = txtBairro.Text;
            comm.Parameters.Add("@cidade", MySqlDbType.VarChar, 100).Value = txtCidade.Text;
            comm.Parameters.Add("@estado", MySqlDbType.VarChar, 2).Value = cbbEstado.Text;
            comm.Parameters.Add("@codFunc", MySqlDbType.Int32, 11).Value = codAlu;

            comm.Connection = Conexao.obterConexao();

            int res = comm.ExecuteNonQuery();

            return res;

            Conexao.fecharConexao();
        }

        //criando alterar funcionarios
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (alterarAlunos(Convert.ToInt32(txtCodigo1.Text)) == 1)
            {
                MessageBox.Show("Funcionário alterado com sucesso!!!");

            }
            else
            {
                MessageBox.Show("Erro ao alterar!!!");
            }
        }
        //Excluindo funcionarios
        public int excluirAlunos(int codAlu)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "delete from tbAlunos where codAlu = @codAlu;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@codAlu", MySqlDbType.Int32, 11).Value = codAlu;

            comm.Connection = Conexao.obterConexao();

            int res = comm.ExecuteNonQuery();

            return res;

            Conexao.fecharConexao();
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja excluir?",
                "Sistema", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.OK)
            {
                //executar o método excluirFuncionarios
                excluirAlunos(Convert.ToInt32(txtCodigo1.Text));
            }
            else
            {
                txtNome.Focus();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
            desabilitarCampos();
        }

        private void btnNovo_Click_1(object sender, EventArgs e)
        {
             habilitarCampos();
            btnNovo.Enabled = false;
            txtNome.Focus();
        }

        private void btnCadastrar_Click_1(object sender, EventArgs e)
        {
            if (txtNome.Text.Equals("") || txtEmail.Text.Equals("")
                || txtEndereco.Text.Equals("") || txtBairro.Text.Equals("")
                || txtCidade.Text.Equals("") || cbbEstado.Text.Equals("")
                || mskCPF.Text.Equals("   .   .   -")
                || mskTelefone1.Text.Equals("     -") || mskCEP.Text.Equals("     -") || txtNumero.Text.Equals(""))
            {
                MessageBox.Show("Não deixar campos vazios.");

            }
            else
            {
                if (cadastrarAlunos() == 1)
                {
                    MessageBox.Show("Cadastrado com sucesso!!!");
                    desabilitarCampos();
                    limparCampos();
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar!!!");
                }
            }
        }
        private void btnAlterar_Click_1(object sender, EventArgs e)
        {
            if (alterarAlunos(Convert.ToInt32(txtCodigo1.Text)) == 1)
            {
                MessageBox.Show("Funcionário alterado com sucesso!!!");

            }
            else
            {
                MessageBox.Show("Erro ao alterar!!!");
            }
        }

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja excluir?",
                "Sistema", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.OK)
            {
                //executar o método excluirFuncionarios
                excluirAlunos(Convert.ToInt32(txtCodigo1.Text));
            }
            else
            {
                txtNome.Focus();
            }
        }

        private void btnPesquisar_Click_1(object sender, EventArgs e)
        {
            frmPesquisar abrir = new frmPesquisar();
            abrir.Show();
        }

        private void btnLimpar_Click_1(object sender, EventArgs e)
        {
            limparCampos();
            desabilitarCampos();
        }

        private void btnVoltar_Click_1(object sender, EventArgs e)
        {
            frmMenuPrincipal abrir = new frmMenuPrincipal();
            abrir.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}