DotnetCLI

* # DOTNET NEW

https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new?tabs=netcore21


create a solution file

    dotnet new  sln -n DotNetCLI

create a Class Library project

    dotnet new classlib -n DotNetCLI.DataAccess

other project templates:

https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new?tabs=netcore21#template-options


## create a custom template

https://docs.microsoft.com/en-us/dotnet/core/tutorials/create-custom-template


for new version templating

https://rehansaeed.com/custom-project-templates-using-dotnet-new/


you use CustomTemlate folder as template project.


1. create a template.json file


It is important to point out that the value of the sourceName field inside the template.json file will be used as a marker to replace all occurances of "MuratCabuk.ClassLibrary.CSharp" to the name of the newly created project when the template executes.


\<Company Name>.\<Template Type>.\<Programming Language>

    {

        "$schema": "http://json.schemastore.org/template",
        "author": "Murat Cabuk",
        "classifications": [ "MyDirectory", "MyClassLibrary" ],
        "identity": "MuratCabuk.ClassLibrary.CSharp",
        "name": "Murat Cabuk Class Library",
        "shortName": "muratcabukclslib",
        "sourceName": "MuratCabuk.ClassLibrary.CSharp",
        "language" : "[C#]"
    }

2. create MuratCabuk.ClassLibraryTemplate.CSharp.nuspec file for local nuget distribution 


https://docs.microsoft.com/en-gb/nuget/reference/nuspec


    <?xml version="1.0" encoding="utf-8"?>
        <package xmlns="http://schemas.microsoft.com/packaging/2012/06/nuspec.xsd">
    <metadata>
       <id>MuratCabuk.ClassLibrary.CSharp</id>
        <version>1.0.0</version>
        <description>
        Creates the murat cabuk class lib app
        </description>
        <projectUrl>http://muratcabuk.com/</projectUrl>
        <authors>Murat Cabuk</authors>
    </metadata>

    <contentFiles>
        <file src="content/**/*.*" />
    </contentFiles>

    </package>


3. create a package 

nuget pack <PATH_TO_NUSPEC_FILE>
    
    nuget pack /MuratCabuk.ClassLibrary.CSharp/MuratCabuk.ClassLibraryTemplate.CSharp.nuspec


4. Installing a template

    To install a template from a NuGet package stored at nuget.org
    dotnet new -i <NUGET_PACKAGE_ID>

    or To install a template from a local nupkg file  
    dotnet new -i <PATH_TO_NUPKG_FILE>

    or To install a template from a file system directory
    dotnet new -i <FILE_SYSTEM_DIRECTORY>

I used the following command to intall from file system

    dotnet new -i MuratCabuk.ClassLibrary.CSharp/content/

but if i had created nuget package

    dotnet new -i MuratCabuk.ClassLibrary.CSharp.1.0.0.nupkg


and I created a project from customtaplate with forroowing command

    dot net muratcabukclslib -n "Merhaba"

you can see the created app in ProjectFromCustomTemplate folder

custom template from microsoft

https://github.com/dotnet/dotnet-template-samples
https://dotnetnew.azurewebsites.net/
