// using System;
// using System.Data.SqlClient;
// using System.Net.Http;
// using System.Threading.Tasks;

// class Program
// {
//     static async Task Main(string[] args)
//     {
//         Console.WriteLine("Iniciando automação...");

//         string connectionString = "Sua_Connection_String";
//         string query = "SELECT UserId, KeycloakId FROM Users WHERE KeycloakId IS NULL";

//         using (SqlConnection conn = new SqlConnection(connectionString))
//         {
//             await conn.OpenAsync();

//             using (SqlCommand cmd = new SqlCommand(query, conn))
//             using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
//             {
//                 while (await reader.ReadAsync())
//                 {
//                     string userId = reader["UserId"].ToString();

//                     // Simulando a request para obter o KeycloakId
//                     string keycloakId = await GetKeycloakIdFromAPI(userId);

//                     // Atualiza o campo KeycloakId
//                     if (!string.IsNullOrEmpty(keycloakId))
//                     {
//                         UpdateKeycloakId(userId, keycloakId, conn);
//                     }
//                 }
//             }
//         }

//         Console.WriteLine("Automação finalizada.");
//     }

//     static async Task<string> GetKeycloakIdFromAPI(string userId)
//     {
//         using (HttpClient client = new HttpClient())
//         {
//             // Aqui você faria a request para a API externa
//             string url = $"https://api.exemplo.com/users/{userId}/keycloakid";
//             HttpResponseMessage response = await client.GetAsync(url);

//             if (response.IsSuccessStatusCode)
//             {
//                 return await response.Content.ReadAsStringAsync(); // Simulação do retorno do KeycloakId
//             }

//             return null;
//         }
//     }

//     static void UpdateKeycloakId(string userId, string keycloakId, SqlConnection conn)
//     {
//         string updateQuery = "UPDATE Users SET KeycloakId = @KeycloakId WHERE UserId = @UserId";
//         using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
//         {
//             cmd.Parameters.AddWithValue("@KeycloakId", keycloakId);
//             cmd.Parameters.AddWithValue("@UserId", userId);
//             cmd.ExecuteNonQuery();
//         }
//     }
// }
