using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace managed_identity_example
{
    public static class ConnectToKeyVault
    {
        #region Constants

        // Name of the secret to get from Key Vault
        private const string SECRET_NAME = "<YOUR_SECRET'S_NAME>";

        // The URL to the Key Vault to get the secret from
        private const string VAULT_URL = "https://<YOUR_VAULT'S_NAME>.vault.azure.net/";

        #endregion

        [FunctionName("ConnectToKeyVault")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var tokenProvider = new AzureServiceTokenProvider();
            using (var kvc = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(tokenProvider.KeyVaultTokenCallback)))
            {
                var secret = await kvc.GetSecretAsync(VAULT_URL, SECRET_NAME);
                Console.WriteLine($"The value of the secret we got from Key Vault: {secret.Value}");

                return new OkObjectResult(secret.Value);
            }
        }
    }
}