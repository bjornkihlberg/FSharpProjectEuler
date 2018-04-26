# Project Euler problem 11: Summation of primes
[Project Euler problem 11](https://projecteuler.net/problem=11)
---
___
## Solution:
```fsharp
open System.IO

let data : int [,] = File.ReadLines "20x20_number_grid.txt"
                     |> Seq.map (fun s -> s.Split ' ' |> Array.map int)
                     |> array2D

let productsInARow : int [] -> int [] =
    Array.windowed 4 >> Array.map (Array.reduce (*))

let productInABackDiagonal (xs : int [,]) : int =
    xs.[0, 0] * xs.[1, 1] * xs.[2, 2] * xs.[3, 3]

let productInAForwardDiagonal (xs : int [,]) : int =
    xs.[0, 3] * xs.[1, 2] * xs.[2, 1] * xs.[3, 0]

let products : int seq =
    seq {
        let l = data.GetLength 0
        for i in 0..l - 1 do
            yield! data.[i, *] |> productsInARow
            yield! data.[*, i] |> productsInARow
        for i in 0..l - 5 do
            for j in 0..l - 5 do
                let xs = data.[i..i + 3, j..j + 3]
                yield productInABackDiagonal xs
                yield productInAForwardDiagonal xs
    }

let answer = Seq.max products

printfn "answer = %i" answer
```

## Walkthrough:

#### Read data, parse it and store it in an appropriate data structure:
A 2d array is chosen for its simple slicing syntax.
```fsharp
let data : int [,] = File.ReadLines "20x20_number_grid.txt"
                     |> Seq.map (fun s -> s.Split ' ' |> Array.map int)
                     |> array2D
```

#### Define helper functions for producing products:
```fsharp
let productsInARow : int [] -> int [] =
    Array.windowed 4 >> Array.map (Array.reduce (*))

let productInABackDiagonal (xs : int [,]) : int =
    xs.[0, 0] * xs.[1, 1] * xs.[2, 2] * xs.[3, 3]

let productInAForwardDiagonal (xs : int [,]) : int =
    xs.[0, 3] * xs.[1, 2] * xs.[2, 1] * xs.[3, 0]
```

#### Define a lazy sequence of all relevant products:
```fsharp
let products : int seq =
    seq {
        let l = data.GetLength 0
        for i in 0..l - 1 do
            yield! data.[i, *] |> productsInARow
            yield! data.[*, i] |> productsInARow
        for i in 0..l - 5 do
            for j in 0..l - 5 do
                let xs = data.[i..i + 3, j..j + 3]
                yield productInABackDiagonal xs
                yield productInAForwardDiagonal xs
    }
```

#### Produce the answer by retrieving the largest product:
```fsharp
let answer = Seq.max products
```

#### Print out the answer:
```fsharp
printfn "answer = %i" answer
```
