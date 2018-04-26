# Project Euler problem 2: Even Fibonacci numbers
[Project Euler problem 2](https://projecteuler.net/problem=2)
---
___
## Solution:
```fsharp
let fibonacci : int seq =
    let rec fib a b = seq { yield a; yield! fib b (a + b) }
    fib 1 2

let lessThan4Mil : int seq = Seq.takeWhile ((>) 4_000_000) fibonacci

let isEven x = x % 2 = 0

let evens : int seq = Seq.filter isEven lessThan4Mil

let answer : int = Seq.sum evens

printfn "answer = %i" answer
```

## Walkthrough:

#### Define a lazy sequence of all fibonacci numbers:
```fsharp
let fibonacci : int seq =
    let rec fib a b = seq { yield a; yield! fib b (a + b) }
    fib 1 2
```

#### Take all fibonacci numbers smaller than four million:
```fsharp
let lessThan4Mil : int seq = Seq.takeWhile ((>) 4_000_000) fibonacci
```

#### Define a predicate that tests wether a number is even:
```fsharp
let isEven x = x % 2 = 0
```

#### Select all even fibonacci numbers smaller than four million:
```fsharp
let evens : int seq = Seq.filter isEven lessThan4Mil
```

#### Answer is the sum of all even fibonacci numbers smaller than four million:
```fsharp
let answer : int = Seq.sum evens
```

#### Print out the answer:
```fsharp
printfn "answer = %i" answer
```
