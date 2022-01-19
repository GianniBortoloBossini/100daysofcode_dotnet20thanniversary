using System.Linq;

Func<int, string> Convert = (number) => number switch 
{
    var x when x % 3 == 0 && x % 5 == 0 => "FizzBuzz",
    var x when x % 3 == 0 => "Fizz",
    var x when x % 5 == 0 => "Buzz",
    _ => number.ToString()
};

Console.WriteLine(String.Join(", ", Enumerable.Range(1, 1000).Select(Convert)));
