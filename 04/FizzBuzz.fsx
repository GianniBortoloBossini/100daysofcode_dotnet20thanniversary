open System

let Convert number =
    match number with
    | number when number % 3 = 0 && number % 5 = 0 -> "FizzBuzz"
    | number when number % 3 = 0  -> "Fizz"
    | number when number % 5 = 0  -> "Buzz"
    | _ -> number.ToString()

let Print (a: seq<string>) =
    printfn "%s" <| String.Join(", ", a)

[1..1000]
|> Seq.map(Convert)
|> Print