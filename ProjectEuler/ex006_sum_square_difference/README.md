# Project Euler problem 6: Sum square difference
[Project Euler problem 6](https://projecteuler.net/problem=6)
---
___
## Solution:
```fsharp
let square (x : int) : int = x * x

let sum_of_squares (n : int) : int =
    seq { 1..n } |> Seq.map square |> Seq.reduce (+)

let square_of_sums (n : int) : int =
    square (n * (n + 1) / 2)

let answer = sum_of_squares 100 - square_of_sums 100 |> abs

printfn "answer = %i" answer
```

## Walkthrough:

#### Define a square function:
```fsharp
let square (x : int) : int = x * x
```

#### Define a function giving the sum of squares:
This function gives the sum of squares from 1 to the given number.
```fsharp
let sum_of_squares (n : int) : int =
    seq { 1..n } |> Seq.map square |> Seq.reduce (+)
```

#### Define a function giving the square of sums:
This function gives the square of the sums from 1 to the given number. We don't need to iterate through a list of these numbers because we know that the sum of the numbers from 1..n is n * (n + 1) / 2.
```fsharp
let square_of_sums (n : int) : int =
    square (n * (n + 1) / 2)
```

#### Produce the answer:
The answer is the difference between the sum of the squares and the square of the sums.
```fsharp
let answer = sum_of_squares 100 - square_of_sums 100 |> abs
```

#### Print out the answer:
```fsharp
printfn "answer = %i" answer
```
