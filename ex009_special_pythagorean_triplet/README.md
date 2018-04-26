# Project Euler problem 9: Special Pythagorean triplet
[Project Euler problem 9](https://projecteuler.net/problem=9)
---
___
## Solution:
```fsharp
let c_min, c_max = 335, 997
let b_min, b_max = 2, 499
let a_min, a_max = 1, 332

let triplets : int seq =
    seq {
        for c in c_min..c_max do
            for b in b_min..b_max do
                for a in a_min..a_max do
                    if a + b + c = 1000 && a*a + b*b = c*c
                    then yield a * b * c
    }

let answer = Seq.head triplets

printfn "%A" answer
```

## Walkthrough:

#### Reduce problem scope by narrowing the possible values of the triplet:
* `c` can at most be 997 when `b` is at its lowest 2 and `a` is at its lowest 1.
* `b` can at most be 499 when `c` is 500 and `a` is 1.
* `c` is at it's lowest level when `c`, `b` and `a` are almost equal at 333, 333 and 333, except `c` has to be larger than `b` and `b` larger than `a` so they'd be 334, 333 and 332 respectively except now their sum is only 999 so one has to increase by 1 - only `c` can increase by one so the smallest value for `c` is 335 and largest value for `a` is 332.
```fsharp
let c_min, c_max = 335, 997
let b_min, b_max = 2, 499
let a_min, a_max = 1, 332
```

#### Create a lazy sequence of the products of all possible triplets:
According to the problem description, there should only be one combination that is valid. When evaluating the sequence, the first (and only) value will be the correct one.
```fsharp
let triplets : int seq =
    seq {
        for c in c_min..c_max do
            for b in b_min..b_max do
                for a in a_min..a_max do
                    if a + b + c = 1000 && a*a + b*b = c*c
                    then yield a * b * c
    }
```

#### Retrieve the first value and produce the answer:
```fsharp
let answer = Seq.head triplets
```

#### Print out the answer:
```fsharp
printfn "%A" answer
```
