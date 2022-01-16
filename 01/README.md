## Day 1 - Create your first script in C#

### A brief intro

Some days ago I had to import some data from an Excel file into my C# application. The customer would date values in a progressive number format.
He sent me an email and he said 
> When the cell contains `44531`, I mean `01/12/2021`

Saerching in the web I found that Excel provides the `DATEVALUE` function (`DATA.VALORE` in italian) and this function convert a date in a string format to a progressive number: I found the way to generate some data.  

Searching again, I found the `DateTime.FromOADate` method into `DateTime` class. It accepts the progressive number and convert it to a DateTime object, exactly what I was searching for!

But before hardcode this logic into my application, I'd like to try it...

### Problem

When I want to try a few line of code or and external library, I create a *Console Application* in a *MyExperiments* folder. Usually I give to this application a name that remember me what the program does. I saw some colleagues doing the same, so I'm not alone :D

But every time I need to create a new Console application: so boring. In addition it create a bounch of folders and file I don't need. Sometime I use [.NET Fiddle](https://dotnetfiddle.net/), but I have to open a browser, import library, ... boring again. 

I'd like something the way I can execute simple script in F#, creating a `MyExperiment.fsx` file and launching the script from command line... *One file - One experiment*, or **OFEDD**, **O**ne **F**ile **E**xperiment **D**riven **D**evelopment!

### Solution

[Bing](www.bing.com) is my friend, and your friends don't let you alone. NEVER! 
I found this repository [filipw/dotnet-script](https://github.com/filipw/dotnet-script) on GitHub. From the description, it could be exactly what I'm searching for:
> Run C# scripts from the .NET CLI, define NuGet packages inline and edit/debug them in VS Code - all of that with full language services support from OmniSharp.

### Let's try!
So, I added the tool globally to `dotnet` using this command
```
dotnet tool install -g dotnet-script
```

Then I created the `FromOADateExperiment.csx` script
```
using System;
using System.Collections;

var dateValues = new List<int>{
    44531, 
    45351
};

foreach (var dateValue in dateValues)
{
    Console.WriteLine(DateTime.FromOADate(dateValue));    
}
```

And finally I run it from command line
```
dotnet-script .\FromOADateExperiment.csx
```
and I simply had the result! Great!!!

But I want to check if these dates are public holidays, probabibly I need an external package. I decided to use the [PublicHoliday](https://www.nuget.org/packages/PublicHoliday) nuget package.
As you can see from the 
```
ScriptWithNugetPackageExperiment.csx
``` 
script file, to add an external nuget package, you simply need to add this line
```
#r "nuget: PublicHoliday, 2.14.0"
```
before your code and the namespace containing the class/method you need to use, as you can see here
```
#r "nuget: PublicHoliday, 2.14.0"

using System;
using System.Collections;
using PublicHoliday;

var dateValues = new List<int>{
    44531,
    44555, 
    45351
};

var holidays = new ItalyPublicHoliday(); 

foreach (var dateValue in dateValues)
{
    var date = DateTime.FromOADate(dateValue);
    var isPublicHoliday = holidays.IsPublicHoliday(date);
    Console.WriteLine($"{date} is {(isPublicHoliday ? "" : "not ")}a public holiday.");    
}
```

Run the script 
```
dotnet-script .\ScriptWithNugetPackageExperiment.csx
``` 
and you'll know if the cryptic sequential numbers into your Excel represent a public holiday or not!

### Conclusion
The `dotnet-script` provide me a valid and fast tool to do some experiments, test logic and external library or to create scripts in C#.