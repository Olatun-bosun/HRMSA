//using HRMSApplication.MyHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Numerics;

namespace HRMSApplication.Setup.Steps
{
    //[RequireAuth(RequiredRole = "admin")]
    public class IndexModel : PageModel
    {
        public List<Stepinfo> listSteps = new List<Stepinfo>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=LAPTOP-HTBOKT77;Initial Catalog=HRMS5DBBk;User ID=Arise;Password=2004Bos16..";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM HRSteps ";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Stepinfo stepinfo = new Stepinfo();
                               stepinfo.ID = reader.GetInt32(0);            
                               stepinfo.Name = reader.GetString(1);
                               stepinfo.Remarks = reader.GetString(2);
                              
                               

                                listSteps.Add(stepinfo);
                                


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

    public class Stepinfo
    {
        public int ID { get; set; } 
        public string Name { get; set; } = "";
        public string Remarks { get; set; } = "";
       
       




    }
}
