# Tamlin Server #
High-level documentation for developers working on teh Tamilin server project.

## Command Line ##
The following commands can be used to run, install and uninstall the Tamlin Server.

* Tamlin.MCServer.Host.exe run
* Tamlin.MCServer.Host.exe install 
* Tamlin.MCServer.Host.exe start
* Tamlin.MCServer.Host.exe stop
* Tamlin.MCServer.Host.exe uninstall 

A complete command line reference can be found [here](http://docs.topshelf-project.com/en/latest/overview/commandline.html)

## Configuration ##
All configuration settings are made in the .config file in the root directory.

Database Connection String

```xml
  <connectionStrings>
    <add name="mcnfb" connectionString="Server=(local);Database=mcnfb;Trusted_Connection=True;MultipleActiveResultSets=true;" providerName="System.Data.SqlClient"/>
  </connectionStrings>
```

App Settings

```xml
  <appSettings>
    <add key="web.port" value="8080"/>
    <add key="web.hostHeader" value="mc.client.com"/>
  </appSettings>
```

## Views (HTML) ##
All HTML pages can be found in the Views Folder in the Web Project.  For more information read the Nancy documentation on the [Super Simple View Engine](https://github.com/NancyFx/Nancy/wiki/The-Super-Simple-View-Engine) and Default [View Location Conventions](https://github.com/NancyFx/Nancy/wiki/View-location-conventions).

## Modules (aka. Controllers) ##
Nancy refers to Controllers as modules.  All modules are founds in the Modules folder in the Web Project.  For more information on Nancy Modules click [here](https://github.com/NancyFx/Nancy/wiki/Exploring-the-nancy-module)

## IoC ##
AutoFac is used to resolve and inject dependencies into classes.  There are two AutoFac modules found in the Configuration folder in the Web project.

* IoCApplicationRegistart.cs - All application life-cycle dependencies should be registered here.  These will be singleton instance that live until a service restart.
* IoCPerRequestRegistrar.cs - All per HTTP request dependencies should be registered here. These will be singleton instance per HTTP request.  This is where almost all dependencies should be registered.

## Data Access ##
Dapper is used as a simple ORM.  Simply create a Domain Object class to represent a table or query result then used Dapper to execute and automatically map the results to an instance of the domain object class.  In general create a repository for each domain object (aka. table).

## Business Logic ##
All business logic should live in Manager classes in the Business project.  In general, all calls from the UI should go through the business layer.  Try to avoid calling repositories directly from the UI.

## Further Reading ##

* [jQuery Mobile Framework](http://demos.jquerymobile.com/1.4.5/)
* [NancyFX MVC Framework](https://github.com/NancyFx/Nancy/wiki/Documentation)
* [Dapper Micro ORM](https://github.com/StackExchange/dapper-dot-net)
* [AutoFac IoC Container](http://autofac.org/)
* [Topshelf Service Framework](http://docs.topshelf-project.com/en/latest/index.html)
* [NLog Logging Framework](http://nlog-project.org/)
