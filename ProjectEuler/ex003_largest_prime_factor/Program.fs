let sqrt_int : int64 -> int64 = float >> sqrt >> int64

let isPrime (n : int64) : bool =
    let rec isPrime : int64 -> bool = function
        | i when i < 2L     -> true
        | i when n % i = 0L -> false
        | i -> isPrime (i - 1L)
    isPrime (sqrt_int n)

let factorise : int64 -> int64 =
    let rec factorise (n : int64) : int64 -> int64 = function
        | x when n > sqrt_int x             -> x
        | x when n |> isPrime && x % n = 0L -> factorise 2L (x / n)
        | x                                 -> factorise (n + 1L) x
    factorise 2L

let answer = factorise 600851475143L

printfn "answer = %i" answer
