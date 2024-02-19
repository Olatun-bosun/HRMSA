//using HRMSApplication.MyHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Numerics;

namespace HRMSApplication.Admin.Employees
{
    //[RequireAuth(RequiredRole = "admin")]
    public class IndexModel : PageModel
    {
        public List<Employeeinfo> listEmployees = new List<Employeeinfo>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=LAPTOP-HTBOKT77;Initial Catalog=HRMS5DBBk;User ID=Arise;Password=2004Bos16..";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM HREmployees ";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Employeeinfo employeeinfo = new Employeeinfo();
                                employeeinfo.EmployeeID = reader.GetString(0);            
                                employeeinfo.StaffIDNo = reader.GetString(1);
                                employeeinfo.Title = reader.GetString(2);
                                employeeinfo.Surname = reader.GetString(3);
                                employeeinfo.OtherNames = reader.GetString(4);
                               

                                listEmployees.Add(employeeinfo);
                                


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

    public class Employeeinfo
    {
        public string EmployeeID { get; set; } = "";
        public string StaffIDNo { get; set; } = "";
        public string Title { get; set; } = "";
        public string Surname { get; set; } = "";
        public string OtherNames { get; set; } = "";
       




    }
}
