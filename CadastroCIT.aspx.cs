using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using VoxPerfect.RN.cs;
using System.Collections.Generic;

namespace TVox
{
    public partial class CadastroCIT : System.Web.UI.Page
    {
        SqlConnection m_connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=contatos_db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //SqlCommand m_command = new SqlCommand();
        //SqlDataAdapter m_adapter = new SqlDataAdapter();
        DataTable m_datatable = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            List<clsContact> clsContacts = clsContact.GetContacts();

            try
            {
                if (!IsPostBack)
                {
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void ClearForm()
        {
            try
            {
                lblId.Text = "";
                textName.Text = "";
                textAge.Text = "";
                textPhone.Text = "";
                RegisterDate.Text = "";
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }

        protected void RegisterContact(object sender, EventArgs e) // '" + int.Parse(txtId.Text) + "',
        {
            try
            {
                m_connect.Open();
                SqlCommand l_command = new SqlCommand("INSERT INTO Contato VALUES ('" + textName.Text + "','" + int.Parse(textAge.Text) + "','" + textPhone.Text + "','" + ddlGender.SelectedValue + "','" + RegisterDate.Text + "')", m_connect); ;
                l_command.ExecuteNonQuery();
                m_connect.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Sucesso. Cadastrado!');", true);
                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        void LoadData()
        {
            try
            {
                SqlCommand l_command = new SqlCommand(" SELECT * FROM Contato", m_connect);
                SqlDataAdapter l_adapter = new SqlDataAdapter(l_command);
                m_datatable = new DataTable();
                l_adapter.Fill(m_datatable);
                DbGridView.DataSource = m_datatable;
                DbGridView.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        protected void UpdateContact(object sender, EventArgs e) //btnUpdateContact btnUpdate(X)
        {
            try
            {
                m_connect.Open();
                SqlCommand l_command = new SqlCommand("UPDATE Contato SET Nome = '" + textName.Text + "', Idade = '" + int.Parse(textAge.Text) + "', Telefone = '" + textPhone.Text + "', Genero = '" + ddlGender.SelectedValue + "', DataCadastro = '" + RegisterDate.Text + "' WHERE Id = '" + int.Parse(lblId.Text) + "'", m_connect);
                l_command.ExecuteNonQuery();
                m_connect.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Sucesso. Atualizado!');", true);
                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        protected void DeleteContact(object sender, EventArgs e)
        {
            try
            {

                m_connect.Open();
                SqlCommand l_command = new SqlCommand("DELETE Contato WHERE Id = '" + int.Parse(lblId.Text) + "'", m_connect);
                l_command.ExecuteNonQuery();
                m_connect.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Sucesso. Deletado!');", true);
                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        protected void SearchContact(object sender, EventArgs e)
        {
            try
            {
                SqlCommand l_command = new SqlCommand(" SELECT Nome, Idade, Telefone, Genero, DataCadastro FROM Contato WHERE Nome LIKE '" + "%" + textSearchContact.Text + "%" + "' ", m_connect);
                if (textSearchContact.Text == "")
                {
                    LoadData();
                }
                else
                {
                    SqlDataAdapter l_adapter = new SqlDataAdapter(l_command);
                    l_adapter.Fill(m_datatable);
                    DbGridView.DataSource = m_datatable;
                    DbGridView.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        protected void SelectContact(object sender, EventArgs e)
        {
            try
            {
                lblId.Text = DbGridView.SelectedRow.Cells[1].Text;
                textName.Text = DbGridView.SelectedRow.Cells[2].Text;
                textAge.Text = DbGridView.SelectedRow.Cells[3].Text;
                textPhone.Text = DbGridView.SelectedRow.Cells[4].Text;
                ddlGender.Text = DbGridView.SelectedRow.Cells[5].Text;
                RegisterDate.Text = DbGridView.SelectedRow.Cells[6].Text;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}