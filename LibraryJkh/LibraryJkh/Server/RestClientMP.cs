using System.Net;
using System.Threading.Tasks;
using LibraryJkh.Server.RequestModel;
using RestSharp;

namespace LibraryJkh.Server
{
    public class RestClientMP
    {
        public async Task<LoginResult> LoginDispatcher(string login, string password)
        {
            var apiUrl = "https://api.sm-center.ru/test_erc_udm";
            RestClient restClientMp = new RestClient(apiUrl);
            RestRequest restRequest = new RestRequest("auth/loginDispatcher", Method.POST);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddBody(new
            {
                login,
                password,
            });
            var response = await restClientMp.ExecuteTaskAsync<LoginResult>(restRequest);
            // Проверяем статус
            if(response.StatusCode != HttpStatusCode.OK)
            {
                return new LoginResult()
                {
                    Error = $"Ошибка {response.StatusDescription}"
                };
            }
            
            return response.Data;
        }
        public async Task<LoginResult> Login(string phone , string password)
        {
            var apiUrl = "https://api.sm-center.ru/test_erc_udm";
            RestClient restClientMp = new RestClient(apiUrl);
            RestRequest restRequest = new RestRequest("auth/Login", Method.POST);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddBody(new
            {
                phone ,
                password,
            });
            var response = await restClientMp.ExecuteTaskAsync<LoginResult>(restRequest);
            // Проверяем статус
            if(response.StatusCode != HttpStatusCode.OK)
            {
                return new LoginResult()
                {
                    Error = $"Ошибка {response.StatusDescription}"
                };
            }
            
            return response.Data;
        }
    }
}