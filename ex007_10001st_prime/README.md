# Project Euler problem 7: 10001st prime
[Project Euler problem 7](https://projecteuler.net/problem=7)
---
___
## Solution:
```fsharp
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
```

## Walkthrough:

#### Define utility function:
This help function helps to optimize the `isPrime`-function by reducing the number of integers needed to test wether a number is a prime or not.
```fsharp
let sqrt_int = float >> sqrt >> int
```

#### Define function to test wether a number is prime:
```fsharp
let isPrime (x : int) : bool =
    let rec isPrime (i : int) : bool =
        i < 2 || x % i <> 0 && isPrime (i - 1)
    isPrime (sqrt_int x)
```

#### Define a function to retrieve the nth Prime:
First a lazy infinite sequence of natural numbers is generated that starts at 2. Then primes are filtered using the `isPrime`-function. Lastly the nth item is retrieved.
```fsharp
let nthPrime (n : int) : int =
    Seq.initInfinite ((+) 2)
    |> Seq.filter isPrime
    |> Seq.item (n - 1)
```

#### Produce the answer:
```fsharp
let answer = nthPrime 10001
```
#### Print out the answer:
```fsharp
printfn "answer = %i" answer
```
