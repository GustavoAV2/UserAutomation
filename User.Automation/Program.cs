using Microsoft.Data.SqlClient;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Iniciando automação...");

        var connectionString = "";
        var keycloakUrl = "";
        var query = "";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            
            using (SqlCommand cmd = new SqlCommand(query, connection))
            using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    Console.WriteLine($"UserId: {reader["UserId"]}, KeycloakId: {reader["KeycloakId"]}");
                }
            }
        }

        Console.WriteLine("Automação finalizada.");
    }
}
