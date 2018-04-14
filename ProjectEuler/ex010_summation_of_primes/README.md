# Project Euler problem 10: Summation of primes
[Project Euler problem 10](https://projecteuler.net/problem=10)
---
___
## Solution:
This solution contains unecessary micro optimizations that I will point out and how to make this simpler.
```fsharp
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
```

## Walkthrough:

#### Define a function for selecting primes:
This function contains some optimizations that can be done without for this particular problem.
```fsharp
let isPrime (x : int64) : bool =
    let max = x |> float |> sqrt |> int64 // only test divisors up to the int of sqrt of x
    let max = if max % 2L = 0L then max - 1L else max // this line rounds down to nearest odd number
    let rec isPrime (i : int64) : bool =
        i > max || x % i <> 0L && isPrime (i + 2L) // here we increment by two, thereby skipping even numbers
    x % 2L <> 0L && isPrime 3L // we test if 2 is a factor then test odd numbers starting with 3
```
This function could be simplified into this but it takes about 150% longer to solve the problem.
```fsharp
let isPrime (x : int64) : bool =
    let max = x |> float |> sqrt |> int64
    let rec isPrime (i : int64) : bool =
        i > max || x % i <> 0L && isPrime (i + 1L)
    isPrime 2L
```

#### Generate a lazy sequence of primes:
Again we got some optimizations that aren't necessary to solve the problem. They only speed up the solution a bit.
```fsharp
let primes : int64 seq =
    seq {
        yield 2L
        let mutable i = 3L
        while true do if isPrime i then yield i
                      i <- i + 2L
    }
```
Here is a more consise way to produce primes but it takes about 25% longer to solve the problem.
```fsharp
let primes : int64 seq =
    Seq.initInfinite ((+) 2 >> int64) |> Seq.filter isPrime
```

#### Produce the answer:
Take all primes smaller than two million then add them to get the correct answer.
```fsharp
let answer =
    primes
    |> Seq.takeWhile ((>) 2_000_000L)
    |> Seq.reduce (+)
```

#### Print out the answer:
```fsharp
printfn "answer = %i" answer
```
