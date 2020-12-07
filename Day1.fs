module AoC2015.Day1

open AoC2015.Utils

let parenToFloor =
    char
    >> function
    | ')' -> -1
    | '(' -> 1
    | _ -> 0

let day1 () =
    readAll "1"
    |> Seq.map parenToFloor
    |> Seq.sum

let day1part2 () =
    readAll "1"
    |> Seq.map parenToFloor
    |> Seq.scan (+) 0
    |> Seq.takeWhile (fun c -> c >= 0)
    |> Seq.length