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

let answer : int = Seq.find isProductOf2_3DigitNumbers2 palindromes

printfn "answer = %i" answer
