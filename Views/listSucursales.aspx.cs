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
    private readonly SucursalService _sucursalService = new SucursalService();
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        this.Load_GridView();
      }
    }
    private void Load_GridView(String queryFiler = null)
    {
      lblShow.Text = string.Empty;

      DataTable tableSucursales = _sucursalService.GetAllSucursales(queryFiler);

      if (tableSucursales.Rows.Count == 0 || tableSucursales == null)
      {
        gridFiltros.DataSource = null;
        gridFiltros.DataBind();
        lblShow.Text = "No results found :( ";
        return;
      }

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
      this.Load_GridView(queryFilter);

    }

    protected void BtnShowAll_Click(object sender, EventArgs e)
    {
      txtFind.Text = string.Empty;
      this.Load_GridView();
    }
  }
}