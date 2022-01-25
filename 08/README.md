## Day 8 - Reading and wrinting csv files in F#

Reading and writing csv files could be tricky. In C#, [CsvHelper](https://joshclose.github.io/CsvHelper/) is a great library that help developers so much.

But in F#, the life is easier. [CsvProvider](https://fsprojects.github.io/FSharp.Data/library/CsvProvider.html) can infer the structure of teh csv file simply providing the file path: loading the file, the library provides Rows and each Row has got the csv columns as members.

Please take a look to `1_ReadCsv/Script_ReadCsv.fsx` and `2_ReadCsvWithSepararorAndQuote/Script_with_separator.fsx` script file to see how easy could be this task!

Creating a csv from an array of elements is simple, as you can see into `3_ExportCsv/Script_export.fsx` script.