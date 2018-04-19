# Project Euler problem 12: Highly divisible triangular number
[Project Euler problem 12](https://projecteuler.net/problem=12)
---
___
## Solution:
```fsharp
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
```

## Walkthrough:

#### Define a function that counts divisors:
This is were most of the magic happens so I will go into details how this function works. It is actually important that you make little optimizations otherwise the problem will take too long to solve.
```fsharp
let countDivisors (x : int) : int =
    let rec loop (n : int) : int -> int = function
        | i when i * i < x -> loop (n + if x % i = 0 then 2 else 0) (i + 1)
        | i when i * i > x -> n
        | _                -> n + 1
    loop 0 1
```

If x is divisible by i, it also means x is divisible by another number so we only have to check if x is divisible by numbers smaller than the square root of x. This is why we add 2 to our counter when we find that x is divisible by i.
```fsharp
| i when i * i < x -> loop (n + if x % i = 0 then 2 else 0) (i + 1)
```

If the square root of x is smaller than i, then we are done and we return our counter.
```fsharp
| i when i * i > x -> n
```

The remaining case is when i is equal to the square root of x, in which case we know we have reached our goal and found one more divisor of x.
```fsharp
| _ -> n + 1
```

#### Define a lazy sequence of all triangle numbers:
```fsharp
let triangleNumber x = x * (x + 1) / 2

let triangleNumbers : int seq = Seq.initInfinite ((+) 1 >> triangleNumber)
```

#### Produce the answer:
We produce the answer by finding the first triangle number whose divisors number up to more than 500.
```fsharp
let answer = Seq.find (countDivisors >> (<) 500) triangleNumbers
```

#### Print out the answer:
```fsharp
printfn "answer = %i" answer
```
