# Chapter 3
## Second internal customer
**Sharing code source + settings for client**

----
It has been a few months since our financial department is using the application and they were happy with it. On a morning coffee break where we were discussing the new automation trends, they mention the tool that we developed. The sales department was willing to see since they had themselves some similar situation.
We configured and deployed on a separate machine for them and we saw great feedback and real usage on a daily basis. They were so excited to see how they decreased the paperwork hours and had more time to pay attention to the client's needs.
They want to use the application as an example of automation and we find it more suitable as product development.

## Problem
Make a Console solution that can read a configurable setting (the folder path to be searched) from a file instead of being hardcoded into the application. Do not over-engineer the solution. Create and make it work, the easy way.


## Technical analysis

Creating a configuration file with all the settings that a client can particularly change. For now, we have just the directory path, along with the config. We have added also a class that manages the reading operation to move the reading operation

The reason that we put the setting into a configuration file and not make 2 applications is to have an easy way to maintain the same application for 2 clients. Also, later, the client may want to read from 2 different folders?

The impact on the solution is minimal. Just create a new class that knows how to read from a config file and retrieve the name of the folder as a property.

## Code

```csharp
var settings = Settings.From("app.json");
var directoryToSearch= settings.DocumentSLocation;
```
**Download code**
Code at [![Chapter03](https://ignatandrei.github.io/console_to_saas/Chapter03.svg)](https://ignatandrei.github.io/console_to_saas/sources/Chapter03.zip)


## Further reading
How an application can have multiple configuration sources (environment, command line, configuration file, code - in this order) - Read about .NET Core endpoint configuration (https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/kestrel?view=aspnetcore-2.2)

Hot reload the configuration: read IOptionSnapshot and IOptionMonitor at https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-3.1 

