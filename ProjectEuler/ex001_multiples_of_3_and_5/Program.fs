let ns : int seq = Seq.initInfinite id

let divisibleBy3Or5 (x : int) : bool = x % 3 = 0 || x % 5 = 0

let answer : int =
    ns
    |> Seq.filter divisibleBy3Or5
    |> Seq.takeWhile ((>) 1000)
    |> Seq.sum

printfn "answer = %i" answer
