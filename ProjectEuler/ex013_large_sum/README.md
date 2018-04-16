# Project Euler problem 13: Large sum
[Project Euler problem 13](https://projecteuler.net/problem=13)
---
___
## Solution:
```fsharp
let data : bigint seq = System.IO.File.ReadLines "data_source.txt"
                        |> Seq.map System.Numerics.BigInteger.Parse

let answer : string = Seq.reduce (+) data
                      |> string |> Seq.take 10 |> System.String.Concat

printfn "answer = %s" answer
```

## Walkthrough:

#### Load and parse data:
```fsharp
let data : bigint seq = System.IO.File.ReadLines "data_source.txt"
                        |> Seq.map System.Numerics.BigInteger.Parse
```

#### Sum and take out first ten numbers:
For sake of simplicity the number is just converted to a string and then the first ten characters are taken out.
```fsharp
let answer : string = Seq.reduce (+) data
                      |> string |> Seq.take 10 |> System.String.Concat
```

#### Print out the answer:
```fsharp
printfn "answer = %s" answer
```
