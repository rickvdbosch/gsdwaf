using System.Data.SqlClient;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace managed_identity_example
{
    public static class ConnectToSQL
    {
        #region Constants

        private const string CONNECTIONSTRING = "Server=tcp:<YOUR_SERVER_NAME>.database.windows.net,1433;Initial Catalog=<YOUR_DATABASE_NAME>;";
        private const string QUERY = "<YOUR_SQL_QUERY>";
        // TENANT_ID can both be the Directory ID (GUID) or the 'xxx.onmicrosoft.com' name of the tenant.
        private const string TENANT_ID = "<YOUR_TENANT_ID>";

        #endregion

        [FunctionName("ConnectToSQL")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            using (var connection = new SqlConnection(CONNECTIONSTRING))
            using (var command = new SqlCommand(QUERY, connection))
            {
                connection.AccessToken = await new AzureServiceTokenProvider().GetAccessTokenAsync("https://database.windows.net/");
                await connection.OpenAsync();
                var result = (await command.ExecuteScalarAsync()).ToString();

                return new OkObjectResult(result);
            }
        }
    }
}
