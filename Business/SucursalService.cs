using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data;


namespace Business
{
  public class SucursalService
  {
    private DaoSucursal _dao = new DaoSucursal();
    public SucursalService() { }
    public DataTable GetAllSucursales( String queryFilter = null)
    {
      return _dao.GetAllSucursales(queryFilter);
    }
  }
}
