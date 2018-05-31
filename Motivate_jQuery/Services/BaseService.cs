﻿using DatabaseConn.Adapter;
using Motivate_jQuery.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Motivate_jQuery.Services
{
    public class BaseService : IBaseService
    {
        string _connectionString;

        public BaseService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public IDbAdapter SqlAdapter
        {
            get
            {
                return new DbAdapter(new SqlCommand(), new SqlConnection(_connectionString));
            }
        }
    }
}