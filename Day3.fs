module AoC2015.Day3

open AoC2015.Utils

type Direction =
    | North
    | South
    | East
    | West

type State =
    { x: int
      y: int
      presents: Map<(int * int), int> }

let initialState = { x = 0; y = 0; presents = Map.empty |> Map.add (0, 0) 1 }

let getDirection =
    function
    | '^' -> North
    | 'v' -> South
    | '<' -> West
    | '>' -> East
    | c -> failwith (sprintf "Invalid direction: %c!" c)

let move dir =
    match dir with
    | North -> (-1, 0)
    | East -> (0, 1)
    | South -> (1, 0)
    | West -> (0, -1)

let deliverAPresent state dir =
    let x = state.x + fst dir
    let y = state.y + snd dir

    let deliverTo =
        match (state.presents |> Map.tryFind (x, y)) with
        | Some n -> n + 1
        | None -> 1

    { x = x
      y = y
      presents = state.presents |> Map.add (x, y) deliverTo }

let deliverAllPresents initial dirs =
    dirs
    |> Seq.map (getDirection >> move)
    |> Seq.fold deliverAPresent initial

let day3 fn () =
    let delivered =
        readAll fn
        |> Seq.map char
        |> deliverAllPresents initialState
    // printfn "%A" delivered
    delivered.presents |> Map.count

let splitOrders dirs =
    dirs
    |> List.ofSeq
    |> List.chunkBySize 2
    |> List.map (fun [ a; b ] -> (char a, char b))
    |> List.unzip

let day3part2 fn () =
    let orders = readAll fn |> splitOrders

    let santa =
        fst orders
        |> Seq.ofList
        |> deliverAllPresents initialState

    let robot =
        snd orders
        |> Seq.ofList
        |> deliverAllPresents {santa with x=0; y=0}

    robot.presents |> Map.count
