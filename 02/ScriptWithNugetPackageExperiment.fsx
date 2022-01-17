#r "nuget: PublicHoliday, 2.14.0"

open System
open PublicHoliday

let dateValues = [44531; 44555; 45351]

let holidays = new ItalyPublicHoliday()

dateValues
|> Seq.map(fun dateValue -> DateTime.FromOADate(dateValue))
|> Seq.map(fun date -> sprintf "%s is %sa public holiday" (date.ToString "yyyy/MM/dd") (if holidays.IsPublicHoliday(date) then "" else "not "))
|> printfn "%A"