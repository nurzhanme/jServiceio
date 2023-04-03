# jServiceio

jServiceio is a RESTful APIs client in C# applications.

If you like this project please give a star and a cup of coffee =)

[!["Buy Me A Coffee"](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/nurzhanme)

## Installation

[![NuGet Badge](https://buildstats.info/nuget/jServiceio)](https://www.nuget.org/packages/jServiceio/)

To install jServiceio, you can use the NuGet package manager in Visual Studio. Simply search for "jServiceio" and click "Install".

Alternatively, you can install jServiceio using the command line:

```
Install-Package jServiceio
```

## Getting Started

### Without using dependency injection:

```c#
var apiClient = new jServiceioClient(new jServiceioOptions());
```

### Using dependency injection:

#### Program.cs

```c#
serviceCollection.AddjServiceioClient();
```

After injecting your service you will be able to get it from service provider

```c#
var apiClient = serviceProvider.GetRequiredService<jServiceioClient>();
```

or injecting in the constructor of your class

```c#
public class MyService
{
    private readonly jServiceioClient _apiClient;

    public NewsService(jServiceioClient apiClient)
    {
        _apiClient = apiClient;
    }
}
```

## Logging and Exception handling

For diagnostic there are `DelegatingHandler`-s such as `LoggingHandler` and `ExceptionHandler`. You can always extend them