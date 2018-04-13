let fibonacci : int seq =
    let rec fib a b = seq { yield a; yield! fib b (a + b) }
    fib 1 2

let lessThan4Mil : int seq = Seq.takeWhile ((>) 4_000_000) fibonacci

let isEven x = x % 2 = 0

let evens : int seq = Seq.filter isEven lessThan4Mil

let answer : int = Seq.sum evens

printfn "answer = %i" answer
