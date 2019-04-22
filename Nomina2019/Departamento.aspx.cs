using System;
using System.Web.UI;
using Logica;

namespace Nomina2019
{
    public partial class Departamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            lblMensaje.Visible = false;
            if (!string.IsNullOrEmpty(txtNombreDepto.Text))
            {
                if (AccesoLogica.InsertaDepartamento(txtNombreDepto.Text))
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "Ya existe un Departamento con el mismo nombre";
                }
                else { 
                    txtNombreDepto.Text = "";
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Confirm", "alert(\"" + "Listo!" + "\")", true);
                    Response.Redirect("Default.aspx");
                }
            }
            else
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "*";
            }
            
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}