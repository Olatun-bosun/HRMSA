//using HRMSApplication.MyHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Numerics;

namespace HRMSApplication.Setup.Cadres
{
    //[RequireAuth(RequiredRole = "admin")]
    public class IndexModel : PageModel
    {
        public List<Cadreinfo> listCadres = new List<Cadreinfo>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=LAPTOP-HTBOKT77;Initial Catalog=HRMS5DBBk;User ID=Arise;Password=2004Bos16..";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM TrainingCadres ";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Cadreinfo cadreinfo = new Cadreinfo();
                              cadreinfo.Code = reader.GetString(0);            
                              cadreinfo.Name = reader.GetString(1);
                              cadreinfo.Remarks = reader.GetString(2);
                              
                               

                                listCadres.Add(cadreinfo);
                                


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

    public class Cadreinfo
    {
        public string Code { get; set; } = "";
        public string Name { get; set; } = "";
        public string Remarks { get; set; } = "";
       
       




    }
}
