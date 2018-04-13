# Project Euler problem 8: Largest product in a series
[Project Euler problem 8](https://projecteuler.net/problem=8)
---
___
## Solution:
A txt-file named `1000_digit_number.txt` contains the numbers to search.
```fsharp
open System.IO

let charToInt (c : char) : int64 = int64 c - int64 '0'

let ns : int64 seq =
     File.ReadLines "1000_digit_number.txt"
     |> Seq.concat
     |> Seq.map charToInt

let products : int64 seq =
    Seq.windowed 13 ns
    |> Seq.map (Array.reduce (*))

let answer : int64 = Seq.max products

printfn "answer = %i" answer
```

## Walkthrough:

#### Define helper function to parse characters to integers:
We need to work with 64bit integers because 32bit is too small to deal with the large products.
```fsharp
let charToInt (c : char) : int64 = int64 c - int64 '0'
```

#### Read all numbers from `1000_digit_number.txt`:
```fsharp
let ns : int64 seq =
     File.ReadLines "1000_digit_number.txt"
     |> Seq.concat
     |> Seq.map charToInt
```

#### Produce the products of thirteen adjacent numbers:
```fsharp
let products : int64 seq =
    Seq.windowed 13 ns
    |> Seq.map (Array.reduce (*))
```

#### Get the largest product:
```fsharp
let answer : int64 = Seq.max products
```

#### Print out the answer:
```fsharp
printfn "answer = %i" answer
```
