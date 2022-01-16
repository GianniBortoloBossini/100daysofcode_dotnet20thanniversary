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