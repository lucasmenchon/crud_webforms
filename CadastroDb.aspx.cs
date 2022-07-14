using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace TVox
{
    public partial class CadastroDb : System.Web.UI.Page
    {
        string conexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conexaoSql;
        SqlCommand comandoSql;

        public void CDados()
        {
            if (Page.IsPostBack)
            {
                dbView.DataBind();
            }
        }

        public void LimpaDados()
        {
            txtNome.Text = "";
            txtIdade.Text = "";
            txtTelefone.Text = "";
            txtGen.SelectedValue = txtGen.Items[0].ToString();
            txtDataCad.Text = "";
            txtMsg.Text = "";

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtId.Text = dbView.SelectedRow.Cells[1].Text;
            txtNome.Text = dbView.SelectedRow.Cells[2].Text;
            txtIdade.Text = dbView.SelectedRow.Cells[3].Text;
            txtTelefone.Text = dbView.SelectedRow.Cells[4].Text;
            txtGen.Text = dbView.SelectedRow.Cells[5].Text;
            txtDataCad.Text = dbView.SelectedRow.Cells[6].Text;

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtNome.Text != "" && txtIdade.Text != "")
            {
                using(conexaoSql = new SqlConnection(conexao))
                {
                    comandoSql = new SqlCommand("INSERT INTO dbo.Contato (Nome, Idade, Telefone, Genero, DataCadastro) VALUES (@nome, @idade, @telefone, @genero, @datacad", conexaoSql);
                    comandoSql.Parameters.AddWithValue("@nome", txtNome.Text);
                    comandoSql.Parameters.AddWithValue("@idade", txtIdade.Text);
                    comandoSql.Parameters.AddWithValue("@telefone", txtTelefone.Text);
                    comandoSql.Parameters.AddWithValue("@genero", txtGen.Text);
                    comandoSql.Parameters.AddWithValue("@datacad", txtDataCad.Text);


                    comandoSql.Connection.Open();
                    comandoSql.ExecuteNonQuery();
                    conexaoSql.Close();
                    CDados();
                    LimpaDados();
                }
            }
            else
            {
                txtMsg.Text = "Preencha todos os campos.";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void btnDel_Click(object sender, EventArgs e)
        {

        }

        protected void btnCan_Click(object sender, EventArgs e)
        {

        }
    }
}