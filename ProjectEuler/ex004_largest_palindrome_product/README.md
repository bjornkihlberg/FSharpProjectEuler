# Project Euler problem 4: Largest palindrome product
[Project Euler problem 4](https://projecteuler.net/problem=4)
---
___
## Solution:
```fsharp
let palindromes : int seq =
    seq {
        for i in 9..-1..1 do
            for j in 9..-1..0 do
                for k in 9..-1..0 do yield i * 100001 + j * 10010 + k * 1100
        for i in 9..-1..1 do
            for j in 9..-1..0 do
                for k in 9..-1..0 do yield i * 10001 + j * 1010 + k * 100
        for i in 9..-1..1 do
            for j in 9..-1..0 do yield i * 1001 + j * 110
        for i in 9..-1..1 do yield i * 11 }
    |> Seq.skipWhile ((>=) (999 * 999)) |> Seq.takeWhile ((<=) (100 * 100))

let is3DigitNumber (x : int) : bool =
    x >= 100 && x <= 999

let isProductOf2_3DigitNumbers2 (pal : int) : bool =
    let rec loop (i : int) : bool =
        is3DigitNumber i && (pal % i = 0 && is3DigitNumber (pal / i) || loop (i + 1))
    loop 100

let answer = Seq.find isProductOf2_3DigitNumbers2 palindromes

printfn "answer = %i" answer
```

#### Create a lazy sequence of relevant palindromes:
The palindromes relevant for our solution are the ones smaller than or equal to the product of the two largest three digit numbers; 999 and greater or equal to the product of the smallest three digit numbers: 100. Since the largest palindrome is what we are looking for, we produce them in a sequence from largest to smallest and then filter out the unwanted ones.
```fsharp
let palindromes : int seq =
    seq {
        for i in 9..-1..1 do
            for j in 9..-1..0 do
                for k in 9..-1..0 do yield i * 100001 + j * 10010 + k * 1100
        for i in 9..-1..1 do
            for j in 9..-1..0 do
                for k in 9..-1..0 do yield i * 10001 + j * 1010 + k * 100
        for i in 9..-1..1 do
            for j in 9..-1..0 do yield i * 1001 + j * 110
        for i in 9..-1..1 do yield i * 11 }
    |> Seq.skipWhile ((>=) (999 * 999)) |> Seq.takeWhile ((<=) (100 * 100))
```

#### Define a helper function that tests wether a number is a three digit number:
```fsharp
let is3DigitNumber (x : int) : bool =
    x >= 100 && x <= 999
```

#### Define a function that tests if a number is a product of two three digit numbers:
```fsharp
let isProductOf2_3DigitNumbers2 (pal : int) : bool =
    let rec loop (i : int) : bool =
        is3DigitNumber i && (pal % i = 0 && is3DigitNumber (pal / i) || loop (i + 1))
    loop 100
```

#### Find the first (largest) palindrome in our sequence that is a product of two three digit numbers:
```fsharp
let answer = Seq.find isProductOf2_3DigitNumbers2 palindromes
```

#### Print out the answer:
```fsharp
printfn "answer = %i" answer
```
