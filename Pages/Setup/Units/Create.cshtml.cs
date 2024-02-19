using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace HRMSApplication.Pages.Setup.Units
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        [Required]
        public string Code { get; set; } = "";
        [BindProperty]
        [Required]
        public string Section { get; set; } = "";
        [BindProperty]
		[Required]
		public string Description { get; set; } = "";

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
                    string sql = "INSERT INTO HPaySection" +
                        "(Code, Section , Description ) VALUES " + "(@Code, @Section, @Description);";

                    using (SqlCommand command = new SqlCommand(sql, connection)) 
                    {
                        command.Parameters.AddWithValue("Code", Code);
                        command.Parameters.AddWithValue("Section", Section);
                        command.Parameters.AddWithValue("Description", Description);

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
			Response.Redirect("/Setup/Units/Index");
		}
    }
}
