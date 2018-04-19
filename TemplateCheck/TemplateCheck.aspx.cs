using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using TemplateCheck.DAL;

namespace TemplateCheck
{
    public partial class TemplateCheck : System.Web.UI.Page
    {
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLoadTemplate_Click(object sender, EventArgs e)
        {
            divTemplate.InnerText=GetTemplate(Convert.ToInt32(txtCpId.Text));
        }
        public string GetTemplate(int CPId)
        {
            string TString = string.Empty;
            try
            {
                cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@CPId", CPId);
                cmd.Parameters.AddWithValue("@Flag", 1);
                //cmd.Parameters.Add("@HTMLTemplate", SqlDbType.VarChar,200000);
                //cmd.Parameters["@HTMLTemplate"].Direction = ParameterDirection.Output;
                
                DataTable dt = Db_Access.ExecuteDataTable(ref cmd, "USP_CREMA_GET_CP_empanelform_html");
                TString = Convert.ToString(dt.Rows[0][0]);
                //TString=cmd.Parameters["@HTMLTemplate"].Value.ToString();
                return TString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}