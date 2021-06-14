// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open Signal
open FSharp.Charting

[<EntryPoint>]
let main argv =
    let points = generateSamples 1000. 400.
    points |> Chart.Line
    let s = Console.ReadLine()
    0 // return an integer exit code
