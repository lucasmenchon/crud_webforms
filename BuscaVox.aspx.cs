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
    public partial class Busca_Vox : System.Web.UI.Page
    {

        SqlConnection m_connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=contatos_db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //SqlCommand m_command = new SqlCommand();
        //SqlDataAdapter m_adapter = new SqlDataAdapter();
        DataTable m_datatable = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
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


    }
}