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

    let countVowels =
        Seq.filter isVowel >> Seq.length 
        
    hasDouble && (not hasForbidden) && (countVowels input >= 3)

let day5 () = readInput "5" |> Seq.filter isNice |> Seq.length
