module AoC2015.Utils

open System.Security.Cryptography
open System.Text
open System.IO


let readLines filePath = File.ReadLines(filePath)
let readFile filePath = File.ReadAllBytes(filePath)

let readInput (s: string) =
    readLines (__SOURCE_DIRECTORY__ + (sprintf "/input/%s.txt" s))

let readAll (s: string) =
    readFile (__SOURCE_DIRECTORY__ + (sprintf "/input/%s.txt" s))

let getProblem (a: seq<string>): string = a |> Seq.head

let md5 (data: byte array): string =
    use md5 = MD5.Create()
    (StringBuilder(), md5.ComputeHash(data))
    ||> Array.fold (fun sb b -> sb.Append(b.ToString("x2")))
    |> string
