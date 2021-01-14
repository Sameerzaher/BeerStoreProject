/*
 **********************************************************
 *                                                        *
 * By: Ameer Kassis - Sameer Zaher - Yuri Malamoud - 41/1 *
 *                                                        *
 **********************************************************
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace BeerStoreProject
{
    public class DbAccess
    {

        #region Constructor + Members
        protected OleDbConnection _conn = null;

        public DbAccess(string connectionString)
        {
            _conn = new OleDbConnection(connectionString);
        }
        #endregion

        #region Protected Methods

        protected void Connect()
        {
            if (_conn.State != ConnectionState.Open)
                _conn.Open();
        }

        protected void DisConnect()
        {
            _conn.Close();
        }

        protected void ExecuteSimpleQuery(OleDbCommand command)
        {
            lock (_conn)
            {
                Connect();
                command.Connection = _conn;
                try
                {
                    command.ExecuteNonQuery();
                }
                finally
                {
                    DisConnect();
                }
            }
        }

        protected int ExecuteScalarIntQuery(OleDbCommand command)
        {
            int ret = -1;
            lock (_conn)
            {
                Connect();
                command.Connection = _conn;
                try
                {
                    ret = (int)command.ExecuteScalar();
                }
                finally
                {
                    DisConnect();
                }
            }
            return ret;
        }

        protected DataSet GetMultipleQuery(OleDbCommand command)
        {
            DataSet dataset = new DataSet();
            lock (_conn)
            {
                Connect();
                command.Connection = _conn;
                try
                {
                    OleDbDataAdapter adapter = new OleDbDataAdapter();
                    adapter.SelectCommand = command;
                    adapter.Fill(dataset);
                }
                    
                finally
                {
                    DisConnect();
                }
            }
            return dataset;
        }
        #endregion

    }
}
