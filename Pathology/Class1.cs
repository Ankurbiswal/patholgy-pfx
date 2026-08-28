using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Pathology
{
    class Class1
    {
        public SqlConnection con;

        public String arun_con()
        {
            // Reads from App.config <connectionStrings> section.
            // To change server/database, edit Pathology.exe.config in the app folder — no recompile needed.
            string cs = ConfigurationManager.ConnectionStrings["PathologyDB"]?.ConnectionString;
            if (!string.IsNullOrEmpty(cs))
                return cs;

            // Fallback if config file is missing
            return "Data Source=.\\sqlexpress;Initial Catalog=pathology2627;Persist Security Info=True;User ID=sa;Password=software;";
        }
    }
}
