## Day 2 - Create your first script in F#

### A brief intro (skip if you read the same paragraph from day 1)

Some days ago I had to import some data from an Excel file into my C# application. The customer would date values in a progressive number format.
He sent me an email and he said 
> When the cell contains `44531`, I mean `01/12/2021`

Saerching in the web I found that Excel provides the `DATEVALUE` function (`DATA.VALORE` in italian) and this function convert a date in a string format to a progressive number: I found the way to generate some data.  

Searching again, I found the `DateTime.FromOADate` method into `DateTime` class. It accepts the progressive number and convert it to a DateTime object, exactly what I was searching for!

But before hardcode this logic into my application, I'd like to try it...

### Problem

In F# there aren't problems... only fun!

### Solution

As explained [here](https://docs.microsoft.com/en-us/dotnet/fsharp/tools/fsharp-interactive/)

> F# Interactive (dotnet fsi) is used to run F# code interactively at the console, or to execute F# scripts. In other words, F# interactive executes a REPL (Read, Evaluate, Print Loop) for F#.

So..."We've got a REPL!", said an italian politician some year ago: we can run scripts without external packages/tools.

### Let's try!
Create the `ScriptWithNugetPackageExperiment.csx` script
```
#r "nuget: PublicHoliday, 2.14.0"

open System
open PublicHoliday

let dateValues = [44531; 44555; 45351]

let holidays = new ItalyPublicHoliday()

dateValues
|> Seq.map(fun dateValue -> DateTime.FromOADate(dateValue))
|> Seq.map(fun date -> sprintf "%s is %sa public holiday" (date.ToString "yyyy/MM/dd") (if holidays.IsPublicHoliday(date) then "" else "not "))
|> Seq.toArray
|> printfn "%A"
```
and run this command from command line
```
dotnet fsi .\ScriptWithNugetPackageExperiment.fsx
```

TADAA!! Script executed succesfully! 

But there's another simplier way to execute an F# script: 
- open VS Code or Visual Studio, as you prefer
- copy the code above
- select all lines
- press `ALT+ENTER` to execute the script

You can select only a bunch of rows, without saving the file, while you are writing your script and execute that code partially to verify if it works propertly: amazing!

### Conclusion
Executing scripts in F# is so simple that you cannot forget to try this experience!


PS: before press `ALT+ENTER` keys, remember to include `open` and `external references` to your selected lines ;)