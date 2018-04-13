let ns : int seq = seq { let mutable i = 1 in while true do yield i; i <- i + 1 }

let divisibleBy3And5 (x : int) : bool = x % 3 = 0 || x % 5 = 0

let answer : int = seq { for n in ns do if divisibleBy3And5 n then yield n }
                   |> Seq.takeWhile ((>) 1000) |> Seq.sum

printfn "answer = %i" answer
