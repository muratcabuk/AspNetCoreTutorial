using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MyIdentityServer
{
    public static class Config
    {

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
           {
               new ApiResource("MyFirstApi","My First Api"),
                new ApiResource("MySecondApi","My Second Api")

           };
        }


        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    //bu clientid yi burada verdiğimiz için, client ında bu id ile bana gelmesi lazım.
                    //developer oratmında zaten startup da AddInMemoryClients kullanmak zorundayız. 
                    //örneğin cep telefonlşarını whatsapp clientid olarak belirli özel verilerle kaydedip sunucuyada bu clientid yi kullanarak çağırıyor.
                    ClientId="client1",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        //apilere bağlamak itediğimizde bir kerelik oluşturulan key burası aslında. 
                        //tekrar oluşturulması gerektiğinde aslında farklı bir key üretilse daha iyi olur
                        new Secret("muratkey".Sha256())

                    },
                    //yukarıdaki ApiResource daki ismlerden birileri gelmeli, birden fazla scope da verilebilir
                    AllowedScopes = { "MyFirstApi", "MySecondApi" }
                },
                 new Client
                {
                    //bu clientid yi burada verdiğimiz için, client ında bu id ile bana gelmesi lazım.
                    //developer oratmında zaten startup da AddInMemoryClients kullanmak zorundayız. 
                    //örneğin cep telefonlşarını whatsapp clientid olarak belirli özel verilerle kaydedip sunucuyada bu clientid yi kullanarak çağırıyor.
                    ClientId="client2",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        //apilere bağlamak itediğimizde bir kerelik oluşturulan key burası aslında. 
                        //tekrar oluşturulması gerektiğinde aslında farklı bir key üretilse daha iyi olur
                        new Secret("muratkey".Sha256())

                    },
                    //yukarıdaki ApiResource ismlerden birileri gelmeli aynı olmalı, birden fazla scope da verilebilir
                    AllowedScopes = { "MySecondApi" }
                },

              new Client
{
    ClientId = "client3",
    ClientName = "JavaScript Client",
    AllowedGrantTypes = GrantTypes.Implicit,
    AllowAccessTokensViaBrowser = true,

    RedirectUris =           { "http://localhost:5003" },
    PostLogoutRedirectUris = { "http://localhost:5003" },
    AllowedCorsOrigins =     { "http://localhost:5003" },
    


    AllowedScopes =
    {
        IdentityServerConstants.StandardScopes.OpenId,
        IdentityServerConstants.StandardScopes.Profile,
        "MyFirstApi"
    }
}




            };
        }
    }
}
