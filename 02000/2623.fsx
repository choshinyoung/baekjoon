open System

let [| n; m |] = Console.ReadLine().Split() |> Array.map int

let graph = Array.init (n + 1) (fun _ -> [])
let visited = Array.zeroCreate (n + 1)
let mutable result = []

for _ in 1..m do
    let a :: b =
        Console.ReadLine().Split() |> Array.map int |> Array.toList

    for i in 0 .. (a - 2) do
        graph[b[i]] <- b[i + 1] :: graph[b[i]]

let rec dfs u =
    if visited[u] = 0 then
        visited[u] <- 1
        graph[u] |> List.iter dfs

        visited[u] <- 2
        result <- u :: result
    elif visited[u] = 1 then
        printfn "0"
        exit 0

[ 1..n ] |> List.iter dfs
result |> List.map string |> String.concat "\n" |> printfn "%s"
