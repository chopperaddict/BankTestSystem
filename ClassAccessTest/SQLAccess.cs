using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassAccessTest
{
/*    class SQLException : Exception
    {
        public SQLException(string message);
        
     }
*/
  
    public class SQLAccess
    {
        
        public static bool SQLconnection = false;
//        readonly SqlCommand command;
//        readonly SqlDataReader dataReader;
        // Note the changed location for the database
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ian1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //original locatoin set by M$
        //public static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ianch\source\repos\ClassAccessTest\ClassAccessTest\ian1.mdf;Integrated Security=True;Connect Timeout=30";

        public static SqlConnection cnn;
         //**************************************************************************************************************************************************************************************
        
        public static bool  SQLConnect2()
        //**************************************************************************************************************************************************************************************
        {
            cnn = new SqlConnection(connectionString);
            try
            {
                cnn.Open();
                SQLAccess.SQLconnection = true;
                string login = cnn . ConnectionString;
                return true;
            }
            catch
            {
                Bank . form1 . Output2 . AppendText ( "SQL connection encountered a problem");
                //throw new ESqlNotificationInfo();
                return false;
            }                
        }
        //**************************************************************************************************************************************************************************************
        public static void SQLDisConnect2()
        //**************************************************************************************************************************************************************************************
        { 
            try
            {   cnn.Close();
                SQLAccess.SQLconnection = false;
            }
            catch { new Exception (" Failed to disconnect form SQL Server" ); }
        }
    }
}
