#r "nuget: FSharp.Data, 4.2.7"

open FSharp.Data

[<Literal>]
let ResolutionFolder = __SOURCE_DIRECTORY__
[<Literal>]
let FileName = "./people.csv"

type PeopleDB = CsvProvider<FileName, ResolutionFolder=ResolutionFolder, CacheRows=false>

let people = PeopleDB.Load(ResolutionFolder + FileName) // this can be a URL

for person in people.Rows do 
    printfn "Id: %d, Name: %s, Surname: %s" person.Id person.Name person.Surname