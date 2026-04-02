open System.Collections.Generic

let INF = System.Int32.MaxValue

let swap i j a =
    let i', j' = i - 1, j - 1

    a
    |> List.mapi (fun k x ->
        if k = i' then a[j']
        elif k = j' then a[i']
        else x)

stdin.ReadLine() |> ignore
let a = stdin.ReadLine().Split() |> Array.map int |> Array.toList
let m = stdin.ReadLine() |> int

let vertextes =
    Array.init m (fun _ -> stdin.ReadLine().Split() |> Array.map int)

let distance = Dictionary<int list, int>()
let queue = PriorityQueue<int list * int, int>()

distance[a] <- 0
queue.Enqueue((a, 0), 0)

while queue.Count > 0 do
    let current, cost = queue.Dequeue()

    if cost <= distance.GetValueOrDefault(current, INF) then
        for [| l; r; c |] in vertextes do
            let next = current |> swap l r
            let cost' = cost + c

            if cost' < distance.GetValueOrDefault(next, INF) then
                distance[next] <- cost'
                queue.Enqueue((next, cost'), cost')

distance.GetValueOrDefault(List.sort a, -1) |> printfn "%d"
