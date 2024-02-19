//using HRMSApplication.MyHelpers;
using HRMSApplication.Pages.Setup.Gralls;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Numerics;

namespace HRMSApplication.Setup.Loans
{
    //[RequireAuth(RequiredRole = "admin")]
    public class IndexModel : PageModel
    {
		public List<Loaninfo> listLoans = new List<Loaninfo>();
		public void OnGet()
        {
			try
			{
				string connectionString = "Data Source=LAPTOP-HTBOKT77;Initial Catalog=HRMS5DBBk;User ID=Arise;Password=2004Bos16..";
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					string sql = "SELECT * FROM LoanType ";

					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								Loaninfo loaninfo = new Loaninfo();
								loaninfo.TypeID = reader.GetInt64(0);
								loaninfo.LoanType = reader.GetString(1);
								loaninfo.LoanRate = reader.GetInt32(2);




								listLoans.Add(loaninfo);



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

	public class Loaninfo
	{
		public BigInteger TypeID { get; set; }
		public string LoanType { get; set; } = "";
		public int LoanRate { get; set; } 







	}
}
