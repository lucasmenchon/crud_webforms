using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using TVox.Models;

namespace TVox
{
    public partial class Cadastro : System.Web.UI.Page
    {

        public static List<Contato> meusContatos = new List<Contato>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["meusContatos"] = meusContatos;
                GView.DataSource = meusContatos;
                GView.DataBind();

            }

            else
                meusContatos = ViewState["meusContatos"] as List<Contato>;

        }

        protected void cmdNew_Click(object sender, EventArgs e)
        {

            cadastros.Style.Add("Display", "normal");
            idGrid.Style.Add("display", "normal");

        }

        void Cadastros(int RowIndex)
        {

            Contato contato = meusContatos[RowIndex];

            txtId.Text = contato.Id.ToString();
            txtNome.Text = contato.Nome;
            txtIdade.Text = contato.Idade;
            txtTelefone.Text = contato.Telefone;
            txtGenero.Text = contato.Genero;
            txtDataCad.Text = contato.DataCadastro;
            //ViewState["RowIndex"] = RowIndex;

            // mostrar editor, ocultar grid

            cadastros.Style.Add("Display", "normal");
            idGrid.Style.Add("display", "normal");

        }



        //adicionar novo contato a lista
        protected void btnCad(object sender, EventArgs e)
        {
            Contato contato1 = null;

            if (!string.IsNullOrEmpty(txtId.Text))
            {
               contato1 = meusContatos.FirstOrDefault(contato => contato.Id == Convert.ToInt32(txtId.Text));
            }
            
            if(contato1 == null)
            {
                Contato contatoCadd = new Contato();

                contatoCadd.Id = meusContatos.Any() ? (meusContatos.Max(ctt => ctt.Id) + 1) : 1;
                contatoCadd.Nome = this.txtNome.Text;
                contatoCadd.Idade = this.txtIdade.Text;
                contatoCadd.Telefone = this.txtTelefone.Text;
                contatoCadd.Genero = this.txtGenero.Text;
                contatoCadd.DataCadastro = txtDataCad.Text;
                meusContatos.Add(contatoCadd);

            }
            else
            {
                contato1.Nome = this.txtNome.Text;
                contato1.Idade = this.txtIdade.Text;
                contato1.Genero = this.txtGenero.Text;
                contato1.Telefone = this.txtTelefone.Text;
                contato1.DataCadastro = this.txtDataCad.Text;
            }
                                    
            ViewState["meusContatos"] = meusContatos;
            cadastros.Style.Add("Display", "normal");
            idGrid.Style.Add("display", "normal");

            GView.DataSource = meusContatos;           
            GView.DataBind();
            limpaTela();

        }

        public void limpaTela()
        {
            txtId.Text = "";
            txtNome.Text = "";
            txtIdade.Text = "";
            txtTelefone.Text = "";
            txtDataCad.Text = "";

        }

        protected void cmdEdit_Click(object sender, EventArgs e)
        {
            Button btnEdit = sender as Button;
            GridViewRow gRow = btnEdit.NamingContainer as GridViewRow;
            Cadastros(gRow.RowIndex);    

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            cadastros.Style.Add("Display", "none");
            idGrid.Style.Add("display", "normal");

        }

        protected void cmdDel_Click(object sender, EventArgs e)
        {

            cadastros.Style.Add("Display", "none");
            idGrid.Style.Add("display", "normal");

            int RowIndex = (int)ViewState["RowIndex"];
            meusContatos.RemoveAt(RowIndex);
            GView.DataSource = meusContatos;
            GView.DataBind();

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            cadastros.Style.Add("Display", "none");
            idGrid.Style.Add("display", "normal");
            
            meusContatos.RemoveAll(idDel => idDel.Id == Convert.ToInt32( txtId.Text));
            GView.DataSource = meusContatos;
            GView.DataBind();
        }
    }
}