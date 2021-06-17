module SignalGenerator

let generateSamples duration frequency =
    let sampleRate = 44100.
    let bitSampleLimit = 32767.
    let volume = 0.8

    let toAmplitude x =
        x
        |> (*) (2. * System.Math.PI * frequency / sampleRate)
        |> sin
        |> (*) bitSampleLimit
        |> (*) volume
        |> int16

    let sampleAmount = duration / 1000. * sampleRate
    let requiredSamples = seq { 1.0 .. sampleAmount }

    Seq.map toAmplitude requiredSamples
