#load "SignalGenerator.fsx"

open System.IO
open System.Text

let pack (d: int16 []) =
    let stream = new MemoryStream()

    let writer =
        new BinaryWriter(stream, System.Text.Encoding.ASCII)

    let dataLength = Array.length d * 2

    writer.Write(Encoding.ASCII.GetBytes("RIFF"))
    writer.Write(Array.length d)
    writer.Write(Encoding.ASCII.GetBytes("WAVE"))

    writer.Write(Encoding.ASCII.GetBytes("fmt "))
    writer.Write(16)
    writer.Write(1s)
    writer.Write(1s)
    writer.Write(44100)
    writer.Write(44100 * 16 / 8)
    writer.Write(2s)
    writer.Write(16s)

    // data
    writer.Write(Encoding.ASCII.GetBytes("data"))
    writer.Write(dataLength)
    let data : byte [] = Array.zeroCreate dataLength
    System.Buffer.BlockCopy(d, 0, data, 0, data.Length)
    writer.Write(data)
    stream

let write fileName (ms: MemoryStream) =
    use fs =
        new FileStream(Path.Combine(__SOURCE_DIRECTORY__, fileName), FileMode.Create)

    ms.WriteTo(fs)

Array.ofSeq (generateSamples 1500. 440.)
|> pack
|> write "test.wav"
