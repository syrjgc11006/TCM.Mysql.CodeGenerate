using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCM.Mysql.CodeGenerate
{
    public class ConstantHelper
    {
        public const string TemplateClassStr1 = @"using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;

    namespace Sandsprite.DbClassGen
    {
	    public class CTemplate
	    {
		    public Dictionary<string, int> Schema; //  \__ so far fastest way to support joins
		    public object[] RawValues;             //  /
		
		    //public members

		    public object GetRaw(string field)
		    {
			    if (Schema.ContainsKey(field)) return RawValues[Schema[field]];
			    return new object();
		    }

		    public CTemplate(IDataReader r, Dictionary<string, int> schema)
		    {
			    Schema = schema;
			    RawValues = new object[r.FieldCount];
			    r.GetValues(RawValues);
			
			    //load members
		
		    }

		//Access function: expects open connection, no error handling 
		/*
		public List<CTemplate> Query_Template(IDbConnection cn, String sql){
			List<CTemplate> ret = new List<CTemplate>();
			IDbCommand cmd = cn.CreateCommand(); 
			cmd.CommandText = sql;
			using(IDataReader r = cmd.ExecuteReader()){
				DataTable schemaTable = r.GetSchemaTable();
				Dictionary<string, int> fields = new Dictionary<string, int>(); 
				int i = 0;
				foreach (DataRow row in schemaTable.Rows)
				{
					try{fields.Add(row[\""ColumnName\""].ToString(), i);}
					catch (Exception e)
					{
						// in case ambiguous column names use SELECT news.id AS newsId, user.id AS userId 
						// we will default to ColumnName_1 for convience... 
						try{fields.Add(row[\""ColumnName\""].ToString() +\""_1\"", i);}
						catch (Exception ex) { //there is a limit to my patience but we could while(1) j++ }
						}
					}
					i++;
				}
				while(r.Read()){
					CTemplate c = new CTemplate(r, fields);
ret.Add(c);
				}
				r.Close();
			}
			return ret;
		}
	}
}
";


        public const string TemplateClassStr = @"
            using System;
            using System.Collections.Generic;
            using System.Linq;
            using System.Text;
            using System.Data;

            namespace TCM.APIService.Model
            {
	            public class Template
	            {
		            //public members
		   

	            }
            }";
    }
}
