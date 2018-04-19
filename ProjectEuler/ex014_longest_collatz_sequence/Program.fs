let collatzSeqLength : int -> int =
    let rec collatzSeqLength (counter : int) (n : uint32) : int =
        if n = 1u then counter
        else if n % 2u = 0u then collatzSeqLength (counter + 1) (n / 2u)
                            else collatzSeqLength (counter + 2) ((n * 3u + 1u) / 2u)
    uint32 >> collatzSeqLength 1

let answer : int =
    Seq.init 999_999 ((+) 1) |> Seq.maxBy collatzSeqLength

printfn "answer = %i" answer
