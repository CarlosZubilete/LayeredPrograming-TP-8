using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccess
{
  class DataAccess
  {
    private String _connectingString_DBSucursales = @"Data Source=DESKTOP-LFTFVP5\SQLEXPRESS;Initial Catalog=BDSucursales;Integrated Security=True";
    public DataAccess() { }
    private SqlConnection GetConnection()
    {
      try
      {
        SqlConnection connection = new SqlConnection(_connectingString_DBSucursales);
        connection.Open();
        return connection;
      }
      catch (SqlException err)
      {
        Console.WriteLine("Something went wrong to the connection to the Database " + err.Message);
        return null;
      }
    }
    private SqlDataAdapter GetDataAdapter(String querySql, SqlConnection connection)
    {
      try
      {
        SqlDataAdapter dataAdapter;
        dataAdapter = new SqlDataAdapter(querySql, connection);
        return dataAdapter;
      }
      catch (SqlException err)
      {
        Console.WriteLine("Something went wrong when the DataAdapter got " + err.Message);
        return null;
      }
    }
  }
}
