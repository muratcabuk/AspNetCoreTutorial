DotnetCLI

# DOTNET NEW

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

also visit the foloowing address for project template options

https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new?tabs=netcore21#template-options


## dotnet new options

Project Temeplate List

    dotnet new -l

Project language

    dotnet new console -lang "c#" 

Project Namespace and name

    dotnet new console -o muratcabuk.DAL

Item Type List.  Predefined values are "project", "item" or "other".
sln, page, globaljson, webconfig ... etc

    dotnet new --type 
    dotnet new --type sln
   
Framework version

    dotnet new -f netcoreapp2.0
    or
    dotnet new -f netstandard2.0

https://github.com/dotnet/docs/blob/master/docs/core/tools/dotnet-new.md

# DOTNNET SLN

source: https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-sln#examples

Add a C# project to a solution:

    dotnet sln todo.sln add todo-app/todo-app.csproj

Remove a C# project from a solution:

    dotnet sln todo.sln remove todo-app/todo-app.csproj

Add multiple C# projects to a solution:

    dotnet sln todo.sln add todo-app/todo-app.csproj back-end/back-end.csproj

Remove multiple C# projects from a solution:

    dotnet sln todo.sln remove todo-app/todo-app.csproj back-end/back-end.csproj

Add multiple C# projects to a solution using a globbing pattern:

    dotnet sln todo.sln add **/*.csproj

Remove multiple C# projects from a solution using a globbing pattern:

    dotnet sln todo.sln remove **/*.csproj


# DOTNET BUILD

The dotnet build command builds the project and its dependencies into a set of binaries. The binaries include the project's code in Intermediate Language (IL) files with a .dll extension and symbol files used for debugging with a .pdb extension. A dependencies JSON file (*.deps.json) is produced that lists the dependencies of the application. A *.runtimeconfig.json file is produced, which specifies the shared runtime and its version for the application.


If the project has third-party dependencies, such as libraries from NuGet, they're resolved from the NuGet cache and aren't available with the project's built output. With that in mind, the product of dotnet build isn't ready to be transferred to another machine to run. This is in contrast to the behavior of the .NET Framework in which building an executable project (an application) produces output that's runnable on any machine where the .NET Framework is installed. To have a similar experience with .NET Core, you need to use the dotnet publish command. For more information, see .NET Core Application Deployment.


Starting with .NET Core 2.0, you don't have to run dotnet restore because it's run implicitly by all commands, such as dotnet build and dotnet run, that require a restore to occur. 

dotnet build uses MSBuild to build the project, so it supports both parallel and incremental builds. For more information, see Incremental Builds. In addition to its options, the dotnet build command accepts MSBuild options, such as /p for setting properties or /l to define a logger. For more information about these options, see the MSBuild Command-Line Reference.

## DOTNET Build Options

    -c|--configuration {Debug|Release}

Defines the build configuration. The default value is Debug.

    -f|--framework <FRAMEWORK>

Compiles for a specific framework. The framework must be defined in the project file.

    --force

Forces all dependencies to be resolved even if the last restore was successful. Specifying this flag is the same as deleting the project.assets.json file.

    -h|--help

Prints out a short help for the command.

    --no-dependencies

Ignores project-to-project (P2P) references and only builds the specified root project.

    --no-incremental

Marks the build as unsafe for incremental build. This flag turns off incremental compilation and forces a clean rebuild of the project's dependency graph.

    --no-restore

Doesn't execute an implicit restore during build.

    -o|--output <OUTPUT_DIRECTORY>

Directory in which to place the built binaries. You also need to define --framework when you specify this option.

### DOTNET Build Examples

Build a project and its dependencies using Release configuration:

    dotnet build --configuration Release

Build a project and its dependencies for a specific runtime (in this example, Ubuntu 16.04):

    dotnet build --runtime ubuntu.16.04-x64

Build the project and use the specified NuGet package source during the restore operation (.NET Core SDK 2.0 and later versions):

    dotnet build --source c:\packages\mypackages

# DOTNET (Nuget Commands)
source : https://docs.microsoft.com/en-us/nuget/tools/dotnet-commands 

### dotnet add package

Adds a package reference to the project file, then runs dotnet restore to install the package.
    
    dotnet add package
    # example
    dotnet add package Newtonsoft.Json
#### dotnet add options

    -h|--help

Prints out a short help for the command.

    -f|--framework <FRAMEWORK>

Adds a package reference only when targeting a specific framework.

    -n|--no-restore

Adds a package reference without performing a restore preview and compatibility check.

    --package-directory <PACKAGE_DIRECTORY>

Restores the package to the specified directory.

    -s|--source <SOURCE>

Uses a specific NuGet package source during the restore operation.

    -v|--version <VERSION>

### dotnet remove package

    dotnet remove package

### dotnet restore
 Restores the dependencies and tools of a project.
 
### (Package creation) dotnet pack 

The dotnet pack command builds the project and creates NuGet packages. The result of this command is a NuGet package. If the --include-symbols option is present, another package containing the debug symbols is created.
    
    dotnet pack ~/projects/app1/project.csproj --output [foldername]
 ### dotnet push
 
The dotnet nuget push command pushes a package to the server and publishes it. The push command uses server and credential details found in the system's NuGet config file or chain of config files. For more information on config files.

#### dotnet push example

Pushes foo.nupkg to the default push source, specifying an API key:

    dotnet nuget push foo.nupkg -k 4003d786-cc37-4004-bfdf-c4f3e8ef9b3a

Push foo.nupkg to the custom push source http://customsource, specifying an API key:

    dotnet nuget push foo.nupkg -k 4003d786-cc37-4004-bfdf-c4f3e8ef9b3a -s http://customsource/

Pushes foo.nupkg to the default push source:

    dotnet nuget push foo.nupkg

Pushes foo.symbols.nupkg to the default symbols source:

    dotnet nuget push foo.symbols.nupkg

Pushes foo.nupkg to the default push source, specifying a 360-second timeout:

    dotnet nuget push foo.nupkg --timeout 360

Pushes all .nupkg files in the current directory to the default push source:

    dotnet nuget push *.nupkg
    





    








