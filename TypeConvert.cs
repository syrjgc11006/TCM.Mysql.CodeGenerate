using SchemaExplorer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCM.Mysql.CodeGenerate
{
    public class TypeConvert
    {
        public static string CSharpType(ColumnSchema column)
        {
            if (column.Name.EndsWith("TypeCode"))
                return column.Name;
            string backtye = "";
            if (column.AllowDBNull)
            {
                backtye = "?";
            }
            switch (column.DataType)
            {
                case DbType.AnsiString:
                case DbType.String:
                    return "string";
                case DbType.Binary:
                    return "byte[]";
                case DbType.Boolean:
                    return "bool" + backtye;
                case DbType.Date:
                case DbType.DateTime:
                case DbType.Time:
                    return "DateTime" + backtye;
                case DbType.Byte:
                case DbType.Int16:
                case DbType.Int32:
                case DbType.Int64:
                case DbType.UInt16:
                case DbType.UInt32:
                case DbType.UInt64:
                    return "int" + backtye;
                case DbType.Currency:
                case DbType.VarNumeric:
                case DbType.Decimal:
                    return "decimal" + backtye;
                case DbType.Double:
                    return "double" + backtye;
                case DbType.Guid:
                    return "Guid" + backtye;

                default:
                    return "object";
            }
        }
    }
}
