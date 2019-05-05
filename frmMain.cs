using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using SchemaExplorer;

namespace TCM.Mysql.CodeGenerate
{
    public partial class frmMain : Form
    {
        MySQLSchemaProvider mySQLSchemaProvider = new MySQLSchemaProvider();
        string connectstr = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            try
            {
              
                string dbname = mySQLSchemaProvider.GetDatabaseName(connectstr);

                DatabaseSchema databaseSchema = new DatabaseSchema(mySQLSchemaProvider, connectstr);

                //获取所有表
                TableSchema[] tableSchemas = mySQLSchemaProvider.GetTables(connectstr, databaseSchema);

                lv_tables.View = View.List;
                foreach (var item in tableSchemas)
                {
                    ListViewItem viewItem = new ListViewItem { Text = item.Name };
                    lv_tables.Items.Add(viewItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                // throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void lv_tables_DoubleClick(object sender, EventArgs e)
        {
            string selectedTable = lv_tables.SelectedItems[0].Text;  //选中的表
            DatabaseSchema databaseSchema = new DatabaseSchema(mySQLSchemaProvider, connectstr);
            TableSchema tableSchema = new TableSchema(databaseSchema, selectedTable, "dbo",DateTime.Now);
            ColumnSchema[] columnSchemas= mySQLSchemaProvider.GetTableColumns(connectstr, tableSchema);

            //方法一：
            //string[] members = new string[columnSchemas.Length];
            // string[] loaders = new string[columnSchemas.Length];

            //for (int i = 0; i < columnSchemas.Length; i++)
            //{
            //    //columnSchemas[i].Description
            //   // members[i] = @"\t\t /// <summary> ///[Summary]/// </summary>";
            //    members[i] += "\t\tpublic [TYPE] [NAME] {get;set;}";
            //    loaders[i] = "\t\t\tif(r[\"[NAME]\"].GetType().ToString() != \"System.DBNull\") [NAME] = ([TYPE])r[\"[NAME]\"];";
            //    members[i] = members[i].Replace("[TYPE]", CSharpType(columnSchemas[i])).Replace("[NAME]", columnSchemas[i].Name);
            //    loaders[i] = loaders[i].Replace("[TYPE]", CSharpType(columnSchemas[i])).Replace("[NAME]", columnSchemas[i].Name);
            //}

            //string tmp = ConstantHelper.TemplateClassStr.Replace("Template", selectedTable);
            //tmp = tmp.Replace("//public members", "\r\n" + string.Join("\r\n", members));
            //tmp = tmp.Replace("//load members", "\r\n" + string.Join("\r\n", loaders));

            //rtClass.Text = tmp;
            //int i = 0;
            //foreach (ColumnSchema in columnSchemas)
            //{
            //    members[i] = "\t\tpublic [TYPE] [NAME];";
            //    loaders[i] = "\t\t\tif(r[\"[NAME]\"].GetType().ToString() != \"System.DBNull\") [NAME] = ([TYPE])r[\"[NAME]\"];";

            //    members[i] = members[i].Replace("[TYPE]", entry.Value).Replace("[NAME]", entry.Key);
            //    loaders[i] = loaders[i].Replace("[TYPE]", entry.Value).Replace("[NAME]", entry.Key);
            //    i++;
            //}s

            //string tmp = template.Replace("Template", tableName);
            //tmp = tmp.Replace("//public members", "\r\n" + string.Join("\r\n", members));
            //tmp = tmp.Replace("//load members", "\r\n" + string.Join("\r\n", loaders));

            //MessageBox.Show(lv_tables.SelectedItems.ToString());

            //RuntimeTextTemplate1 runtimeTextTemplate1 = new RuntimeTextTemplate1();
            //rtClass.Text= runtimeTextTemplate1.TransformText();

            label1.Visible = true;
            //方法二：
            var template = Activator.CreateInstance<RuntimeTextTemplate1>();

            template.Session = new Microsoft.VisualStudio.TextTemplating.TextTemplatingSession();
            template.Session["tableName"] = selectedTable;
            template.Session["Columns"] = columnSchemas;
            template.Initialize();
            rtClass.Text = template.TransformText();
            label1.Visible = false;
        }

        public string CSharpType(ColumnSchema column)
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
