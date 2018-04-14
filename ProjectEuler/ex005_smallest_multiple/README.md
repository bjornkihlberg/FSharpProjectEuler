# Project Euler problem 5: Smallest multiple
[Project Euler problem 5](https://projecteuler.net/problem=5)
---
___
## Solution:
```fsharp
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
```

## Walkthrough:

#### Create a lazy sequence of numbers from 2 to 20:
```fsharp
let ns : int seq = seq { for i in 2..20 do yield i }
```

#### Create an array of primes:
This could be an infinite lazy sequence to have a more general solution but I dont want to get bogged down too much in writing code for producing prime numbers. I only need the ones in the range 2..20.
```fsharp
let primes : int [] = [| 2; 3; 5; 7; 11; 13; 17; 19 |]
```

#### Define helper functions:
```fsharp
let sqrt_int = float >> sqrt >> int

let divisible a b = a % b = 0
```

#### Define function for factorising:
This is needed for factorising all numbers in the range 2 to 20.
```fsharp
let smallestFactor (x : int) : int =
    Array.find (divisible x) primes

let factorise : int -> int list =
    let rec factorise (ps : int list) (x : int) : int list =
        let p = smallestFactor x
        if p > sqrt_int x then x::ps
                          else factorise (p::ps) (x / p)
    factorise []
```

#### Define function for finding the minimum power required for a given prime
This is needed because we will factorise the numbers in the range 2..20 and then count what is the minimum power for each prime in the range 2..20. This is done because if our number is divisible, for example, by 8, then it is also divisible by 2. So we would need at least 3 2s to accomodate the 8.
```fsharp
let countPrimes (p : int) : int list -> int =
    List.filter ((=) p) >> List.length

let largestPrimeOccurance (p : int) : int list seq -> int =
    Seq.map (countPrimes p) >> Seq.max
```

#### Produce the answer
First all numbers in the range 2..20 are factorised. Then each prime are taken to the power of the largest occurance for that prime. And then finally all those numbers are multiplied and we get our answer.
```fsharp
let answer =
    let ns_factorised : int list seq = Seq.map factorise ns
    primes
    |> Array.map (fun p -> pown p (largestPrimeOccurance p ns_factorised))
    |> Array.reduce (*)
```

#### Print out the answer:
```fsharp
printfn "answer = %i" answer
```
