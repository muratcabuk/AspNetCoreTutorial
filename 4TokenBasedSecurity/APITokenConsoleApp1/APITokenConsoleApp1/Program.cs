using Microsoft.IdentityModel.Tokens;
using System;
using System.IO;
using System.Security.Cryptography;

namespace APITokenConsoleApp1
{

    //Manuel olrak kendimiz token ürettik
    //secretkey kullanılarak JWT din diğer ilk iki partı kullanılarak imza oluşturuluyor.
    //böylece herhangi bir şey payload da veya header da değişirse imza değişir.
    //zaten biz illaki header ve payload kısmına unique veriler koyduğumuz için imza her kişide farklı olacaktır.

    // jwt.io sayfasında encode decode kısmından test edilebilir.
    //decode kısmında hehangi bir veri değiştirildiğinde zaten imza da değişmiş olacak görülebilir.
    //burada bir daha yazmadık test kodunu
    //gelen JWT string çevrildikten sonra değişiklik yapılıp tekrar token üretilirse imza (sign) değiştiği görülebilir.
    class Program
    {

        static string JWT=string.Empty;
        static string mySecretKey= "muratkey";
        static string controlKey = string.Empty;

        static void Main(string[] args)
        {
            GenerateJWT();
            Console.WriteLine("==============================================================");
            DecodeJWT(JWT);
        }



        private static void DecodeJWT(string jwt)
        {
            var splitJWTArray = jwt.Split('.');

            var headerBase64 = splitJWTArray[0];
            var payloadBase64 = splitJWTArray[1];
            var secretKeyBase64 = splitJWTArray[2];

            var headerByte = Convert.FromBase64String(headerBase64);
            var payloadByte = Convert.FromBase64String(payloadBase64);
            var secretKeyByte = Convert.FromBase64String(secretKeyBase64);


            var header = System.Text.Encoding.UTF8.GetString(headerByte);
            var payload = System.Text.Encoding.UTF8.GetString(payloadByte);
            var secretKey = secretKeyBase64;


            //secretkey zaten SHA olduğu için gelen değerleri çeviremeyiz.
            //ancak gelen değerlerle aynı token ı tekrar oluşturup sonuçları karşılaştırabiliriz.

            //secret key de kullanılarak aslında imza oluşturuluyor.

            Console.WriteLine(header);
            Console.WriteLine(payload);

            Console.WriteLine("Client dan gelen Sign (imza)");
            Console.WriteLine(secretKey);

            Console.WriteLine("Kendi ürettiğimiz Sign (İmza)");
            Console.Write(JWT.Split('.')[2]);

            //Sonuç olarak zaten client herhangi birşeyi değiştirse budara yakalamak mümkün


            Console.ReadLine();

        }




        private static void GenerateJWT()
        {
            var header = File.ReadAllText(".\\header.json");
            var payload = File.ReadAllText(".\\payload.json");

            JWT = generateToken(header, payload, mySecretKey);

            Console.WriteLine($"JWT Token : {JWT}");


           
        }

        private static string doBase64(byte[] bytes)
        {
            var input = Convert.ToBase64String(bytes);


            return input;
        }


        private static string dobase64(string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            string base64 = doBase64(bytes);
            return base64;
        }


        private static string doHMAC256(string input, string secretKeyText)
        {

            byte[] secretByteKey = System.Text.Encoding.UTF8.GetBytes(secretKeyText);

            //bunun için microsoft.identitymodel.token eklenmeli
            //SymmetricSecurityKey secretKey = new SymmetricSecurityKey(secretByteKey);

            //SigningCredentials credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);



            //kendi yöntemimizle yapmış olduk HMACSHA256 yı. JWT bunu kullanıyor

            HMACSHA256 hMACSHA256 = new HMACSHA256(secretByteKey);
            var bytes=  hMACSHA256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
            // return System.Text.Encoding.UTF8.GetString(bytes);

            return Convert.ToBase64String(bytes);

        }


        private static string generateToken(string header, string payload, string secretKey)
        {
            string firstPart = dobase64(header) + "." + dobase64(payload);
            string secondPart = doHMAC256(firstPart, secretKey);

            string token = firstPart + "." + secondPart;

            return token;
        }


    }
}
