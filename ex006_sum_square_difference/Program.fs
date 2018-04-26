let square (x : int) : int = x * x

let sum_of_squares (n : int) : int =
    seq { 1..n } |> Seq.map square |> Seq.reduce (+)

let square_of_sums (n : int) : int =
    square (n * (n + 1) / 2)

let answer = sum_of_squares 100 - square_of_sums 100 |> abs

printfn "answer = %i" answer
