using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace ManagementPlatform
{
    class dbProcess
    {
        #region MySql資料庫
        //資料庫連接字串
        static string mySqlConnectionString = "server=localhost;uid=root;pwd=1234;SslMode=none;";
        static MySqlConnection _mySqlConnection = null;
        public static MySqlConnection mySqlConnection
        {
            get
            {
                if (_mySqlConnection == null)
                {
                    _mySqlConnection = new MySqlConnection(mySqlConnectionString);
                    _mySqlConnection.Open();
                    return _mySqlConnection;
                }
                else if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    _mySqlConnection.Open();
                    return _mySqlConnection;
                }
                else
                {
                    return _mySqlConnection;
                }
            }
        }
        ///// <summary>
        ///// 取得欲查詢之資料dataset
        ///// </summary>
        ///// <param name="sql">SQL command</param>
        ///// <returns>dataset</returns>
        public static DataSet GetDataSet(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adp.Fill(ds);
            mySqlConnection.Close();

            return ds;
        }
        /// <summary>
        /// 取得資料欲查詢之資料表
        /// </summary>
        /// <param name="sql">SQL command</param>
        /// <returns>欲查詢之資料表</returns>
        public static DataTable GetDataTable(string sql)
        {
            //建立 DataSet
            DataSet dataSet = new DataSet();

            MySqlDataAdapter dataAdapter1 = new MySqlDataAdapter(sql, mySqlConnection);
            dataAdapter1.Fill(dataSet, "dataInfo");

            DataTable dataTable = dataSet.Tables["dataInfo"];
            mySqlConnection.Close();
            return dataTable;
        }
        /// <summary>
        /// 回傳影響行數
        /// </summary>
        /// <param name="sql">SQL command</param>
        /// <returns>影響之資料行數</returns>
        public static int ExecuteSQL(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, mySqlConnection);
            return cmd.ExecuteNonQuery();
        }
        #endregion

    }
}
