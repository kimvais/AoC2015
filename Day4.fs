module AoC2015.Day4

open System.Text.RegularExpressions
open AoC2015.Utils

let input = "ckczppom"
let leadingZeroesRe n = Regex((sprintf "^0{%d}.*" n))

let checkForLeadingZeroes n s = (leadingZeroesRe n).IsMatch(s)

let findHashWithLeadingZeroes n i =
    sprintf "%s%d" input i
    |> Seq.map byte
    |> Array.ofSeq
    |> md5
    |> checkForLeadingZeroes n

let day4 () =
    Seq.initInfinite id
    |> Seq.filter (findHashWithLeadingZeroes 5)
    |> Seq.head

let day4part2 () =
    Seq.initInfinite id
    |> Seq.filter (findHashWithLeadingZeroes 6)
    |> Seq.head
