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
