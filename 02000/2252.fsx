open System

let [| n; m |] = Console.ReadLine().Split() |> Array.map int

let graph = Array.init (n + 1) (fun _ -> [])
let visited = Array.zeroCreate (n + 1)
let mutable result = []

for _ in 1..m do
    let [| u; v |] = Console.ReadLine().Split() |> Array.map int
    graph[u] <- v :: graph[u]

let rec dfs u =
    if not (visited[u]) then
        graph[u] |> List.iter dfs

        visited[u] <- true
        result <- u :: result

[ 1..n ] |> List.iter dfs
result |> List.map string |> String.concat " " |> printfn "%s"
