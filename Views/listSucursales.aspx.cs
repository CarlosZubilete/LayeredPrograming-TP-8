using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Business;
using System.Data;


namespace Views
{
  public partial class listSucursales : System.Web.UI.Page
  {
    private SucursalService _sucursalService = new SucursalService();
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        this.Load_GridView();
      }
    }
    private void Load_GridView()
    {
      DataTable tableSucursales = _sucursalService.GetAllSucursales();
      gridFiltros.DataSource = tableSucursales;
      gridFiltros.DataBind();
    }

  }
}