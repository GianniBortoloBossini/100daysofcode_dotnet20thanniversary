#r "nuget: FSharp.Data, 4.2.7"

open FSharp.Data
open System
open System.IO

type ArtistsCsv = CsvProvider<Schema = "Id (int), Artist (string), Instrument (string option)", HasHeaders = false>

let rows =
  [ ArtistsCsv.Row(1, "Jimmy Hendrix", Some "Guitar")
    ArtistsCsv.Row(2, "Nicko McBrain", Some "Drum")
    ArtistsCsv.Row(3, "Gianni Bortolo Bossini", None)
  ]

let fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_export.csv" 

let csv = new ArtistsCsv(rows)
File.WriteAllText(fileName, csv.SaveToString())