module AoC2015.Day2
open AoC2015.Utils


let getDims (s:string) =
    s.Split 'x' |> Seq.map int |> Array.ofSeq
       
let day2 () =
    let getSides (sideArray:array<int>) =
        let l = sideArray.[0]
        let h = sideArray.[1]
        let w = sideArray.[2]
        [| l * w; l * h; w * h |] 

    let countUsage s =
        let sides = Seq.cache s
        Seq.min sides + (Seq.map ((*) 2) sides |> Seq.sum)

    readInput "2" |> Seq.map (getDims >> getSides >> countUsage) |> Seq.sum 

let day2part2 () =
    let getSides (s:array<int>) =
        [| s.[0]; s.[1]; s.[2] |] |> Array.sort
    let sides = readInput "2" |> Seq.map (getDims >> getSides)
    let calculateRibbon p =
        let wrap = (p |> Array.take 2 |> Seq.sum) * 2
        let bow = p |> Array.reduce (*)
        bow + wrap
    sides |> Seq.map calculateRibbon |> Seq.sum
    