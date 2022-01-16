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