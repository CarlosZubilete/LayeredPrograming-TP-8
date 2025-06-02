using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Business;


namespace Views
{
  public partial class index : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        this.Load_ProvinciasDropDown();
        // TImer
        timer_lblShow.Enabled = false;
      }
    }
    private void Load_ProvinciasDropDown()
    {
      ProvinciaService provinciaService = new ProvinciaService();
      DataTable dataTable = provinciaService.GetAllProvincies();

      ddlProvinciesSuc.DataSource = dataTable;
      ddlProvinciesSuc.DataTextField = "DescripcionProvincia";
      ddlProvinciesSuc.DataValueField = "Id_Provincia";
      ddlProvinciesSuc.DataBind();

      ddlProvinciesSuc.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));
    }

    protected void BtnSend_Click(object sender, EventArgs e)
    {
      SucursalService sucursalService = new SucursalService();
      String name = txtNameSuc.Text.Trim().ToString();
      String description = txtDescriptionSuc.Text.Trim().ToString();
      String idProvincia = ddlProvinciesSuc.SelectedValue.ToString();
      String address = txtAddressSuc.Text.Trim().ToString();

      if (sucursalService.AddSucursal(name, description, Convert.ToInt32(idProvincia), address))
      {
        lblShow.Text = "Sucursal added successfully";
        this.CleanControl();
        timer_lblShow.Enabled = true; 
      }
      else
      {
        lblShow.Text = "Error, something got wrong";
        timer_lblShow.Enabled = true;
      }
    }
    private void CleanControl()
    {
      txtNameSuc.Text = string.Empty;
      txtDescriptionSuc.Text = string.Empty;
      txtAddressSuc.Text = string.Empty;
      ddlProvinciesSuc.SelectedIndex = 0;
    }

    protected void Timer_lblShow_Tick(object sender, EventArgs e)
    {
      lblShow.Text = string.Empty;
      timer_lblShow.Enabled = false;
    }
  }
}
// TODO: NO ENTRA EN EL TRY Y EL CATCH.
/*
Nombre: Mi gusto
Descripcion: Restaurante y cadena de comida que se especializa en empanadas y pizzas
Provincia: Buenos Aires
Direccion : Av. Cazón 699 esq, B. Marabotto, B1648 Tigre
*/

/*
Nombre: Sport Club
Descripcion: Cadena de gimnasios y centros deportivos líder en Argentina
Provincia: Buenos Aires
Direccion : Montes de Oca 201, B1648 Tigre
 */