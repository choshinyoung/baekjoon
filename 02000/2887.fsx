let n = stdin.ReadLine() |> int

let nodes =
    Array.init n (fun x -> x, stdin.ReadLine().Split() |> Array.map int64)

let edges =
    [| 0..2 |]
    |> Array.collect (fun axis ->
        nodes
        |> Array.sortBy (fun (_, a) -> a[axis])
        |> Array.pairwise
        |> Array.map (fun ((i, a), (j, b)) ->
            abs (a[axis] - b[axis]), i, j))
    |> Array.sort

let parents = Array.init n id

let rec find a =
    if parents[a] <> a then
        parents[a] <- find parents[a]

    parents[a]

let union a b =
    let a' = find a
    let b' = find b

    if a' <> b' then
        parents[b'] <- a'
        true
    else
        false

let mutable mst = 0L

for c, u, v in edges do
    if union u v then
        mst <- mst + c

printfn "%d" mst
