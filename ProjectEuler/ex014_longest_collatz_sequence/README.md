# Project Euler problem 14: Longest Collatz sequence
[Project Euler problem 14](https://projecteuler.net/problem=14)
---
___
## Solution:
```fsharp
let collatzSeqLength : int -> int =
    let rec collatzSeqLength (counter : int) (n : uint32) : int =
        if n = 1u then counter
        else if n % 2u = 0u then collatzSeqLength (counter + 1) (n / 2u)
                            else collatzSeqLength (counter + 2) ((n * 3u + 1u) / 2u)
    uint32 >> collatzSeqLength 1

let answer : int =
    Seq.init 999_999 ((+) 1) |> Seq.maxBy collatzSeqLength

printfn "answer = %i" answer
```

## Walkthrough:
This problem has been really humbling for me. Immediately when I looked at this I started thinking about optimization; I would cache already discovered sequences and look them up during every loop and so on. That didn't work.

Then I found that since the sequence can only ever decrease in value by halving, only a 2 could lead to a 1, and only a 4 could lead to a 2 etc. So I would take the second logarithm of a value and see if I get a whole number back and break the loop early. Finally my solution would resolve in a reasonable amount of time. Then just for fun I decided to remove this feature and see what happened. Well... Time went down by about 80%... :-|

Turns out that premature optimization is the root of all evil... ;P Who would've thunk?

#### Define a function that finds the length of the collatz sequence for a given number:
```fsharp
let collatzSeqLength : int -> int =
    let rec collatzSeqLength (counter : int) (n : uint32) : int =
        if n = 1u then counter
        else if n % 2u = 0u then collatzSeqLength (counter + 1) (n / 2u)
                            else collatzSeqLength (counter + 2) ((n * 3u + 1u) / 2u)
    uint32 >> collatzSeqLength 1
```

#### Produce the answer:
```fsharp
let answer : int =
    Seq.init 999_999 ((+) 1) |> Seq.maxBy collatzSeqLength
```

#### Print out the answer:
```fsharp
printfn "answer = %i" answer
```
