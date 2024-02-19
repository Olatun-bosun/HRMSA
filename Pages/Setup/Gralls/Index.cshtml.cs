//using HRMSApplication.MyHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Numerics;

namespace HRMSApplication.Setup.Gralls
{
    //[RequireAuth(RequiredRole = "admin")]
    public class IndexModel : PageModel
    {
        public List<Grallinfo> listGralls = new List<Grallinfo>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=LAPTOP-HTBOKT77;Initial Catalog=HRMS5DBBk;User ID=Arise;Password=2004Bos16..";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM HPayAllowance ";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Grallinfo grallinfo = new Grallinfo();
								grallinfo.HID = reader.GetInt64(0);

								//grallinfo.AllowID = reader.GetInt64(1);            
                             grallinfo.AllowName = reader.GetString(1);
                             grallinfo.Value1 = reader.GetInt32(2);
                             grallinfo.Steps = reader.GetString(3);
								grallinfo.GradeID = reader.GetInt64(4);

								grallinfo.Grade = reader.GetString(5);



                                listGralls.Add(grallinfo);
                                


                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public class Grallinfo
    {
		public BigInteger HID { get; set; }

		//public BigInteger AllowID { get; set; } 
        public string AllowName { get; set; } = "";
        public int Value1 { get; set; }
        public string Steps { get; set; } = "";
		public BigInteger GradeID { get; set; }

		public string Grade { get; set; } = "";





    }
}
