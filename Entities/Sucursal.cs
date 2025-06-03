using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public class Sucursal
  {
    private int _id;
    private String _name;
    private String _address;
    private int _idProvince; 
    private String _description;
    public Sucursal() { }
 
    public int Id
    {
      get { return _id; }
      set { _id = value;  }
    }
    public String Name
    {
      get { return _name; }
      set { _name = value; }
    }
    public String Address
    {
      get { return _address; }
      set { _address = value; }
    }
    public int IdProvince
    {
      get { return _idProvince; }
      set { _idProvince = value; }
    }
    public String Description
    {
      get { return _description; }
      set { _description = value; }
    }
  }
}
