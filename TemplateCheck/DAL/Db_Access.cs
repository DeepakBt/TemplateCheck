﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CASSecurityLib;

namespace TemplateCheck.DAL
{
    public static class Db_Access
    {
        static string con;
        static Db_Access()
        {
            con = CASSecurity.DESDecrypt(ConfigurationManager.AppSettings.Get("DBConnection").ToString());
            //con = ConfigurationManager.AppSettings.Get("DBConnection").ToString();
        }
        public static DataTable ExecuteDataTable(ref SqlCommand cmd, string spName)
        {
            SqlCommand _cmd = default(SqlCommand);
            SqlDataAdapter _adapter = default(SqlDataAdapter);
            DataSet _ds = default(DataSet);
            SqlConnection _cnn = default(SqlConnection);
            _cmd = new SqlCommand();
            _adapter = new SqlDataAdapter();
            _cnn = new SqlConnection(con);
            if ((_cnn.State == ConnectionState.Open))
            {
                _cnn.Close();
            }
            else
            {
                _cnn.Open();
            }
            _cmd = cmd;
            _cmd.Connection = _cnn;
            _cmd.CommandText = spName;
            _cmd.CommandType = CommandType.StoredProcedure;
            _adapter.SelectCommand = _cmd;
            _ds = new DataSet();
            try
            {
                _adapter.Fill(_ds, "CRMTable");
            }
            catch (Exception ex)
            {
                _cmd.Dispose();
                throw ex;
            }
            finally
            {
                if ((_cnn.State == ConnectionState.Open))
                {
                    _cnn.Close();
                }
                _cnn.Dispose();
                _cmd.Dispose();
                _adapter.Dispose();
                GC.Collect();
            }
            return _ds.Tables["CRMTable"]; ;
        }

        public static DataSet ExecuteDataSet(ref SqlCommand cmd, string spName)
        {
            SqlCommand _cmd = default(SqlCommand);
            SqlDataAdapter _adapter = default(SqlDataAdapter);
            DataSet _ds = default(DataSet);
            SqlConnection _cnn = default(SqlConnection);
            _cmd = new SqlCommand();
            _adapter = new SqlDataAdapter();
            _cnn = new SqlConnection(con);
            if ((_cnn.State == ConnectionState.Open))
            {
                _cnn.Close();
            }
            else
            {
                _cnn.Open();
            }
            _cmd = cmd;
            _cmd.Connection = _cnn;
            _cmd.CommandText = spName;
            _cmd.CommandType = CommandType.StoredProcedure;
            _adapter.SelectCommand = _cmd;
            _ds = new DataSet();
            try
            {
                _adapter.Fill(_ds, "CRMTable");
            }
            catch (Exception ex)
            {
                _cmd.Dispose();
                throw ex;
            }
            finally
            {
                if ((_cnn.State == ConnectionState.Open))
                {
                    _cnn.Close();
                }
                _cnn.Dispose();
                _cmd.Dispose();
                _adapter.Dispose();
                GC.Collect();
            }
            return _ds;
        }
    }
}