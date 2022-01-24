## Day 7 - Enhanced .net 6 Minimal Api solution with Carter

I'm old enough to remember NancyFx. [NancyFx](http://nancyfx.org/) was a simple library to create REST API using the _.net framework_. It aimed to improve the structure of the project simplifying the way to create endpoints, as you can see below 
```
public class SampleModule : Nancy.NancyModule
{
    public SampleModule()
    {
        Get["/"] = _ => "Hello World!";
    }
}
```
The code is quite similar to the new .net 6 Minimal Api. Do you agree?
I loved NancyFx, so I like Minimal Api. I like Minimal Api, and I don't lot them, because they don't provide a built-in way to create a well structured project: many blogs show a rich `Program.cs` class with many `MapGet`, `MapPost`, `Map{Something}` methods. This is good to introduce the argument, but become a pain if you need to develop a mid-size REST API project.

Searching for some suggestions to improve my REST API projects, I found [Carter](https://github.com/CarterCommunity/Carter).

### Create a Carter api

Open your terminal, and install Carter template launching this command
```
dotnet new -i CarterTemplate
```
then create you project executing this one
```
dotnet new Carter -n MyCarterApp
```

As you can see, a Carter project has a slim `Program.cs` class, that contains the magical `builder.Services.AddCarter();` declaration.
This line of code allows you to move endpoints declaration and implementation from `Program.cs` to `XXXModule` class. An example is the provided `HomeModule.cs` file that contains this code
```
public class HomeModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app) => app.MapGet("/", () => "Hello from Carter!");
}
```
The class implements `ICarterModule` interface. Carter will load modules automagically, simply searching classes that implement `ICartedModule` interface.
Running `dotnet run` and executing the following command, you can retrieve the _Hello from Carter!_ response 
```
curl http://localhost:5000/
```

### Creating modules
I like Hexagonal architecture, so I try to setup the project following Ports/Adapters structures.
Into _Modules\Api_ folder, I created two modules: _Players_ and _Teams_.
Into each module I create three folders: _Core_ that contains the business logic, _Ports_ that contains interfaces and _Adapters_ that contains the implentation of the previews interface.
To fluently inject modules dependencies I created two classes `TeamsConfiguration` and `PlayersConfiguration`, one for each module, that expose `AddPlayersConfiguration` and `AddTeamsConfiguration` extension methods. Those extension methods provide a simple way to register dependencies into IoC container
```
builder.Services.AddCarter()
                .AddPlayersConfiguration()
                .AddTeamsConfiguration(); 
```

`PlayersModule.cs` and `TeamsModule.cs` classes contains module-related endpoints.

Now, running the api with `dotnet run`, you can invoke the Players and Teams api calling `curl http://localhost:5000/players` and `curl http://localhost:5000/teams` from your terminal.

### Conclusions
This sample provides an easy way to create a Carter-based .net 6 minimal rest api, structuring the project in _modules_.
As you can see, your `Program.cs` class is slim now, and you can create well structured REST API.