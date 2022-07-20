using Framework.Base.Atributos;
using Framework.Base.Database;
using Framework.Base.Entidade;
using Framework.Base.Enumeradores;
using Framework.Base.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using VoxPerfect.RN.cs;
using System.Web.UI;

namespace TVox.Models
{
    [clsAtrTabela("CONTACT_LUCAS")]
    public class Contact : clsBaseEntidade
    {
        [clsAtrCampo("ID", true)]
        public decimal Id { get; set; }

        [clsAtrCampo("NAME")]
        public string Name { get; set; }

        [clsAtrCampo("AGE")]
        public decimal Age { get; set; }

        [clsAtrCampo("PHONE")]
        public string Phone { get; set; }

        [clsAtrCampo("GENDER")]
        public string Gender { get; set; }

        [clsAtrCampo("REGISTER_DATE")]
        public DateTime RegisterDate { get; set; }


        public static List<Contact> GetContacts()
        {
            try
            {
                Contact contact = new Contact();
                return contact.Listar().Cast<Contact>().AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public override object getPKValue()
        {
            return Id;
        }

        public override object setPKValue(object aobjvalue)
        {
            Id = Convert.ToDecimal(aobjvalue);
            return aobjvalue;
        }


        public override enmObjectState State()
        {
            try
            {
                enmObjectState lenmState;
                Contact lobjEntity = new Contact();
                lobjEntity.Id = this.Id;
                if (lobjEntity.Abrir())
                    lenmState = enmObjectState.eAberto;
                else
                    lenmState = enmObjectState.eFechado;

                return lenmState;
            }
            catch (Exception Erro)
            {
                throw Erro;
            }
        }
  

        public bool SearchContact(string p_Name)
        {

            string lstrSelect = string.Empty;
            IDataReader l_DR = null;

            try
            {
                lstrSelect = "SELECT NAME, AGE, PHONE, GENDER, REGISTER_DATE FROM CONTACT_LUCAS WHERE NAME LIKE '" + "%" + p_Name + "%" + "'" + Environment.NewLine;

                l_DR = clsConexao.getDataReader(lstrSelect);
                return l_DR.Read();

            }
            catch (Exception Error)
            {
                throw Error;
            }
            finally
            {
                if (l_DR != null)
                {
                    l_DR.Close();
                    l_DR = null;
                }
            }
        }
    }
}
