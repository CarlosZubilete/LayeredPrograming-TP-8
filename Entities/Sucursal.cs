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
    private String _province; // in Database is a int , CHEKOUT! 
    private String _description;
    public Sucursal() { }
    public int Id
    {
      get { return _id; }
      set { _id = value; }
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
    public String Province
    {
      get { return _province; }
      set { _province = value; }
    }
    public String Description
    {
      get { return _description; }
      set { _description = value; }
    }
  }
}
