using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Entities;

namespace Views
{
  public partial class DeleteSucursal : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        timer_lblShow.Enabled = false;
      }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      String inputId = txtFind.Text.Trim().ToString();
      // lblShow.Text = inputId;
      int idSucursal = Convert.ToInt32(inputId);

      SucursalService sucursalService = new SucursalService();

      if (!sucursalService.ExistsSucursal(idSucursal))
      {
        lblShowTable.Text = $@"
        <div style='border: 1px solid black; background-color: #333; color: #fff; padding: 10px; font-weight: bold ; text-align: center;'>
              No se han encontrado registros
          </div>";
      }
      else
      {
        Sucursal sucursal = sucursalService.GetSucursal(idSucursal);
        this.ShowTableMessage(ref sucursal);
        
        if (sucursalService.DeleteSucursalById(idSucursal) == 1)
        {
          Console.WriteLine("Delete successfully");
          lblShowTable.Text += $@"<div style='border: 1px solid black; background-color: #333; color: #fff; padding: 10px; font-weight: bold; text-align: center;'>
              Se ha eliminado de la BBDD
          </div>";
        }
      }

      timer_lblShow.Enabled = true;
      txtFind.Text = string.Empty;

    }

    private void ShowTableMessage(ref Sucursal sucursal)
    {
      lblShowTable.Text = $@"
        <table style='border-collapse: collapse; background-color: #fff; color: #333; width: 100%;'>
            <tr>
                <th style='border: 1px solid black; padding: 8px;'>ID</th>
                <td style='border: 1px solid black; padding: 8px;'>{sucursal.Id}</td>
            </tr>
            <tr>
                <th style='border: 1px solid black; padding: 8px;'>Name</th>
                <td style='border: 1px solid black; padding: 8px;'>{sucursal.Name}</td>
            </tr>
            <tr>
                <th style='border: 1px solid black; padding: 8px;'>Descripción</th>
                <td style='border: 1px solid black; padding: 8px;'>{sucursal.Description}</td>
            </tr>
            <tr>
                <th style='border: 1px solid black; padding: 8px;'>Dirección</th>
                <td style='border: 1px solid black; padding: 8px;'>{sucursal.Address}</td>
            </tr>
        </table>";

    }
    protected void timer_lblShow_Tick(object sender, EventArgs e)
    {
      lblShowTable.Text = string.Empty;
      timer_lblShow.Enabled = false;
    }
  }
}