//using HRMSApplication.MyHelpers;
using HRMSApplication.Pages.Setup.Gralls;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Numerics;

namespace HRMSApplication.Setup.Maindeds
{
    //[RequireAuth(RequiredRole = "admin")]
    public class IndexModel : PageModel
    {
		public List<Maindedinfo> listMaindeds = new List<Maindedinfo>();
		public void OnGet()
        {
			try
			{
				string connectionString = "Data Source=LAPTOP-HTBOKT77;Initial Catalog=HRMS5DBBk;User ID=Arise;Password=2004Bos16..";
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					string sql = "SELECT * FROM DeductionID ";

					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								Maindedinfo maindedinfo = new Maindedinfo();
								maindedinfo.DedID = reader.GetInt64(0);
								maindedinfo.DedName = reader.GetString(1);



								listMaindeds.Add(maindedinfo);



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

	public class Maindedinfo
	{
		public BigInteger DedID { get; set; }
		public string DedName { get; set; } = "";






	}
}
