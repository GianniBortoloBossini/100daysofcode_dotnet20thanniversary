#r "nuget: FSharp.Data, 4.2.7"

open FSharp.Data

[<Literal>]
let ResolutionFolder = __SOURCE_DIRECTORY__
[<Literal>]
let FileName = "./people_with_separator.csv"
[<Literal>]
let Separator = ";"

type PeopleDB = CsvProvider<FileName, Separator, ResolutionFolder=ResolutionFolder, CacheRows=false>

let people = PeopleDB.Load(__SOURCE_DIRECTORY__ + FileName) // this can be a URL

for person in people.Rows do 
    printfn "Id: %d, Name: %s, Surname: %s, Note: %s" person.Id person.Name person.Surname person.Note