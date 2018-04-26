let countDivisors (x : int) : int =
    let rec loop (n : int) : int -> int = function
        | i when i * i < x -> loop (n + if x % i = 0 then 2 else 0) (i + 1)
        | i when i * i > x -> n
        | _                -> n + 1
    loop 0 1

let triangleNumber x = x * (x + 1) / 2

let triangleNumbers : int seq = Seq.initInfinite ((+) 1 >> triangleNumber)

let answer = Seq.find (countDivisors >> (<) 500) triangleNumbers

printfn "answer = %i" answer
