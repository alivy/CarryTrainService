
using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteHelp
{
    public class DBHelp
    {
        public static string basepath = new DirectoryInfo("../../").FullName;
        public static string connStr = @"Data Source=" + basepath + @"LiteDB\CarryTrain.db;Initial Catalog=sqlite;Integrated Security=True;Max Pool Size=10";
        //public static string connStr = string.Format(@"Data Source={0}\CarryTrain.db;Initial Catalog=sqlite;Integrated Security=True;Max Pool Size=10", System.IO.Directory.GetCurrentDirectory());
        //public static string connStr = AppResource.FilePath("LiteDB.CarryTrain.db");
        /// <summary>
        /// 返回DataTable类型数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable DataTableQuery(string sql)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                //conn.Open();
                using (SQLiteDataAdapter ap = new SQLiteDataAdapter(sql, conn))
                {
                    DataSet ds = new DataSet();
                    ap.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    return dt;
                }
            }
        }

        #region ExecuteNonQuery命令
        /// <summary>  
        /// 对数据库执行增、删、改命令  
        /// </summary>  
        /// <param name="safeSql">T-Sql语句</param>  
        /// <returns>受影响的记录数</returns>  
        public static int ExecuteNonQuery(string safeSql)
        {
            using (SQLiteConnection Connection = new SQLiteConnection(connStr))
            {
                Connection.Open();
                SQLiteTransaction trans = Connection.BeginTransaction();
                try
                {
                    SQLiteCommand cmd = new SQLiteCommand(safeSql, Connection);
                    cmd.Transaction = trans;
                    if (Connection.State != ConnectionState.Open)
                    {
                        Connection.Open();
                    }
                    int result = cmd.ExecuteNonQuery();
                    trans.Commit();
                    return result;
                }
                catch(Exception ex)
                {
                    Log.Write(LogLevel.Error, "执行数据库执行增、删、改命令失败", ex);
                    trans.Rollback();
                    return 0;
                }
            }
        }

        /// <summary>  
        /// 对数据库执行增、删、改命令  
        /// </summary>  
        /// <param name="sql">T-Sql语句</param>  
        /// <param name="values">参数数组</param>  
        /// <returns>受影响的记录数</returns>  
        public static int ExecuteNonQuery(string sql, SqlParameter[] values)
        {
            using (SQLiteConnection Connection = new SQLiteConnection(connStr))
            {
                Connection.Open();
                SQLiteTransaction trans = Connection.BeginTransaction();
                try
                {
                    SQLiteCommand cmd = new SQLiteCommand(sql, Connection);
                    cmd.Transaction = trans;
                    cmd.Parameters.AddRange(values);
                    if (Connection.State != ConnectionState.Open)
                    {
                        Connection.Open();
                    }
                    int result = cmd.ExecuteNonQuery();
                    trans.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return 0;
                }
            }
        }
        #endregion

        #region ExecuteScalar命令
        /// <summary>  
        /// 查询结果集中第一行第一列的值  
        /// </summary>  
        /// <param name="safeSql">T-Sql语句</param>  
        /// <returns>第一行第一列的值</returns>  
        public static int ExecuteScalar(string safeSql)
        {
            using (SQLiteConnection Connection = new SQLiteConnection(connStr))
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
                SQLiteCommand cmd = new SQLiteCommand(safeSql, Connection);
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
        }

        /// <summary>  
        /// 查询结果集中第一行第一列的值  
        /// </summary>  
        /// <param name="sql">T-Sql语句</param>  
        /// <param name="values">参数数组</param>  
        /// <returns>第一行第一列的值</returns>  
        public static int ExecuteScalar(string sql, SqlParameter[] values)
        {
            using (SQLiteConnection Connection = new SQLiteConnection(connStr))
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
                SQLiteCommand cmd = new SQLiteCommand(sql, Connection);
                cmd.Parameters.AddRange(values);
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
        }
        #endregion

        #region ExecuteReader命令
        /// <summary>  
        /// 创建数据读取器  
        /// </summary>  
        /// <param name="safeSql">T-Sql语句</param>  
        /// <param name="Connection">数据库连接</param>  
        /// <returns>数据读取器对象</returns>  
        public static SQLiteDataReader ExecuteReader(string safeSql, SQLiteConnection Connection)
        {
            if (Connection.State != ConnectionState.Open)
                Connection.Open();
            SQLiteCommand cmd = new SQLiteCommand(safeSql, Connection);
            SQLiteDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        /// <summary>  
        /// 创建数据读取器  
        /// </summary>  
        /// <param name="sql">T-Sql语句</param>  
        /// <param name="values">参数数组</param>  
        /// <param name="Connection">数据库连接</param>  
        /// <returns>数据读取器</returns>  
        public static SQLiteDataReader ExecuteReader(string sql, SqlParameter[] values, SQLiteConnection Connection)
        {
            if (Connection.State != ConnectionState.Open)
                Connection.Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            SQLiteDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        #endregion

        #region ExecuteDataTable命令
        /// <summary>  
        /// 执行指定数据库连接对象的命令,指定存储过程参数,返回DataTable  
        /// </summary>  
        /// <param name="type">命令类型(T-Sql语句或者存储过程)</param>  
        /// <param name="safeSql">T-Sql语句或者存储过程的名称</param>  
        /// <param name="values">参数数组</param>  
        /// <returns>结果集DataTable</returns>  
        public static DataTable ExecuteDataTable(CommandType type, string safeSql, params SqlParameter[] values)
        {
            using (SQLiteConnection Connection = new SQLiteConnection(connStr))
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
                DataSet ds = new DataSet();
                SQLiteCommand cmd = new SQLiteCommand(safeSql, Connection);
                cmd.CommandType = type;
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(ds);
                return ds.Tables[0];
            }
        }

        /// <summary>  
        /// 执行指定数据库连接对象的命令,指定存储过程参数,返回DataTable  
        /// </summary>  
        /// <param name="safeSql">T-Sql语句</param>  
        /// <returns>结果集DataTable</returns>  
        public static DataTable ExecuteDataTable(string safeSql)
        {
            using (SQLiteConnection Connection = new SQLiteConnection(connStr))
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
                DataSet ds = new DataSet();
                using (SQLiteCommand cmd = new SQLiteCommand(safeSql, Connection))
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                {
                    try
                    {
                        da.Fill(ds);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                return ds.Tables[0];
            }
        }

        /// <summary>  
        /// 执行指定数据库连接对象的命令,指定存储过程参数,返回DataTable  
        /// </summary>  
        /// <param name="sql">T-Sql语句</param>  
        /// <param name="values">参数数组</param>  
        /// <returns>结果集DataTable</returns>  
        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] values)
        {
            using (SQLiteConnection Connection = new SQLiteConnection(connStr))
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
                DataSet ds = new DataSet();
                SQLiteCommand cmd = new SQLiteCommand(sql, Connection);
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddRange(values);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(ds);
                return ds.Tables[0];
            }
        }
        #endregion

        #region GetDataSet命令
        /// <summary>  
        /// 取出数据  
        /// </summary>  
        /// <param name="safeSql">sql语句</param>  
        /// <param name="tabName">DataTable别名</param>  
        /// <param name="values"></param>  
        /// <returns></returns>  
        public static DataSet GetDataSet(string safeSql, string tabName, params SqlParameter[] values)
        {
            using (SQLiteConnection Connection = new SQLiteConnection(connStr))
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
                DataSet ds = new DataSet();
                SQLiteCommand cmd = new SQLiteCommand(safeSql, Connection);

                if (values != null)
                    cmd.Parameters.AddRange(values);

                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                try
                {
                    da.Fill(ds, tabName);
                }
                catch (Exception ex)
                {

                }
                return ds;
            }
        }
        #endregion

        #region ExecureData 命令
        /// <summary>  
        /// 批量修改数据  
        /// </summary>  
        /// <param name="ds">修改过的DataSet</param>  
        /// <param name="strTblName">表名</param>  
        /// <returns></returns>  
        public static int ExecureData(DataSet ds, string strTblName)
        {
            try
            {
                //创建一个数据库连接  
                using (SQLiteConnection Connection = new SQLiteConnection(connStr))
                {
                    if (Connection.State != ConnectionState.Open)
                        Connection.Open();

                    //创建一个用于填充DataSet的对象  
                    SQLiteCommand myCommand = new SQLiteCommand("SELECT * FROM " + strTblName, Connection);
                    SQLiteDataAdapter myAdapter = new SQLiteDataAdapter();
                    //获取SQL语句，用于在数据库中选择记录  
                    myAdapter.SelectCommand = myCommand;

                    //自动生成单表命令，用于将对DataSet所做的更改与数据库更改相对应  
                    SQLiteCommandBuilder myCommandBuilder = new SQLiteCommandBuilder(myAdapter);

                    return myAdapter.Update(ds, strTblName);  //更新ds数据  
                }

            }
            catch (Exception err)
            {
                throw err;
            }
        }

        #endregion
    }
}
