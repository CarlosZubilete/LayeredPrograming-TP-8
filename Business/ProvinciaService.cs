﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using System.Data;


namespace Business
{
  public class ProvinciaService
  {
    private DaoProvincia _dao = new DaoProvincia();
    public ProvinciaService() { }
    public DataTable GetAllProvincies()
    {
      return _dao.GetAllProvincies();
    }

  }
}
