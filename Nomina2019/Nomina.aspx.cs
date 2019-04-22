using System;
using Logica;
using System.Web.UI.WebControls;
using System.Data;

namespace Nomina2019
{
    public partial class Nomina : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblNombre.Text = Request.QueryString["Nombre"] + " " +
                    Request.QueryString["Apellidos"];
                foreach (DataRow row in AccesoLogica.ObtenerDepartamentos().Rows)
                {
                    ListItem depto = new ListItem(row[1].ToString(), row[0].ToString());
                    this.ddlDepartamentos.Items.Add(depto);
                }
                ddlDepartamentos.SelectedIndex = - 1;
            }
        }

        private void Page_Init(object sender, EventArgs e)
        {
            txtBuscar.Attributes.Add("onkeypress", "return GetValidatorNumSinDecimal(event)");
            txtdiasTrabajados.Attributes.Add("onkeypress", "return GetValidatorNumSinDecimal(event)");
            txtHorasExtra.Attributes.Add("onkeypress", "return GetValidatorNumSinDecimal(event)");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            AccesoLogica.InsertaNomina(Convert.ToInt32(Request.QueryString["idEmpleado"]),
                Convert.ToInt32(txtdiasTrabajados.Text), Convert.ToInt32(txtHorasExtra.Text),
                clPeriodoDesde.SelectedDate.ToShortDateString(), 
                clPeridodHasta.SelectedDate.ToShortDateString());
            LimpiarFormulario();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                this.gvNominas.DataSource = AccesoLogica.ObtenerNominasEmpleado(Convert.ToInt32(txtBuscar.Text), 1);
                this.gvNominas.DataBind();
            }
            
        }

        
        private void LimpiarFormulario()
        {
            this.txtdiasTrabajados.Text = "";
            this.txtHorasExtra.Text = "";
            this.clPeriodoDesde.SelectedDate = new DateTime();
            this.clPeridodHasta.SelectedDate = new DateTime();
        }

        protected void gvNominas_RowCommand1(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void ddlDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.gvNominas.DataSource = AccesoLogica.ObtenerNominasEmpleado(ddlDepartamentos.SelectedIndex+1, 2);
            this.gvNominas.DataBind();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}