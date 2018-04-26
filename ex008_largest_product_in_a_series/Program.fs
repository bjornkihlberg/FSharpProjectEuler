open System.IO

let charToInt (c : char) : int64 = int64 c - int64 '0'

let ns : int64 seq =
     File.ReadLines "1000_digit_number.txt"
     |> Seq.concat
     |> Seq.map charToInt

let products : int64 seq =
    Seq.windowed 13 ns
    |> Seq.map (Array.reduce (*))

let answer : int64 = Seq.max products

printfn "answer = %i" answer
