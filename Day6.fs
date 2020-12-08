module AoC2015.Day6

open System.Text.RegularExpressions
open AoC2015.Utils

type Command =
    | On
    | Off
    | Toggle

let getValue cmd current =
    match cmd with
    | On -> 1
    | Off -> 0
    | Toggle ->
        match current with
        | 0 -> 1
        | 1 -> 0

let getValue2 cmd current =
    let value =
        match cmd with
        | On -> current + 1
        | Off -> current - 1
        | Toggle -> current + 2

    if value < 0 then 0 else value

let turn (lights: int [,]) valuegetter cmd x1 y1 x2 y2 () =
    for x in x1 .. x2 do
        for y in y1 .. y2 do
            let current = lights.[x, y]
            let value = valuegetter cmd current
            lights.[x, y] <- value

let parse valuegetter lights s =
    let re =
        Regex("^(?<command>turn on|turn off|toggle) (?<x1>\d+),(?<y1>\d+) through (?<x2>\d+),(?<y2>\d+)")

    let m = re.Match(s)

    let cmd =
        match m.Groups.["command"].Value with
        | "turn on" -> On
        | "turn off" -> Off
        | "toggle" -> Toggle

    let x1 = int m.Groups.["x1"].Value
    let y1 = int m.Groups.["y1"].Value
    let x2 = int m.Groups.["x2"].Value
    let y2 = int m.Groups.["y2"].Value
    turn lights valuegetter cmd x1 y1 x2 y2 ()


let day6' input valFun () =
    let (lights: int [,]) = Array2D.zeroCreate 1000 1000
    input |> Seq.iter (parse valFun lights)
    lights |> Seq.cast<int> |> Seq.sum

let day6 () = day6' (readInput "6") getValue ()

let day6part2 () = day6' (readInput "6") getValue2 ()
