open System
open System.Collections.Generic

let [| v; e |] = Console.ReadLine().Split() |> Array.map int

let graph = Array.init (v + 1) (fun _ -> [])

for _ in 1..e do
    let [| a; b; c |] = Console.ReadLine().Split() |> Array.map int

    graph[a] <- (b, c) :: graph[a]
    graph[b] <- (a, c) :: graph[b]

let visited = Array.zeroCreate (v + 1)
let mutable mst = 0

let queue = PriorityQueue<int * int, int>()
queue.Enqueue((1, 0), 0)

while queue.Count > 0 do
    let u, w = queue.Dequeue()

    if not visited[u] then
        visited[u] <- true
        mst <- mst + w

        for u', w' in graph[u] do
            if not visited[u'] then
                queue.Enqueue((u', w'), w')

printfn "%d" mst
