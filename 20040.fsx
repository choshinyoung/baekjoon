open System

let [| n; m |] = Console.ReadLine().Split() |> Array.map int

let parent = Array.init n id

let rec find x =
    if parent[x] = x then
        x
    else
        parent[x] <- find parent[x]
        parent[x]

[ 1..m ]
|> List.map (fun _ -> Console.ReadLine().Split() |> Array.map int)
|> List.iteri (fun i [| a; b |] ->
    let rootA = find a
    let rootB = find b

    if rootA = rootB then
        printfn "%d" (i + 1)
        exit 0

    parent[rootB] <- rootA)

printf "0"
