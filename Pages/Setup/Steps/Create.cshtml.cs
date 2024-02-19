using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Numerics;

namespace HRMSApplication.Pages.Setup.Steps
{
    public class CreateModel : PageModel
    {
       
        [BindProperty]
        [Required]
        public string Name { get; set; } = "";
        [BindProperty]
		[Required]
		public string Remarks { get; set; } = "";

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
                    string sql = "INSERT INTO HRSteps" +
                        "( Name , Remarks ) VALUES " + "( @Name, @Remarks);";

                    using (SqlCommand command = new SqlCommand(sql, connection)) 
                    {
                        command.Parameters.AddWithValue("Name", Name);
                        command.Parameters.AddWithValue("Remarks", Remarks);

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
			Response.Redirect("/Setup/Steps/Index");
		}
    }
}
