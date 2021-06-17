// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open SignalGenerator
open ToneParser

[<EntryPoint>]
let main argv =
    ToneParser.test pToken aspiration
    0 // return an integer exit code
