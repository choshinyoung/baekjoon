open System

let t = Console.ReadLine() |> int

for _ in 1..t do
    let n = Console.ReadLine() |> int
    let a = Console.ReadLine().Split() |> Array.map (fun x -> int x - 1)

    let visited = Array.zeroCreate n
    let finished = Array.zeroCreate n
    let mutable result = 0

    let rec dfs s =
        if visited[s] then
            if not finished[s] then
                let rec cycle s' = if s' <> s then 1 + cycle a[s'] else 1
                result <- result + cycle a[s]
        else
            visited[s] <- true
            dfs a[s]

        finished[s] <- true

    for i in 0 .. n - 1 do
        dfs i

    n - result |> printfn "%d"
