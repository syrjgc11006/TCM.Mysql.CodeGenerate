using SchemaExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TCM.Mysql.CodeGenerate
{
    public class CodeHelper
    {
        public static string[] GetSqlInsertInto(ColumnSchema[] columns)
        {
            List<string> propertyNameList = new List<string>();
            foreach (ColumnSchema property in columns)
            {
                if (property.IsPrimaryKeyMember && property.Name.ToLower() == "id")
                {
                    continue;
                }
                propertyNameList.Add(property.Name);
            }
            return propertyNameList.ToArray();
        }
        public static string[] GetSqlInsertValue(ColumnSchema[] columns)
        {
            List<string> propertyNameList = new List<string>();
            foreach (ColumnSchema property in columns)
            {
                if (property.IsPrimaryKeyMember && property.Name.ToLower() == "id")
                {
                    continue;
                }
                propertyNameList.Add("@" + property.Name);
            }
            return propertyNameList.ToArray();
        }

        public static string[] GetSqlUpdateSet(ColumnSchema[] columns)
        {
            List<string> propertyList = new List<string>();
            foreach (ColumnSchema property in columns)
            {
                propertyList.Add(property.Name + "=@" + property.Name);
            }
            return propertyList.ToArray();
        }

        public static string[] GetSqlWhereId(ColumnSchema[] columns)
        {
            List<string> propertyList = new List<string>();
            foreach (ColumnSchema property in columns)
            {
                if (property.IsPrimaryKeyMember)
                {
                    propertyList.Add(property.Name + "=@" + property.Name);
                }
            }
            return propertyList.ToArray();
        }

        public static string[] GetSqlSelect(ColumnSchema[] columns)
        {
            List<string> propertyList = new List<string>();
            foreach (ColumnSchema property in columns)
            {
                propertyList.Add(property.Name);
            }
            return propertyList.ToArray();
        }
    }
}
