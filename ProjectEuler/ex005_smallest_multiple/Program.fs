let ns : int seq = seq { for i in 2..20 do yield i }

let primes : int [] = [| 2; 3; 5; 7; 11; 13; 17; 19 |]

let sqrt_int = float >> sqrt >> int

let divisible a b = a % b = 0

let smallestFactor (x : int) : int =
    Array.find (divisible x) primes

let factorise : int -> int list =
    let rec factorise (ps : int list) (x : int) : int list =
        let p = smallestFactor x
        if p > sqrt_int x then x::ps
                          else factorise (p::ps) (x / p)
    factorise []

let countPrimes (p : int) : int list -> int =
    List.filter ((=) p) >> List.length

let largestPrimeOccurance (p : int) : int list seq -> int =
    Seq.map (countPrimes p) >> Seq.max

let answer =
    let ns_factorised : int list seq = Seq.map factorise ns
    primes
    |> Array.map (fun p -> pown p (largestPrimeOccurance p ns_factorised))
    |> Array.reduce (*)

printfn "answer = %i" answer
