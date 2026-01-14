open System

let input () =
    Console.ReadLine().Split() |> Array.map int

let t = Console.ReadLine() |> int

for _ in 1..t do
    let [| n; k |] = input ()
    let d = input ()

    let graph = Array.init (n + 1) (fun _ -> [])
    let time = Array.create (n + 1) -1

    for _ in 1..k do
        let [| u; v |] = input ()
        graph[v] <- u :: graph[v]

    let w = Console.ReadLine() |> int

    let rec dfs u =
        if time[u] = -1 then
            let m =
                graph[u]
                |> List.fold (fun acc prev -> max acc (dfs prev)) 0

            time[u] <- d[u - 1] + m

        time[u]

    dfs w |> printfn "%d"
