let sqrt_int = float >> sqrt >> int

let isPrime (x : int) : bool =
    let rec isPrime (i : int) : bool =
        i < 2 || x % i <> 0 && isPrime (i - 1)
    isPrime (sqrt_int x)

let nthPrime (n : int) : int =
    Seq.initInfinite ((+) 2)
    |> Seq.filter isPrime
    |> Seq.item (n - 1)

let answer = nthPrime 10001

printfn "answer = %i" answer
