DotnetCLI

* dotnet new

https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new?tabs=netcore21


create a solution file

    dotnet new  sln -n DotNetCLI

create a Class Library project 

    dotnet new classlib -n DotNetCLI.DataAccess

other project templates:

https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new?tabs=netcore21#template-options


create a custom template

https://docs.microsoft.com/en-us/dotnet/core/tutorials/create-custom-template

1. create a template.json file

recommended template name is in the format 

\<Company Name>.\<Template Type>.\<Programming Language>

    {

        "$schema": "http://json.schemastore.org/template",
        "author": "Murat Cabuk",
        "classifications": [ "Common", "Console" ],
        "identity": "MuratCabuk.ClassLibrary.CSharp",
        "name": "Murat Cabuk Class Library Application",
        "shortName": "muratcabukclslib"
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
        <authors>Murat Cabuk</authors>      
    </metadata>

    <contentFiles>
        <file src="**\*.*" />
    </contentFiles>

    </package>


3. create a package 

    //nuget pack <PATH_TO_NUSPEC_FILE>
    nuget pack /MuratCabuk.ClassLibrary.CSharp/MuratCabuk.ClassLibraryTemplate.CSharp.nuspec




custom template from microsoft 

https://github.com/dotnet/dotnet-template-samples

    create new 