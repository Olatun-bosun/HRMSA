//using HRMSApplication.MyHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Numerics;

namespace HRMSApplication.Setup.Grades
{
    //[RequireAuth(RequiredRole = "admin")]
    public class IndexModel : PageModel
    {
        public List<Gradeinfo> listGrades = new List<Gradeinfo>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=LAPTOP-HTBOKT77;Initial Catalog=HRMS5DBBk;User ID=Arise;Password=2004Bos16..";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
					connection.Open();

					string sql = "SELECT * FROM GradeLevel ";

					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								Gradeinfo gradeinfo = new Gradeinfo();
								gradeinfo.ID = reader.GetInt32(0);
								gradeinfo.GradeName = reader.GetString(1);



								listGrades.Add(gradeinfo);


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

	public class Gradeinfo
	{
		public int ID { get; set; }
		public string GradeName { get; set; } = "";






	}
}
