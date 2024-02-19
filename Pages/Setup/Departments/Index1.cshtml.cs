using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace HRMSApplication.Pages.Setup.Departments
{
	//[RequireAuth(RequiredRole = "admin")]
	public class Index1Model : PageModel
	{
		public List<DepartmentInfo> listDepartments = new List<DepartmentInfo>();
		public void OnGet()
		{
			try
			{
				string connectionString = "Data Source=LAPTOP-HTBOKT77;Initial Catalog=HRMS5DBBk;User ID=Arise;Password=2004Bos16..";
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					string sql = "SELECT * FROM HPayDept";

					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								DepartmentInfo departmentinfo = new DepartmentInfo();
								departmentinfo.Code = reader.GetString(0);
								departmentinfo.Name = reader.GetString(1);




								listDepartments.Add(departmentinfo);



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

	public class DepartmentInfo
	{
		public string Code { get; set; } = "";
		public string Name { get; set; } = "";







	}
}
