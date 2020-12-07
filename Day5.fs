module AoC2015.Day5

open AoC2015.Utils


let hasForBidden (a, b) =
    match (a, b) with
    | ('a', 'b')
    | ('c', 'd')
    | ('p', 'q')
    | ('x', 'y') -> true
    | _ -> false

let isVowel =
    function
    | 'a'
    | 'e'
    | 'i'
    | 'o'
    | 'u' -> true
    | _ -> false

let isNice s =
    let input = Seq.cache s

    let hasDouble =
        Seq.pairwise input
        |> Seq.exists (fun (a, b) -> a = b)

    let hasForbidden =
        Seq.pairwise input |> Seq.exists hasForBidden

    let countVowels = Seq.filter isVowel >> Seq.length

    hasDouble
    && (not hasForbidden)
    && (countVowels input >= 3)

let isNice2 (s: string) =
    let input = Seq.cache s

    let getOffset (s: seq<string * int>) =
        let a = snd (Seq.head s)
        let b = snd (Seq.last s)
        (fst (Seq.head s)), b - a

    let hasXYX =
        Seq.windowed 3
        >> Seq.exists (fun [| a; _; b |] -> a = b)

    let hasPair =
        Seq.pairwise
        >> Seq.mapi (fun i (a, b) -> (sprintf "%c%c" a b), i)
        >> Seq.groupBy fst
        >> Seq.map (snd >> getOffset)
        >> Seq.exists (snd >> (<) 1)

    hasXYX input && hasPair input

let day5 () =
    readInput "5" |> Seq.filter isNice |> Seq.length

let day5part2 () =
    readInput "5" |> Seq.filter isNice2 |> Seq.length
