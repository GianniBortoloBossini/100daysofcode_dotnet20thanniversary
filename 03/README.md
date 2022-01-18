## Day 3 - Simplify MVC web api controllers

### Minimal API approch

Create a new _minimal api_ running the following command: `dotnet new web -o minimal_api`.
Add the `WeatherForecastService.cs` service class to expose the business logic: we need to retrieve weather forecasts.
To invoke methods from the service directly from action method,
- first of all, we need to register the `WeatherForecastService` class into the IoC container using 
  ```
  builder.Services.AddScoped<WeatherForecastService>();
  ```
- and then, we have to inject the dependency into `MapGet` method, as follow 
  ```  
  app.MapGet("/", (WeatherForecastService service) => Results.Ok(service.Get()));
  ```
So easy! I remember that MVC web api requires developer to 
- inject the service into the controller, 
- create a local private readonly variable, 
- assign the service parameter from the controller to this variable
- use the local service variable into the action method

It seems quite verbose...

### MVC approch

MVC controller could be less verbose, too!
Create a new _mvc web api_ running the following command: `dotnet new webapi -o mvc_api`. 
Add the `WeatherForecastService.cs` service class to expose the business logic: we need to retrieve weather forecasts.
To invoke methods from the service directly from action methods,
- first of all, we need to register the `WeatherForecastService` class into the IoC container using 
  ```
  builder.Services.AddScoped<WeatherForecastService>();
  ```
  from `Program.cs` class
- and then, into `WeatherForecastController.cs` controller class, we can inject the dependency into `Get` method, as follow 
  ```  
  [HttpGet()]
    public IEnumerable<WeatherForecast> Get([FromServices] WeatherForecastService service)
        => service.Get();
  ```. 
  
No costructor needed: not bad!
