# Routing


Change contoller and action name for cultural code

'''
 app.UseMvc(routes =>
            {
# en/Home/Index/2
                routes.MapRoute(
                    name: "default",
                    template: "{lang:length(2)}/{controller}/{action}/{id?}",
                    defaults: new {controller="home",lang="tr",action="index"});




# en/Account/Index/2
                routes.MapRoute(
                    name: "account_en",
                    template: "{lang:length(2)}/account/index/{id?}",
                    defaults: new {controller="account",lang="en",action="index"});



# tr/Hesap/Indeks/2

                routes.MapRoute(
                    name: "account_tr",
                    template: "{lang:length(2)}/hesap/indeks/{id?}",
                    defaults: new {controller="account",lang="tr",action="index"});



# es/Cuenta/Index/2


                     routes.MapRoute(
                    name: "account_ar",
                    template: "{lang:length(2)}/test/indeks/{id?}",
                    defaults: new {controller="account",lang="es",action="index"});



            });
            
'''

