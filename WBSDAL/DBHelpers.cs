using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBSDAL
{
    public class DBHelper
    {
        //连接数据库的字符串（可以通过工具栏-连接数据库获取/也可以通过配置web.config获取）
        /// <summary>
        /// 连接数据库字符串
        /// </summary>
        //static string strConn = "Data Source=DESKTOP-PF3RFAF;Initial Catalog=NewsRelease;Integrated Security=True;pwd=456";
        static string strConn = ConfigurationManager.ConnectionStrings["Conn"].ToString();

        //web.config获取，先添加system.configuration.dll
        //string _webconfig = System.Configuration.ConfigurationSettings.AppSettings["配置名称"];//会提示已过期

        //string _webconfig2 = System.Configuration.ConfigurationManager.AppSettings["配置名称"];


        /// <summary>
        /// 执行添加、修改、删除的SQL语句，返回受影响行数
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns>返回影响行数</returns>
        public static int ExecSqlResult(string strSql)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(strSql, conn);
                int result = command.ExecuteNonQuery();
                conn.Close();
                return result;
            }
        }


        /// <summary>
        /// 执行查询SQL语句，返回DataTable数据集
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns>返回数据集DataTable</returns>
        public static DataTable ExecSqlDataTable(string strSql)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                SqlDataAdapter sqlData = new SqlDataAdapter(strSql, conn);
                DataTable dt = new DataTable();
                sqlData.Fill(dt);

                //释放
                sqlData.Dispose();

                conn.Close();

                return dt;
            }
        }

        /// <summary>
        /// 执行SQL语句，获取首行首列
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns>返回首行首列</returns>
        public static object ExecSqlScalar(string strSql)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(strSql);
                object result = command.ExecuteScalar();
                conn.Close();
                return result;
            }
        }
        #region DataTable转List集合

        /// <summary>
        /// DataTable转List集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> DataTableToList<T>(DataTable dt)
        {
            return JsonConvert.DeserializeObject<List<T>>(JsonConvert.SerializeObject(dt));
        }

        /// <summary>
        /// 执行SqL语句，返回List集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static List<T> DataTableToList<T>(string strSql)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                SqlDataAdapter sqlData = new SqlDataAdapter(strSql, conn);

                DataTable dt = new DataTable();
                sqlData.Fill(dt);
                sqlData.Dispose();
                conn.Close();

                List<T> list = DataTableToList<T>(dt);

                return list;
            }
        }
        #endregion

        #region 执行存储过程

        /// <summary>
        /// 执行存储过程，返回影响行数
        /// </summary>
        /// <param name="ProcName"></param>
        /// <param name="Parms"></param>
        /// <returns></returns>
        public static int ExecProcGetResult(string ProcName, Dictionary<string, object> Parms)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                SqlCommand command = new SqlCommand();
                command.CommandText = ProcName;
                command.CommandType = CommandType.StoredProcedure;
	command.Connection = conn;
                foreach (var item in Parms)
                {
                    SqlParameter parm = new SqlParameter(item.Key, item.Value);
                    command.Parameters.Add(parm);
                }
                int result = command.ExecuteNonQuery();
                conn.Close();

                return result;
            }
        }

        /// <summary>
        /// 执行存储过程返回DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pairs"></param>
        /// <returns></returns>
        public static DataTable ExecSqlGetDataTable(string sql, Dictionary<string, object> pairs)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = sql;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = conn;
                foreach (var item in pairs)
                {
                    command.Parameters.AddWithValue(item.Key, item.Value);
                }
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataAdapter.Dispose();
                conn.Close();
                return dt;
            }
        }





        /// <summary>
        /// 执行存储过程，获取数据集及输出参数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ProcName"></param>
        /// <param name="Parms"></param>
        /// <param name="OutName">@totalcount输出参数</param>
        /// <returns></returns>
        public static List<T> ExecProcGetResult<T>(string ProcName, Dictionary<string, object> Parms, out string OutName)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {

                OutName = "@totalcount";
                conn.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = conn;

                //设置该SQL语句为存储过程
                command.CommandText = ProcName;
                command.CommandType = CommandType.StoredProcedure;

                //循环遍历添加参数
                foreach (var item in Parms)
                {
                    SqlParameter parm = new SqlParameter();

                    parm.ParameterName = item.Key;

                    //判断是不是输出参数
                    if (item.Key.ToLower().Equals(OutName))
                    {
                        parm.Direction = ParameterDirection.Output;
                        parm.Size = 50;
                    }
                    else
                    {
                        parm.Value = item.Value;
                    }
                    command.Parameters.Add(parm);
                }

                //执行command，获取数据集
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataAdapter.Dispose();

                //返回输出参数
                object o = command.Parameters[OutName].Value;
                OutName = o.ToString();

                //关闭连接
                conn.Close();

                return DataTableToList<T>(dt);
            }
        }

        #endregion

    }
}
