﻿using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;

namespace WebApplication2
{
    /// <summary>
    /// SQLSERVER助手类
    /// </summary>
    public class DBHelper
    {
        private string connectionString;

        public DBHelper()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["websiteConnectionStringHome"].ConnectionString;
        }
        public DBHelper(string connString)
        {
            this.connectionString = connString;
        }
        /// <summary>
        /// 返回数据库null类型
        /// </summary>
        /// <param name="parms"></param>
        public void get_db_para_value(SqlParameter[] parms)
        {
            foreach (var item in parms)
            {
                if (item.Value == null || (item.SqlDbType == SqlDbType.NText && string.IsNullOrEmpty(item.Value.ToString())))
                    item.Value = DBNull.Value;
            }
        }
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectionString
        {
            get { return this.connectionString; }
        }

        /// <summary>
        /// 释放连接
        /// </summary>
        public void Dispose()
        {

        }

        public string GetRole(string username)
        {
            string role = null;
            string sql = "select rolemode from login where username=@username";
            SqlParameter[] paras = { new SqlParameter("@username", SqlDbType.NVarChar) { Value = username } };
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddRange(paras);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    role = reader["rolemode"].ToString();
                    return role;
                }
                else
                    return null;
            }
        
        }

        /// <summary>
        /// 得到一个SqlDataReader
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public SqlDataReader GetDataReader(string sql)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Prepare();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }

        /// <summary>
        /// 得到一个SqlDataReader
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public SqlDataReader GetDataReader(string sql, SqlParameter[] parameter)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (parameter != null && parameter.Length > 0)
                    cmd.Parameters.AddRange(parameter);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                cmd.Prepare();
                return dr;
            }
        }

        /// <summary>
        /// 得到一个DataTable
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dr.Close();
                    dr.Dispose();
                    cmd.Prepare();
                    return dt;
                }
            }
        }

        /// <summary>
        /// 得到一个DataTable
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql, SqlParameter[] parameter)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameter != null && parameter.Length > 0)
                        cmd.Parameters.AddRange(parameter);
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dr.Close();
                    dr.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Prepare();
                    return dt;
                }
            }
        }
        /// <summary>
        /// 数据批量导入 DataTable方式写入数据,resData源数据
        /// </summary>
        /// <param name="resData"></param>
        /// <param name="server_Connect"></param>
        /// <param name="desTable"></param>
        public void dataTableCopy(DataTable resData, String desTable, ref string error)
        {
            error = "0";
            if (resData == null || resData.Equals(null))
            {
                error = "源数据为空";
                return;
            }
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlTransaction sqlbulkTransaction = conn.BeginTransaction();
            ////允许自增
            SqlBulkCopy sqlbulkcopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.KeepIdentity, sqlbulkTransaction);
            try
            {
                //请在插入数据的同时检查约束，如果发生错误调用sqlbulkTransaction事务
                sqlbulkcopy.DestinationTableName = desTable;//数据库中的表名

                for (int i = 0; i < resData.Columns.Count; i++)
                {
                    //列映射
                    sqlbulkcopy.ColumnMappings.Add(resData.Columns[i].ColumnName, resData.Columns[i].ColumnName);
                }
                sqlbulkcopy.WriteToServer(resData);//源数据
                sqlbulkTransaction.Commit();
                sqlbulkcopy.Close();
            }
            catch (Exception ex)
            {
                sqlbulkTransaction.Rollback();
                error = ex.ToString();
            }
            finally
            {
                //sqlbulkcopy.Close();
            }
        }
        
        /// <summary>
        /// 得到数据集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet GetDataSet(string sql)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlDataAdapter dap = new SqlDataAdapter(sql, conn))
                {
                    DataSet ds = new DataSet();
                    dap.Fill(ds);
                    return ds;
                }
            }
        }

        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int Execute(string sql)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Prepare();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 执行SQL(事务)
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int Execute(List<string> sqlList)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    int i = 0;
                    cmd.Connection = conn;
                    foreach (string sql in sqlList)
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = sql;
                        cmd.Prepare();
                        i += cmd.ExecuteNonQuery();
                    }
                    return i;
                }
            }
        }

        /// <summary>
        /// 执行带参数的SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public int Execute(string sql, SqlParameter[] parameter)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameter != null && parameter.Length > 0)
                        cmd.Parameters.AddRange(parameter);
                    int i = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    cmd.Prepare();
                    return i;
                }
            }
        }

        /// <summary>
        /// 执行SQL(事务)
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int Execute(List<string> sqlList, List<SqlParameter[]> parameterList)
        {
            if (sqlList.Count > parameterList.Count)
            {
                throw new Exception("参数错误");
            }
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    int i = 0;
                    cmd.Connection = conn;
                    for (int j = 0; j < sqlList.Count; j++)
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = sqlList[j];
                        if (parameterList[j] != null && parameterList[j].Length > 0)
                        {
                            cmd.Parameters.AddRange(parameterList[j]);
                        }
                        i += cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        cmd.Prepare();
                    }
                    return i;
                }
            }
        }

        /// <summary>
        /// 得到一个字段的值
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public string ExecuteScalar(string sql)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    object obj = cmd.ExecuteScalar();
                    cmd.Prepare();
                    return obj != null ? obj.ToString() : string.Empty;
                }
            }
        }

        /// <summary>
        /// 得到一个字段的值
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public string ExecuteScalar(string sql, SqlParameter[] parameter)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameter != null && parameter.Length > 0)
                        cmd.Parameters.AddRange(parameter);
                    object obj = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    cmd.Prepare();
                    return obj != null ? obj.ToString() : string.Empty;
                }
            }
        }
        /// <summary>
        /// 得到一个字段的值
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public string GetFieldValue(string sql)
        {
            return ExecuteScalar(sql);
        }
        /// <summary>
        /// 得到一个字段的值
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public string GetFieldValue(string sql, SqlParameter[] parameter)
        {
            return ExecuteScalar(sql, parameter);
        }

        /// <summary>
        /// 获取一个sql的字段名称
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public string GetFields(string sql, SqlParameter[] param)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                System.Text.StringBuilder names = new System.Text.StringBuilder(500);
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (param != null && param.Length > 0)
                        cmd.Parameters.AddRange(param);
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SchemaOnly);
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        names.Append("[" + dr.GetName(i) + "]" + (i < dr.FieldCount - 1 ? "," : string.Empty));
                    }
                    cmd.Parameters.Clear();
                    dr.Close();
                    dr.Dispose();
                    cmd.Prepare();
                    return names.ToString();
                }
            }
        }

       public string[] getReaderFields(string sql, SqlParameter[] param)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();              
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (param != null && param.Length > 0)
                        cmd.Parameters.AddRange(param);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        int fieldcount = dr.FieldCount;
                        string[] array = new string[fieldcount];
                        for (int i = 0; i < fieldcount; i++)
                        {
                            array[i] = dr[i].ToString();
                        }
                        cmd.Parameters.Clear();
                        dr.Close();
                        dr.Dispose();
                        cmd.Prepare();
                        return array;
                    }
                    else
                        return null;
                }
            }
        
        
        }

        /// <summary>
        /// 获取一个sql的字段名称
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="tableName">表名 </param>
        /// <returns></returns>
        public string GetFields(string sql, SqlParameter[] param, out string tableName)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                System.Text.StringBuilder names = new System.Text.StringBuilder(500);
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (param != null && param.Length > 0)
                        cmd.Parameters.AddRange(param);
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SchemaOnly);
                    tableName = dr.GetSchemaTable().TableName;
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        names.Append("[" + dr.GetName(i) + "]" + (i < dr.FieldCount - 1 ? "," : string.Empty));
                    }
                    cmd.Parameters.Clear();
                    dr.Close();
                    dr.Dispose();
                    cmd.Prepare();
                    return names.ToString();
                }
            }
        }

        /// <summary>
        /// 得到分页sql
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public string GetPaerSql(string sql, int size, int number, out long count, SqlParameter[] param = null)
        {
            string count1 = GetFieldValue(string.Format("select count(*) from ({0}) as PagerCountTemp", sql), param);
            //long i;
            count = int.Parse(count1);

            StringBuilder sql1 = new StringBuilder();
            sql1.Append("select * from (");
            sql1.Append(sql);
            sql1.AppendFormat(") as PagerTempTable");
            if (count > size)
            {
                sql1.AppendFormat(" where PagerAutoRowNumber between {0} and {1}", number * size - size + 1, number * size);
            }
            return sql1.ToString();
        }

        /// <summary>
        /// 得到分页sql
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
    //    public string GetPaerSql(string table, string fileds, string where, string order, int size, int number, out long count, SqlParameter[] param = null)
    //    {
    //        string where1 = string.Empty;
    //        if (where.IsNullOrEmpty())
    //        {
    //            where1 = "";
    //        }
    //        else
    //        {
    //            where1 = where.Trim();
    //            if (where1.StartsWith("and", StringComparison.CurrentCultureIgnoreCase))
    //            {
    //                where1 = where1.Substring(3);
    //            }
    //        }
    //        string where2 = where1.IsNullOrEmpty() ? "" : "where " + where1;
    //        string sql = string.Format("select {0},ROW_NUMBER() OVER(ORDER BY {1}) as PagerAutoRowNumber from {2} {3}", fileds, order, table, where2);


    //        string count1 = GetFieldValue(string.Format("select count(*) from {0} {1}", table, where2), param);
    //        long i;
    //        count = count1.IsLong(out i) ? i : 0;

    //        StringBuilder sql1 = new StringBuilder();
    //        sql1.AppendFormat("select {0} from (", fileds.IsNullOrEmpty() ? "*" : fileds);
    //        sql1.Append(sql);
    //        sql1.AppendFormat(") as PagerTempTable");
    //        if (count > size)
    //        {
    //            sql1.AppendFormat(" where PagerAutoRowNumber between {0} and {1}", number * size - size + 1, number * size);
    //        }

    //        return sql1.ToString();
    //    }
    }
}
