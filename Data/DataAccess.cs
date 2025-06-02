using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
  class DataAccess
  {
    private String _connectingString_DBSucursales = @"Data Source=DESKTOP-LFTFVP5\SQLEXPRESS;Initial Catalog=BDSucursales;Integrated Security=True";
    public DataAccess() { }
    public Boolean RecordExists(String query)
    {
      Boolean state = false;
      SqlConnection connection = GetConnection();
      SqlCommand command = new SqlCommand(query, connection);

      SqlDataReader reader = command.ExecuteReader();

      if (reader.Read())
      {
        state = true;
      }

      return state;
    }
    public DataTable GetDataTable(String nameTable, String querySql)
    {
      using (SqlConnection connection = GetConnection())
      {
        try
        {
          DataSet dataSet = new DataSet();
          SqlDataAdapter dataAdapter = GetDataAdapter(querySql, connection);
          dataAdapter.Fill(dataSet, nameTable);
          return dataSet.Tables[nameTable];
        }
        catch (SqlException err)
        {
          Console.WriteLine("Error: " + err.Message);
          return null;
        }
      }
    }
    public int GetMaxSucursalId(String query)
    {
      int max = -1;
      SqlConnection connection = GetConnection();

      if (connection == null) return -1;

      SqlCommand command = new SqlCommand(query, connection);
      SqlDataReader reader = command.ExecuteReader();

      if (reader.Read())
      {
        max = Convert.ToInt32(reader[0].ToString());
      }

      return max;
    }
    public int ExecuteStoredProcedure(SqlCommand command, String storedProcedure)
    {
      try
      {
        using (SqlConnection connection = GetConnection())
        {
          if (connection == null) return -1;

          // connection.Open();
          command.Connection = connection;
          command.CommandType = CommandType.StoredProcedure;  // Indico el tipo de procedimiento.
          command.CommandText = storedProcedure; // Nombre del procedimiento o query.
          return command.ExecuteNonQuery(); // Ejecuto el procedimiento y retorna las filas afectadas.
        }
      }
      catch (SqlException ex)
      {
        Console.WriteLine("Error when the command executed: " + ex.Message);
        return -1;
      }
    }

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
