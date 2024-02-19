using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace HRMSApplication.Pages.Setup.Mainalls
{
    public class CreateModel : PageModel
    {
        
        [BindProperty]
        [Required]
        public string AllowName { get; set; } = "";
        
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
                    string sql = "INSERT INTO AllowanceID" +
                        "( AllowName ) VALUES " + "(@AllowName);";

                    using (SqlCommand command = new SqlCommand(sql, connection)) 
                    {
                        command.Parameters.AddWithValue("AllowName", AllowName);

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
			Response.Redirect("/Setup/Mainalls/Index");
		}
    }
}
