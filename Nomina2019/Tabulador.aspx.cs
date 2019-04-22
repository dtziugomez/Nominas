using System;
using System.Web.UI;
using Logica;


namespace Nomina2019
{
    public partial class Tabulador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                this.txtSueldo.Text = Request.QueryString["SueldoBase"];
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            AccesoLogica.ActualizaTabulador(Convert.ToInt32(Request.QueryString["idEmpleado"]),
                Convert.ToDecimal(txtSueldo.Text));
            Response.Redirect("Default.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}