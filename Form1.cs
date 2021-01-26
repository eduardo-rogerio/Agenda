using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Agenda
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private MySqlConnection objCnx = new MySqlConnection();
        private MySqlCommand objComd = new MySqlCommand();
        private MySqlDataReader objDados;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                objCnx.ConnectionString = "Server=localhost;Database=dbCapacitacao;User=root;Pwd=";
                objCnx.Open();
            }
            catch (Exception Erro)
            {
                MessageBox.Show("Erro==>" + Erro.Message, "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);

                throw;
            }
        }

        private void BtnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                string strSql = "Select * from tblAgenda Where agdid = " + TxtCodigo.Text;
                objComd.Connection = objCnx;
                objComd.CommandText = strSql;
                objDados = objComd.ExecuteReader();
                if (objDados.HasRows)
                {
                    MessageBox.Show("Código existente!!!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!objDados.IsClosed)
                {
                    objDados.Close();
                }

                strSql = "Insert into tblAgenda (agdid,agdnome,agdemail,agdtelefone,agdcpf)" +
                    "values(@agdid,@agdnome,@agdemail,@agdtelefone,@agdcpf)";

                objComd.Parameters.AddWithValue("@agdid", TxtCodigo.Text);
                objComd.Parameters.AddWithValue("@agdnome", TxtNome.Text);
                objComd.Parameters.AddWithValue("@agdemail", TxtEmail.Text);
                objComd.Parameters.AddWithValue("@agdtelefone", TxtTelefone.Text);
                objComd.Parameters.AddWithValue("@agdcpf", TxtCpf.Text);

                objComd.Connection = objCnx;
                objComd.CommandText = strSql;
                objComd.ExecuteNonQuery();

                MessageBox.Show("Registro incluido com sucesso!!!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //fecha o DataReader
                if (!objDados.IsClosed) { objDados.Close(); }
            }
            
            catch (Exception Erro)
            {
                MessageBox.Show("Erro==>" + Erro.Message, "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            
        }

        private void BtnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                string strSql = "Select * from tblAgenda Where agdid = " + TxtCodigo.Text;
                objComd.Connection = objCnx;
                objComd.CommandText = strSql;
                objDados = objComd.ExecuteReader();
                if (!objDados.HasRows)
                {
                    MessageBox.Show("Código inexistente!!!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtCodigo.Focus();
                }
                else
                {
                    if (!objDados.IsClosed) { objDados.Close(); }//fecha data reader
                    objComd.Parameters.Clear();
                

                strSql = "update tblAgenda set agdnome = @agdnome,agdemail = @agdemail,agdtelefone = @agdtelefone,agdcpf = @agdcpf where agdid = @agdid";

                objComd.Parameters.AddWithValue("@agdid", TxtCodigo.Text);
                objComd.Parameters.AddWithValue("@agdnome", TxtNome.Text);
                objComd.Parameters.AddWithValue("@agdemail", TxtEmail.Text);
                objComd.Parameters.AddWithValue("@agdtelefone", TxtTelefone.Text);
                objComd.Parameters.AddWithValue("@agdcpf", TxtCpf.Text);

                objComd.Connection = objCnx;
                objComd.CommandText = strSql;
                objComd.ExecuteNonQuery();

                MessageBox.Show("Registro Alterado com sucesso!!!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnLimpar_Click(sender,e);
                }
                //fecha o DataReader
                if (!objDados.IsClosed) { objDados.Close(); }
            }

            catch (Exception Erro)
            {
                MessageBox.Show("Erro==>" + Erro.Message, "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            TxtCodigo.Clear();
            TxtCpf.Clear();
            TxtEmail.Clear();
            TxtNome.Clear();
            TxtTelefone.Clear();

            TxtCodigo.Focus();

        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {

            try
            {
                string strSql = "Select * from tblAgenda Where agdid = " + TxtCodigo.Text;
                objComd.Connection = objCnx;
                objComd.CommandText = strSql;
                objDados = objComd.ExecuteReader();
                if (!objDados.HasRows)
                {
                    MessageBox.Show("Código inexistente!!!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtCodigo.Focus();
                }
                else
                {
                    if (!objDados.IsClosed) { objDados.Close(); }

                    if (MessageBox.Show("Deseja excluir","ADO.NET",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK) 
                    { 
                    strSql = "Delete from tblAgenda Where agdid = " + TxtCodigo.Text;

                    objComd.Connection = objCnx;
                    objComd.CommandText = strSql;
                    objComd.ExecuteNonQuery();

                    MessageBox.Show("Registro eliminado com sucesso!!!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnLimpar_Click(sender, e); 
                    }
                }
                //fecha o DataReader
                if (!objDados.IsClosed) { objDados.Close(); }
            }

            catch (Exception Erro)
            {
                MessageBox.Show("Erro==>" + Erro.Message, "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                string strSql = "Select * from tblAgenda Where agdid = " + TxtCodigo.Text;
                objComd.Connection = objCnx;
                objComd.CommandText = strSql;
                objDados = objComd.ExecuteReader();
                if (!objDados.HasRows)
                {
                    MessageBox.Show("Código inexistente!!!", "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtCodigo.Focus();
                }
                else
                {
                    objDados.Read();
                    TxtNome.Text = objDados["agdnome"].ToString();
                    TxtEmail.Text = objDados["agdemail"].ToString();
                    TxtTelefone.Text = objDados["agdtelefone"].ToString();
                    TxtCpf.Text = objDados["agdcpf"].ToString();
                }
                //fecha o DataReader
                if (!objDados.IsClosed) { objDados.Close(); }
            }

            catch (Exception Erro)
            {
                MessageBox.Show("Erro==>" + Erro.Message, "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void BtnListaDeDados_Click(object sender, EventArgs e)
        {
            FrmConsultarLista objTela = new FrmConsultarLista();
            objTela.ShowDialog();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            objCnx.Close();
            Application.Exit();
        }
    }
}
