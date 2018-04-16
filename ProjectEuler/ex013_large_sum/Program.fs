let data : bigint seq = System.IO.File.ReadLines "data_source.txt"
                        |> Seq.map System.Numerics.BigInteger.Parse

let answer : string = Seq.reduce (+) data
                      |> string |> Seq.take 10 |> System.String.Concat

printfn "answer = %s" answer
