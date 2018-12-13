#
projeyi properties den cosoleda çalışcak şeklde getiriyoruz.

Debug menusunde profile kısmında applicatio ı seçiyoruz "MyIdentityServer"

daha sonra uygulamayı çalıştırıken IIS Express değilde applicaiton name mizin olduğu server ı seçiyoruz. "MyIdentityServer"

OAuth2 standartlarına uygun yazılmış api lerde  http(s)://apiaddress:portnumber/.well-known/openid-configuration ile api discovery yapılabilir.
bu discovery ile end point adresi client tarafından alınabilir

client app lere IdentityModel paketini yükledik.

Developer lar için clientID ve client Secret üretilmesi zorunlu.



javasciptte kullanabilmek için oidc-client js kütüphanesinin yüklenmesi lazım. biz bower ile yükleyip manual olarak www altında js klasörüne koyduk.



//örnekler github identityser4 saples lar altında mevcut
https://github.com/IdentityServer/IdentityServer4.Samples


https://github.com/IdentityServer


https://github.com/IdentityServer/IdentityServer4.Samples/tree/release/Quickstarts/2_ResourceOwnerPasswords





