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
  }
}