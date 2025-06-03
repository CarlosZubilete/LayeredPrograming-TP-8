using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data;
using Entities;

namespace Business
{
  public class SucursalService
  {
    private DaoSucursal _dao = new DaoSucursal();
    public SucursalService() { }
    public DataTable GetAllSucursales(String queryFilter = null)
    {
      return _dao.GetAllSucursales(queryFilter);
    }
    public bool AddSucursal(String name, String description, int idProvincia, String address)
    {
      int cantRows;

      Sucursal sucursal = new Sucursal { Name = name };
      DaoSucursal dao = new DaoSucursal();

      if (dao.IsSucursaleDuplicate(sucursal))
      {
        return false;
      }

      sucursal.Description = description;
      sucursal.IdProvince = idProvincia;
      sucursal.Address = address;

      cantRows = dao.AddSucursal(sucursal);

      if (cantRows == 1)
        return true;
      else
        return false;
    }
    // TODO: get the sucursal to show their data with anoteh function.
    // TODO: create a function to verificate if idSuc exists.
    public Sucursal GetSucursal(int idSucursal)
    {
      Sucursal sucursal = new Sucursal { Id = idSucursal };
      DaoSucursal dao = new DaoSucursal();

      if (sucursal.Id == -1) return sucursal; 

      dao.GetSucursal(ref sucursal);

      return sucursal; 
    }
    public bool ExistsSucursal(int idSucursal)
    {
      DaoSucursal dao = new DaoSucursal();
      return dao.ExistsSucursal(idSucursal); 
    }
    public int DeleteSucursalById(int idSucursal)
    {
      Sucursal sucursal = new Sucursal { Id = idSucursal };
      DaoSucursal dao = new DaoSucursal();
      return dao.DeleteSucursal(sucursal);
    }
  }
}
