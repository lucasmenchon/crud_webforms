using Framework.Base.Database;
using Framework.Base.Entidade;
using Framework.Base.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TVox.Models;

namespace TVox
{
    public partial class BuscaCIT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        public void LoadData()
        {
            try
            {
                Contact l_contactSearch = new Contact();
                List<Contact> l_contacts = l_contactSearch.Listar().Cast<Contact>().AsQueryable().ToList();

                DbGridView.DataSource = l_contacts.Select(p => new
                {
                    ID = p.Id,
                    Name = p.Name,
                    Age = p.Age,
                    Phone = p.Phone,
                    Gender = p.Gender,
                    RegisterDate = p.RegisterDate.ToString("dd/MM/yyyy"),

                });

                DbGridView.DataBind();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void SearchContact(object sender, EventArgs e)
        {
            List<Contact> contacts = new List<Contact>();

            string l_cmdSelect = string.Empty;
            IDataReader l_dataReader = null;
            try
            {
                l_cmdSelect = "SELECT ID," +
                            " NAME, " +
                            "AGE, " +
                            "PHONE, " +
                            "GENDER, " +
                            "REGISTER_DATE " +
                            "FROM CONTACT_LUCAS " +
                            "WHERE " +
                            "UPPER (NAME) LIKE '" + textSearchName.Text.ToUpper() + "%" + "'";

                if (!string.IsNullOrEmpty(textSearchGender.Text))
                    l_cmdSelect += $"AND GENDER = '{textSearchGender.Text}'";

                if (!string.IsNullOrEmpty(textSearchAge.Text))
                    l_cmdSelect += $"AND AGE = {textSearchAge.Text}";

                if (!string.IsNullOrEmpty(textSearchPhone.Text))
                    l_cmdSelect += $"AND PHONE = '{textSearchPhone.Text}'";

                if (!string.IsNullOrEmpty(textSearchDate.Text))
                    l_cmdSelect += $"AND REGISTER_DATE = '{Convert.ToDateTime(textSearchDate.Text).ToString("yyyy-MM-dd")}'";

                l_dataReader = clsConexao.getDataReader(l_cmdSelect);
                using (IDataReader l_DR = clsConexao.getDataReader(l_cmdSelect))
                {
                    clsBaseEntidade l_Entity;
                    while (l_DR.Read())
                    {
                        l_Entity = new Contact();
                        clsUtils.setRsToObj(ref l_Entity, l_Entity.GetType(), l_DR);
                        contacts.Add((Contact)l_Entity);
                    }
                }

                DbGridView.DataSource = contacts;
                DbGridView.DataBind();
            }
            catch (Exception error)
            {
                throw new Exception(error.ToString());
            }
            finally
            {
                if (l_dataReader != null)
                {
                    l_dataReader.Close();
                    l_dataReader = null;
                }
            }
        }

        protected void ListAll(object sender, EventArgs e)
        {
            LoadData();
        }

    }
}