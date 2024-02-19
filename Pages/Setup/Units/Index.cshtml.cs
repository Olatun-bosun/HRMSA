//using HRMSApplication.MyHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Numerics;

namespace HRMSApplication.Setup.Units
{
    //[RequireAuth(RequiredRole = "admin")]
    public class IndexModel : PageModel
    {
        public List<Unitinfo> listEmployees = new List<Unitinfo>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=LAPTOP-HTBOKT77;Initial Catalog=HRMS5DBBk;User ID=Arise;Password=2004Bos16..";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM HPaySection ";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Unitinfo unitinfo = new Unitinfo();
                                unitinfo.Code = reader.GetString(0);            
                                unitinfo.Section = reader.GetString(1);
                                
                               

                                listEmployees.Add(unitinfo);
                                


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

    public class Unitinfo
    {
        public string Code { get; set; } = "";
        public string Section { get; set; } = "";
        
       




    }
}
