module AoC2015.Day8

open System.Text.RegularExpressions
open AoC2015.Utils

let getDiff (s: string) =
    let unescaped =
        Regex.Unescape(s.[1..(Seq.length s - 2)])

    printfn "%s - %s" s unescaped
    String.length s - String.length unescaped

let day8 () = readInput "8" |> Seq.sumBy getDiff

let day8part2 () = 0
