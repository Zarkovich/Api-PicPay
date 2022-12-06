using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Services
{
    public record class AuthMessage(
        string Message = null
    );


    public static class RequestMocks
    {
        private static string AuthTransactionUrl = "https://run.mocky.io/";


        public static async Task<bool> GetAuth()
        {
            HttpClient getAuth = new()
            {
                BaseAddress = new Uri(AuthTransactionUrl),
            };

            var response = await getAuth.GetFromJsonAsync<AuthMessage>("v3/8fafdd68-a090-496f-8c9a-3442cf30dae6");

            if (response.Message == "Autorizado") return true;

            return false;

        }
    }
}