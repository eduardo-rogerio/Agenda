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
    public partial class FrmConsultarLista : Form
    {
        private MySqlConnection objCnx = new MySqlConnection();
        private MySqlCommand objComd = new MySqlCommand();
        private MySqlDataReader objDados;
        public FrmConsultarLista()
        {
            InitializeComponent();
        }

        private void FrmConsultarLista_Load(object sender, EventArgs e)
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

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                string strSql = "Select * from tblAgenda order by agdnome";
                objComd.CommandText = strSql;
                objComd.Connection = objCnx;
                objDados = objComd.ExecuteReader();

                if (!objDados.HasRows)
                {
                    MessageBox.Show("Código Inexistente!!!", "Consultar Lista", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    while (objDados.Read())
                    {
                        dataGridView1.Rows.Add(objDados["agdid"].ToString(),
                                                objDados["agdnome"].ToString(),
                                                objDados["agdemail"].ToString(),
                                                objDados["agdtelefone"].ToString(),
                                                objDados["agdcpf"].ToString());
                    }
                    objDados.Close();
                }
            }
            catch (Exception Erro)
            {
                MessageBox.Show("Erro==>" + Erro.Message, "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            objCnx.Close();
            this.Close();

        }
    }
}
