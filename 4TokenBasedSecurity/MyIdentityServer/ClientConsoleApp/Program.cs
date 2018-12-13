using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClientConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Merhaba Ben Client Uygulamasıyım");

            Console.WriteLine("bir tuşa basınız");
            Console.ReadKey();

            //çağrılan func asyn olduğu için bu şekilde çalıştırıyoruz.
            //clientid si client1 olan client tanımlanıyor.
            //ve bu clientid ile identityserverda scope1 e ait apiler çağrılmak isteniyor.
            GetMyFirstApiAsync().GetAwaiter().GetResult();


            //çağrılan func asyn olduğu için bu şekilde çalıştırıyoruz.
            //clientid si client2 olan client tanımlanıyor.
            //ve bu clientid ile identityserverda scope2 e ait apiler çağrılmak isteniyor.
            GetMySecondApiAsync().GetAwaiter().GetResult();




            Console.WriteLine("çıkmak bir tuşa basınız");
            Console.ReadKey();
        }

        private static async Task GetMyFirstApiAsync()
        {

            Console.WriteLine("MyFirstApi okunuyor");

            var disco = await DiscoveryClient.GetAsync("http://localhost:5000");

            //client: clientid   muratkey: clientsecret oluyor.
            var tokenClient1 = new TokenClient(disco.TokenEndpoint, "client1", "muratkey");
            var tokenResponse1 = await tokenClient1.RequestClientCredentialsAsync("MyFirstApi");

            if (tokenResponse1.IsError)
            {
                Console.WriteLine(tokenResponse1.Error);
                return;
            }

            Console.WriteLine(tokenResponse1.Json);

            var client = new HttpClient();
            client.SetBearerToken(tokenResponse1.AccessToken);

            var response = client.GetAsync("http://localhost:5001/identity");

            if(!response.Result.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Result.IsSuccessStatusCode);
            }else
            {
                var content = await response.Result.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
            }


            Console.WriteLine("MyFirstApi okundu devam etmek bir tuşa basınız");


            Console.WriteLine("=====================================================");
            Console.ReadKey();

        }




        private static async Task GetMySecondApiAsync()
        {

            Console.WriteLine("MySecondApi okunuyor");

            var disco = await DiscoveryClient.GetAsync("http://localhost:5000");

            //client: clientid   muratkey: clientsecret oluyor.
            var tokenClient1 = new TokenClient(disco.TokenEndpoint, "client2", "muratkey");

            //Invalid_Scope dönmeli
            //buranın hata alması gerekiyor çünki client2 identity server da sadece MySecondApi ye yetkili
            var tokenResponse1 = await tokenClient1.RequestClientCredentialsAsync("MyFirstApi");

            if (tokenResponse1.IsError)
            {
                Console.WriteLine(tokenResponse1.Error);
                return;
            }

            Console.WriteLine(tokenResponse1.Json);

            var client = new HttpClient();
            client.SetBearerToken(tokenResponse1.AccessToken);

            var response = client.GetAsync("http://localhost:5002/identity");

            if (!response.Result.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Result.IsSuccessStatusCode);
            }
            else
            {
                var content = await response.Result.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
            }


            Console.WriteLine("MySecondApi okundu devam etmek bir tuşa basınız");
            Console.ReadKey();

        }

    }
}
