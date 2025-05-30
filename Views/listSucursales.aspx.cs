using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Business;
using Entities;
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

    protected void BtnFilter_Click(object sender, EventArgs e)
    {
      String input = txtFind.Text.Trim();

      if (String.IsNullOrEmpty(input))
      {
        lblShow.Text = "Please enter a Sucursale Id";
        return;
      }

      String queryFilter = $" WHERE Id_Sucursal = {input} ";
      DataTable tableSucursales = _sucursalService.GetAllSucursales(queryFilter);
      gridFiltros.DataSource = tableSucursales;
      gridFiltros.DataBind();
      // Sucursal sucursal = new Sucursal { Id = inputId };

    }

    protected void BtnShowAll_Click(object sender, EventArgs e)
    {
      this.Load_GridView();
    }
  }
}