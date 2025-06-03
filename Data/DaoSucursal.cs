using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entities;

namespace Data
{
  public class DaoSucursal
  {
    private DataAccess _dataAccess = new DataAccess();
    public DaoSucursal() { }

    public DataTable GetAllSucursales(String queryFilter = null) // Maybe we must find a more descriptive name
    {
      String query = "SELECT S.Id_Sucursal, S.NombreSucursal, S.DescripcionSucursal AS 'Descripcion', P.DescripcionProvincia AS 'Provincias',S.DireccionSucursal AS 'Direccion' FROM Sucursal S JOIN Provincia P ON S.Id_ProvinciaSucursal = P.Id_Provincia";

      if (!String.IsNullOrEmpty(queryFilter))
        query += queryFilter;

      DataTable dataTable = _dataAccess.GetDataTable("Sucursal", query);
      return dataTable;
    }
    public Boolean IsSucursaleDuplicate(Sucursal sucursal) // maaybe , we should find another name. 'FindNameSucusal'
    {
      String query = $"SELECT * FROM Sucursal WHERE NombreSucursal = '{sucursal.Name}' ";
      return _dataAccess.RecordExists(query);
    }
    public int AddSucursal(Sucursal sucursal)
    {
      SqlCommand command = new SqlCommand();
      this.BuildAddSucursalParameters(ref command, sucursal);
      return _dataAccess.ExecuteStoredProcedure(command, "spAgregarSucursal");
    }
    public int GetMaxSucursalId()
    {
      return _dataAccess.GetMaxSucursalId("Select MAX(Id_Sucursal) FROM Sucursal");
    }
    public int DeleteSucursal(Sucursal sucursal)
    {
      SqlCommand command = new SqlCommand();
      this.BuildDeleteSucursalParameters(ref command, sucursal);
      return _dataAccess.ExecuteStoredProcedure(command, "spEliminarSucursal");
    }
    public bool ExistsSucursal(int id)
    {
      DataTable dataTable = _dataAccess.GetDataTable("Sucursal", $"SELECT * FROM Sucursal WHERE Id_Sucursal = {id}");
      if (dataTable == null || dataTable.Rows.Count == 0)
        return false;
      else return true;
    }
    public Sucursal GetSucursal( ref Sucursal sucursal)
    {
      DataTable dataTable = _dataAccess.GetDataTable("Sucursal", $"SELECT * FROM Sucursal WHERE Id_Sucursal = {sucursal.Id}");

      if (dataTable == null || dataTable.Rows.Count == 0)
      {
        sucursal.Id = -1; // We report an error.
        return sucursal;
      }

      // sucursal.Id = Convert.ToInt32(dataTable.Rows[0][1].ToString());
      sucursal.Name = dataTable.Rows[0][1].ToString();
      sucursal.Description = dataTable.Rows[0][2].ToString();
      sucursal.IdProvince = Convert.ToInt32(dataTable.Rows[0][4].ToString());
      sucursal.Address = dataTable.Rows[0][5].ToString();

      return sucursal;
    }
    private void BuildAddSucursalParameters(ref SqlCommand command, Sucursal sucursal)
    {
      SqlParameter parameter; // = new SqlParameter();

      parameter = command.Parameters.Add("@NOMBRESUCURSAL", SqlDbType.VarChar, 100);
      parameter.Value = sucursal.Name;

      parameter = command.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar, 100);// 'DESCRICION'
      parameter.Value = sucursal.Description;

      parameter = command.Parameters.Add("@IDPROVINCIA", SqlDbType.Int);
      parameter.Value = sucursal.IdProvince;

      parameter = command.Parameters.Add("@DIRECCION", SqlDbType.VarChar, 100);
      parameter.Value = sucursal.Address;
    }
    private void BuildDeleteSucursalParameters(ref SqlCommand command, Sucursal sucursal)
    {
      SqlParameter parameter; // = new SqlParameter();
      parameter = command.Parameters.Add("@IDSUCURSAL", SqlDbType.Int);
      parameter.Value = sucursal.Id;
    }
  }
}

/*
Use BDSucursales
GO

CREATE PROCEDURE [dbo].[spAgregarSucursal](
@NOMBRESUCURSAL NVARCHAR(100),
@DESCRIPCION NVARCHAR(100),
@IDPROVINCIA INT,
@DIRECCION NVARCHAR(100)
)
AS 
INSERT INTO Sucursal 
(
NombreSucursal,
DescripcionSucursal,
Id_ProvinciaSucursal,
DireccionSucursal)
VALUES (
@NOMBRESUCURSAL,
@DESCRIPCION,
@IDPROVINCIA,
@DIRECCION)

RETURN
*/

/*
USE BDSucursales
GO

CREATE PROCEDURE [dbo].[spEliminarSucursal] (
    @IDSUCURSAL INT
)
AS
    DELETE FROM Sucursal WHERE Id_Sucursal = @IDSUCURSAL;
    RETURN 

*/