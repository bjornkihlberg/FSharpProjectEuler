# Project Euler problem 3: Largest prime factor
[Project Euler problem 3](https://projecteuler.net/problem=3)
---
___
## Solution:
```fsharp
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
```

## Walkthrough:

#### Define a function that gets the rounded down integer of the square root:
The reason this is done is because when you want to test if a number `x` is a prime you dont have to test all numbers between 2 and `x`, only the numbers between 2 and the square root of `x`.
```fsharp
let sqrt_int : int64 -> int64 = float >> sqrt >> int64
```

#### Define a function that tests a given number and returns true if it is prime:
```fsharp
let isPrime (n : int64) : bool =
    let rec isPrime : int64 -> bool = function
        | i when i < 2L     -> true
        | i when n % i = 0L -> false
        | i -> isPrime (i - 1L)
    isPrime (sqrt_int n)
```

#### Define a function that finds the largest factor of a given number:
Since the problem requires that a very large number `x` is factorised, it's best to start by finding the smaller prime factors. Once a prime factor `p` has been found, instead of keep factorising `x`, factorise `x` / `p`, thereby reducing the computational load significantly.
```fsharp
let factorise : int64 -> int64 =
    let rec factorise (n : int64) : int64 -> int64 = function
        | x when n > sqrt_int x             -> x
        | x when n |> isPrime && x % n = 0L -> factorise 2L (x / n)
        | x                                 -> factorise (n + 1L) x
    factorise 2L
```

#### Produce the answer and print it out:
```fsharp
let answer = factorise 600851475143L

printfn "answer = %i" answer
```