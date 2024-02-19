using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace HRMSApplication.Pages.Setup.Departments
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        [Required]
        public string Code { get; set; } = "";
        [BindProperty]
        [Required]
        public string Name { get; set; } = "";
        [BindProperty]
		[Required]
		public string Remark { get; set; } = "";

		public string errorMessage = "";
		public string successMessage = "";

		public void OnGet()
        {
        }
        public void OnPost()
		{

            try 
            {
                string connectionString = "Data Source=LAPTOP-HTBOKT77;Initial Catalog=HRMS5DBBk;User ID=Arise;Password=2004Bos16..";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO HPayDept" +
                        "(Code, Name , Remark ) VALUES " + "(@Code, @Name, @Remark);";

                    using (SqlCommand command = new SqlCommand(sql, connection)) 
                    {
                        command.Parameters.AddWithValue("Code", Code);
                        command.Parameters.AddWithValue("Name", Name);
                        command.Parameters.AddWithValue("Remark", Remark);

                        command.ExecuteNonQuery();
                    }
                }
            }

            catch (Exception ex)
            {
				errorMessage = ex.Message;
				return;
			}
			successMessage = "Data saved correctly";
			Response.Redirect("/Setup/Departments/Index");
		}
    }
}
