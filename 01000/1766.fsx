open System
open System.Collections.Generic

let [| n; m |] = Console.ReadLine().Split() |> Array.map int

let graph = Array.init (n + 1) (fun _ -> [])
let indegree = Array.zeroCreate (n + 1)
let mutable result = []

for _ in 1..m do
    let [| a; b |] = Console.ReadLine().Split() |> Array.map int

    graph[a] <- b :: graph[a]
    indegree[b] <- indegree[b] + 1

let queue = PriorityQueue<int, int>()

(indegree, [| 0..n |])
||> Array.iter2 (fun x i ->
    if x = 0 && i <> 0 then
        queue.Enqueue(i, i))

while queue.Count > 0 do
    let u = queue.Dequeue()
    result <- u :: result

    for v in graph[u] do
        indegree[v] <- indegree[v] - 1

        if indegree[v] = 0 then
            queue.Enqueue(v, v)

result |> List.rev |> List.map string |> String.concat " " |> printfn "%s"
