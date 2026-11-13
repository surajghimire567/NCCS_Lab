using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace NCCS_Lab_MVC.Controllers.Api
{
    // Q20: Demonstrates SQL Injection risk vs prevention
    [ApiController]
    [Route("api/[controller]")]
    public class SqlInjectionDemoController : ControllerBase
    {
        private const string ConnStr = "Data Source=nccs_lab.db";

        // VULNERABLE: builds SQL by directly concatenating user input.
        // Input like:  ' OR '1'='1   would return ALL rows, bypassing the filter.
        [HttpGet("vulnerable")]
        public IActionResult Vulnerable(string username)
        {
            using var conn = new SqliteConnection(ConnStr);
            conn.Open();

            // DANGEROUS — do not use in real applications
            string sql = $"SELECT * FROM Users WHERE Username = '{username}'";

            using var cmd = new SqliteCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            var rows = new List<string>();
            while (reader.Read())
                rows.Add(reader["Username"].ToString() ?? "");

            return Ok(new { query = sql, rows });
        }

        // SAFE: uses a parameterized query.
        // The input is always treated as DATA, never as part of the SQL command,
        // so ' OR '1'='1 is matched literally and returns no injected rows.
        [HttpGet("safe")]
        public IActionResult Safe(string username)
        {
            using var conn = new SqliteConnection(ConnStr);
            conn.Open();

            string sql = "SELECT * FROM Users WHERE Username = @username";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@username", username); // parameter, not string-concatenated

            using var reader = cmd.ExecuteReader();

            var rows = new List<string>();
            while (reader.Read())
                rows.Add(reader["Username"].ToString() ?? "");

            return Ok(new { query = sql, rows });
        }
    }
}
