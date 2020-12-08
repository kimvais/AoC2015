open AoC2015.Utils
open AoC2015.Day1
open AoC2015.Day2
open AoC2015.Day3
open AoC2015.Day4
open AoC2015.Day5
open AoC2015.Day6
open AoC2015.Day8



[<EntryPoint>]
let main argv =
    let day = argv |> getProblem
    match day with
    | "1" -> day1 ()
    | "1b" -> day1part2 ()
    | "2" -> day2 ()
    | "2b" -> day2part2 ()
    | "3" -> day3 "3" ()
    | "3b" -> day3part2 "3" ()
    | "4" -> day4 ()
    | "4b" -> day4part2 ()
    | "5" -> day5 ()
    | "5b" -> day5part2 ()
    | "6" -> day6 ()
    | "6b" -> day6part2 ()
    | "8" -> day8 ()
    | "8b" -> day8part2 ()
    | _ -> 1
    |> printfn "%d"
    0
