using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Data
{
  public class DaoSucursal
  {
    private DataAccess _dataAccess = new DataAccess();

    public DaoSucursal() { }

    public DataTable GetAllSucursales()
    {
      DataTable dataTable = _dataAccess.GetDataTable("Sucursal", "SELECT S.Id_Sucursal, S.NombreSucursal, S.DescripcionSucursal AS 'Descripcion', P.DescripcionProvincia AS 'Provincias',S.DireccionSucursal AS 'Direccion' FROM Sucursal S JOIN Provincia P ON S.Id_ProvinciaSucursal = P.Id_Provincia");
      return dataTable;
    }
  }
}
