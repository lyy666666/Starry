using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using WBSDAL;

namespace WBSBLL
{
    /// <summary>
    /// T类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Genaricity<T>
    {
        /// <summary>
        /// 反射查询分页
        /// </summary>
        /// <param name="name">查询Name</param>
        /// <param name="pageIndex">分页启始值</param>
        /// <param name="pageSize">分页每页显示页数</param>
        /// <param name="sum">输出参数记录总数</param>
        /// <returns></returns>
        public abstract DataTable Select(string name, int pageIndex, int pageSize, int sum);
        /// <summary>
        /// 反射查询全部
        /// </summary>
        /// <param name="TypeName">数据库表名</param>
        /// <returns></returns>
        public static DataTable SelectAll(string TypeName)
        {
            T t = (T)Activator.CreateInstance(typeof(T));
            string sql = $"select * from {TypeName}";
            return DBHelper.ExecSqlDataTable(sql);
        }
        /// <summary>
        /// 反射添加方法
        /// </summary>
        /// <param name="t">Model表</param>
        /// <param name="TypeName">数据库表名</param>
        /// <param name="key">主键</param>
        /// <returns></returns>
        public static int Add(T t, string TypeName, string key)
        {
            PropertyInfo[] processInfo = t.GetType().GetProperties();
            string sql = $"insert into {TypeName} values(";
            string sq = "";
            foreach (PropertyInfo item in processInfo)
            {
                if (item.Name != key)
                {
 	    if (item.GetValue(t) == null)
                    {
                        sq += "'" + "',";
                    }
                    else
                    {
                        sq += "'" + item.GetValue(t).ToString() + "',";
                    }


                }
            }
            sq = sq.Substring(0, sq.Length - 1);
            //sq.TrimEnd();
            sql += sq + ")";
            return DBHelper.ExecSqlResult(sql);
        }
        /// <summary>
        /// 反射修改方法
        /// </summary>
        /// <param name="nodel">Model表</param>
        /// <param name="TypeName">数据库表名</param>
        /// <param name="key">主键</param>
        /// <param name="id">修改的ID</param>
        /// <returns></returns>
        public static int UpData(T nodel, string TypeName, string key, int id)// where T : new()
        {
            //获取Type对象，反射操作基本都是用Type进行的
            Type type = typeof(T);
            string strsql = string.Format("update {0} set ", TypeName);
            //获取Type对象所有公共属性
            PropertyInfo[] info = type.GetProperties();
            string link = "";
            foreach (PropertyInfo item in info)
            {
                if (item.Name != key)
                {


                    object val = item.GetValue(nodel);
                    if (val != null)
                    {
                        //更新修改字段的值
                        strsql += link + item.Name + "='" + val + "'";
                        link = ",";
                    }
                }
                
            }
            strsql += string.Format(" where {0}='{1}'", key, id);
            //调用执行方法
            return DBHelper.ExecSqlResult(strsql);

        }
        /// <summary>
        /// 反射删除方法
        /// </summary>
        /// <param name="TypeName">数据库表名</param>
        /// <param name="key">主键</param>
        /// <param name="id">删除的ID</param>
        /// <returns></returns>
        public static int Delete(string TypeName, string key, string id)// where T : new()
        {
            //获取Type对象，反射操作基本都是用Type进行的
            Type type = typeof(T);
            string strsql = string.Format("delete from  {0} where {1}='{2}'", TypeName, key, id);
            //调用执行方法
            return DBHelper.ExecSqlResult(strsql);

        }
        /// <summary>
        /// 反射查询一条
        /// </summary>
        /// <param name="TypeName">数据库表名</param>
        /// <param name="key">主键</param>
        /// <param name="id">查询的ID</param>
        /// <returns></returns>
        public static DataTable SelectOne(string TypeName, string key, int id)
        {
            T t = (T)Activator.CreateInstance(typeof(T));
            string sql = $"select * from {TypeName} where {key}='{id}'";
            return DBHelper.ExecSqlDataTable(sql);
        }
        /// <summary>
        /// DataTable转List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> DataTableToList(DataTable dt)
        {
            var lst = new List<T>();
            var plist = new List<System.Reflection.PropertyInfo>(typeof(T).GetProperties());
            foreach (DataRow item in dt.Rows)
            {
                T t = System.Activator.CreateInstance<T>();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    PropertyInfo info = plist.Find(p => p.Name == dt.Columns[i].ColumnName);
                    if (info != null)
                    {
                        if (!Convert.IsDBNull(item[i]))
                        {
                            info.SetValue(t, item[i], null);
                        }
                    }
                }
                lst.Add(t);
            }
            return lst;
        }
        /// <summary>
        /// List转DataTable
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static DataTable ListToDataTable(IEnumerable<T> collection)
        {
            var props = typeof(T).GetProperties();
            var dt = new DataTable();
            dt.Columns.AddRange(props.Select(p => new DataColumn(p.Name, p.PropertyType)).ToArray());
            if (collection.Count() > 0)
            {
                for (int i = 0; i < collection.Count(); i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in props)
                    {
                        object obj = pi.GetValue(collection.ElementAt(i), null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    dt.LoadDataRow(array, true);
                }
            }
            return dt;
        }
    }
}