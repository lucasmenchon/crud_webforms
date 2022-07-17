using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TVox
{
    public partial class CadastroBusca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDados();
            }
        }

        public void Limpar()
        {
            txtId.Text = "";
            txtNome.Text = "";
            txtIdade.Text = "";
            txtTel.Text = "";
            txtDtc.Text = "";
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=contatos_db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        protected void BtnInserir(object sender, EventArgs e) // '" + int.Parse(txtId.Text) + "',
        {
            conn.Open();
            SqlCommand comm = new SqlCommand("INSERT INTO Contato VALUES ('" + txtNome.Text + "','" + int.Parse(txtIdade.Text) + "','" + txtTel.Text + "','" + txtGen.SelectedValue + "','" +  txtDtc.Text + "')", conn); ;
            comm.ExecuteNonQuery();
            conn.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Sucesso no Cadastro.');", true);
            LoadDados();
            Limpar();
        }

        void LoadDados()
        {
            SqlCommand comm = new SqlCommand(" SELECT * FROM Contato", conn);
            SqlDataAdapter adap = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            Griddb.DataSource = dt;
            Griddb.DataBind();
        }

        protected void btnAtt(object sender, EventArgs e) //btnUpdateContact btnUpdate(X)
        {
            conn.Open();
            SqlCommand comm = new SqlCommand("UPDATE Contato SET Nome = '" + txtNome.Text + "', Idade = '" + int.Parse(txtIdade.Text) + "', Telefone = '" + txtTel.Text + "', Genero = '" + txtGen.SelectedValue + "', DataCadastro = '" + txtDtc.Text + "' WHERE Id = '" + int.Parse(txtId.Text) + "'", conn);
            comm.ExecuteNonQuery();
            conn.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Sucesso na Atualização.');", true);
            LoadDados();
            Limpar();
        }

        protected void btnDel(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand comm = new SqlCommand("DELETE Contato WHERE Id = '" + int.Parse(txtId.Text) + "'", conn);
            comm.ExecuteNonQuery();
            conn.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Sucesso Deletado.');", true);
            LoadDados();
            Limpar();
        }

        protected void btnBuscar(object sender, EventArgs e) //luc usar like
        {
            SqlCommand comm = new SqlCommand(" SELECT * FROM Contato WHERE Nome = '" + txtNomeBusca.Text + "'", conn);
            if (txtNomeBusca.Text == "")
            {
                LoadDados();
            }
            else
            {
                SqlDataAdapter adap = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                Griddb.DataSource = dt;
                Griddb.DataBind();
            }
        }
               

        protected void btnSelect(object sender, EventArgs e)
        {            
                txtId.Text = Griddb.SelectedRow.Cells[1].Text;
                txtNome.Text = Griddb.SelectedRow.Cells[2].Text;
                txtIdade.Text = Griddb.SelectedRow.Cells[3].Text;
                txtTel.Text = Griddb.SelectedRow.Cells[4].Text;
                txtGen.Text = Griddb.SelectedRow.Cells[5].Text;
                txtDtc.Text = Griddb.SelectedRow.Cells[6].Text;   

        }
    }
}