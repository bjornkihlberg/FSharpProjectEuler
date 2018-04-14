let isPrime (x : int64) : bool =
    let max = x |> float |> sqrt |> int64
    let max = if max % 2L = 0L then max - 1L else max
    let rec isPrime (i : int64) : bool =
        i > max || x % i <> 0L && isPrime (i + 2L)
    x % 2L <> 0L && isPrime 3L

let primes : int64 seq =
    seq {
        yield 2L
        let mutable i = 3L
        while true do if isPrime i then yield i
                      i <- i + 2L
    }

let answer =
    primes
    |> Seq.takeWhile ((>) 2_000_000L)
    |> Seq.reduce (+)

printfn "answer = %i" answer
