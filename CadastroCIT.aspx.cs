using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using VoxPerfect.RN.cs;
using System.Collections.Generic;
using TVox.Models;
using System.Linq;

namespace TVox
{
    public partial class CadastroCIT : System.Web.UI.Page
    {
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

        protected void RegisterContact(object sender, EventArgs e)
        {
            Contact l_contact = new Contact();

            l_contact.Id = Convert.ToDecimal(l_contact.getNewPK());
            l_contact.Name = textName.Text;
            l_contact.Age = Convert.ToInt32(textAge.Text);
            l_contact.Phone = textPhone.Text;
            l_contact.Gender = ddlGender.SelectedValue;
            l_contact.RegisterDate = Convert.ToDateTime(RegisterDate.Text);

            if (l_contact.Salvar(true) > 0)
            {
                textMsg.Text = "<p class='alert alert-success' role='alert'>CADASTRADO COM SUCESSO!</p>";
            }
            else
            {
                textMsg.Text = "<div class='alert alert-warning' role='alert'>NÃO CADASTRADO.</ div >";
            }

            ClearForm();
            LoadData();
        }

        protected void UpdateContact(object sender, EventArgs e)
        {
            // Update
            Contact l_contactUpdate = new Contact();
            l_contactUpdate.Id = Convert.ToDecimal(lblId.Text);

            //retorna objeto
            if (l_contactUpdate.Abrir())
            {

                l_contactUpdate.Name = textName.Text;
                l_contactUpdate.Age = Convert.ToInt32(textAge.Text);
                l_contactUpdate.Phone = textPhone.Text;
                l_contactUpdate.Gender = ddlGender.SelectedValue;
                l_contactUpdate.RegisterDate = Convert.ToDateTime(RegisterDate.Text);
                if (l_contactUpdate.Salvar(true) > 0)
                {
                    textMsg.Text = "<p class='alert alert-info' role='alert'>ATUALIZADO COM SUCESSO!</p>";
                }
                else
                {
                    textMsg.Text = "<p class='alert alert-warning' role='alert'>NÃO ATUALIZADO!</p>";
                }
            }

            ClearForm();
            LoadData();
        }

        protected void DeleteContact(object sender, EventArgs e)
        {
            //delete
            Contact l_contactDelete = new Contact();
            l_contactDelete.Id = Convert.ToDecimal(lblId.Text);
            l_contactDelete.Excluir();
            textMsg.Text = "<p class='alert alert-danger' role='alert'>DELETADO COM SUCESSO!</p>";

            ClearForm();
            LoadData();
        }

        protected void DbGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblId.Text = DbGridView.SelectedRow.Cells[1].Text;
                textName.Text = DbGridView.SelectedRow.Cells[2].Text;
                textAge.Text = DbGridView.SelectedRow.Cells[3].Text;
                textPhone.Text = DbGridView.SelectedRow.Cells[4].Text;
                ddlGender.Text = DbGridView.SelectedRow.Cells[5].Text;
                RegisterDate.Text = Convert.ToDateTime(DbGridView.SelectedRow.Cells[6].Text).ToString("yyyy-MM-dd");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}