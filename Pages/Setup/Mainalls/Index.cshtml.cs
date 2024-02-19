//using HRMSApplication.MyHelpers;
using HRMSApplication.Pages.Setup.Gralls;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Numerics;

namespace HRMSApplication.Setup.Mainalls
{
    //[RequireAuth(RequiredRole = "admin")]
    public class IndexModel : PageModel
    {
		public List<Mainallinfo> listMainalls = new List<Mainallinfo>();
		public void OnGet()
        {
			try
			{
				string connectionString = "Data Source=LAPTOP-HTBOKT77;Initial Catalog=HRMS5DBBk;User ID=Arise;Password=2004Bos16..";
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					string sql = "SELECT * FROM AllowanceID ";

					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								Mainallinfo mainallinfo = new Mainallinfo();
								mainallinfo.AllowID = reader.GetInt32(0);
								mainallinfo.AllowName = reader.GetString(1);



								listMainalls.Add(mainallinfo);



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

	public class Mainallinfo
	{
		public int AllowID { get; set; }
		public string AllowName { get; set; } = "";






	}
}
